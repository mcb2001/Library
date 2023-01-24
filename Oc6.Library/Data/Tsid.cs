using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
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
    public class TsidFactory
    {
        public const long DateTimeMask = 0b0111111111111111111111111111111111111111110000000000000000000000;

        public const long CounterMask = 0b0000000000000000000000000000000000000000001111111100000000000000;

        public const long RandomMask = 0b0000000000000000000000000000000000000000000000000011111111111111;

        private byte internalCounter = 0;

        private readonly object syncRoot = new();

        public long Create()
        {
            lock (syncRoot)
            {
                TimeSpan diff = DateTime.UtcNow - DateTime.UnixEpoch;

                long timeInMilliseconds = diff.Ticks / TimeSpan.TicksPerMillisecond;

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
                return (tsid << 1) >> 1;
            }
        }

        public static string ToShortString(long tsid)
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
    }
}
