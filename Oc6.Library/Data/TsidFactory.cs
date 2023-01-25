using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Oc6.Library.Data
{
    /// <summary>
    /// <para>Time Sortable Unique Identifier</para>
    /// <para>64 integer (long)</para>
    /// <para>First 42 bits is the current millis since epoch</para>
    /// <para>Next 8 bits is a counter</para>
    /// <para>Last 14 bits is randomness</para>
    /// <para>Guarenteed to generate 255 sortable unique Tsid every millisecond</para>
    /// </summary>
    public class TsidFactory : ITsidFactory
    {
        public const long DateTimeMask = 0b0111111111111111111111111111111111111111110000000000000000000000;

        public const long CounterMask = 0b0000000000000000000000000000000000000000001111111100000000000000;

        public const long RandomMask = 0b0000000000000000000000000000000000000000000000000011111111111111;

        private byte internalCounter = 0;
        private static long previousTimeInMilliseconds = 0;

        private readonly object syncRoot = new();

        private static readonly Regex parserRegex = new("^(0[0-9a-fA-F]{11})-([0-9a-fA-F]{2})-([0-9a-fA-F]{4})$");

        public long CreateTsid()
        {
            lock (syncRoot)
            {
                TimeSpan diff = DateTime.UtcNow - DateTime.UnixEpoch;

                long timeInMilliseconds = diff.Ticks / TimeSpan.TicksPerMillisecond;

                //counter is per millisecond, so roll back to zero on next tick
                if (timeInMilliseconds != previousTimeInMilliseconds)
                {
                    previousTimeInMilliseconds = timeInMilliseconds;
                    internalCounter = 0;
                }

                //We only need the first 42 bits, leaving behind 22 0's
                timeInMilliseconds <<= 22;

                Span<byte> randomBytes = new byte[8];

                RandomNumberGenerator.Fill(randomBytes[..2]);

                randomBytes[2] = internalCounter;

                ++internalCounter;

                long randomBits = BitConverter.ToInt64(randomBytes);

                //We only have 22 bits to play with, so drop the last two random off the end
                randomBits >>= 2;

                long tsid = timeInMilliseconds | randomBits;

                //Always have first bit 0
                return tsid & long.MaxValue;
            }
        }

        public string ToTsidString(long tsid)
        {
            if (tsid < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tsid), ErrorMessages.TsidMustBePositive);
            }

            string datetime = Convert.ToString((tsid & DateTimeMask) >> 22, 16)
                .ToUpperInvariant()
                .PadLeft(12, '0');

            string counter = Convert.ToString((tsid & CounterMask) >> 14, 16)
                .ToUpperInvariant()
                .PadLeft(2, '0');

            string random = Convert.ToString(tsid & RandomMask, 16)
                .ToUpperInvariant()
                .PadLeft(4, '0');

            StringBuilder builder = new();
            builder.Append(datetime);
            builder.Append('-');
            builder.Append(counter);
            builder.Append('-');
            builder.Append(random);
            return builder.ToString();
        }

        public bool TryParseTsid(string value, out long tsid)
        {
            if (value.Length != 20)
            {
                tsid = default;
                return false;
            }


            Match match = parserRegex.Match(value);

            if (!match.Success)
            {
                tsid = default;
                return false;
            }

            if (!long.TryParse(match.Groups[1].ValueSpan, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long datetime))
            {
                tsid = default;
                return false;
            }

            if (!long.TryParse(match.Groups[2].ValueSpan, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long counter))
            {
                tsid = default;
                return false;
            }

            if (!long.TryParse(match.Groups[3].ValueSpan, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long random))
            {
                tsid = default;
                return false;
            }

            tsid = (datetime << 22) | (counter << 14) | random;

            return true;
        }
    }
}
