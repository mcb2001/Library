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
    public static class Tsid
    {
        /// <summary>
        /// The internal counter to allow for multiple Tsid's to be created at the same millisecond and still be sortable.
        /// </summary>
        private static byte internalCounter = 0;

        /// <summary>
        /// This factory is thread safe
        /// </summary>
        private static readonly object syncRoot = new();

        /// <summary>
        /// Creates a new Time Sortable Unique Identifier
        /// </summary>
        /// <returns></returns>
        public static long Create()
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

            string baseString = Convert.ToString(tsid, 16)
                .ToUpperInvariant()
                .PadLeft(16, '0');

            StringBuilder builder = new();
            builder.Append(baseString[0]);
            builder.Append(baseString[1]);
            builder.Append(baseString[2]);
            builder.Append(baseString[3]);
            builder.Append('-');
            builder.Append(baseString[4]);
            builder.Append(baseString[5]);
            builder.Append(baseString[6]);
            builder.Append(baseString[7]);
            builder.Append('-');
            builder.Append(baseString[8]);
            builder.Append(baseString[9]);
            builder.Append(baseString[10]);
            builder.Append(baseString[11]);
            builder.Append('-');
            builder.Append(baseString[12]);
            builder.Append(baseString[13]);
            builder.Append(baseString[14]);
            builder.Append(baseString[15]);
            return builder.ToString();
        }
    }
}
