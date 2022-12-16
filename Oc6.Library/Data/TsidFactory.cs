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
    /// <para>Next 6 bits is a counter</para>
    /// </summary>
    public static class TsidFactory
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

                long randomBits = BitConverter.ToInt64(randomBytes);

                randomBits >>= 2;

                Span<byte> counterBytes = new byte[] { 0, 0, ++internalCounter, 0, 0, 0, 0, 0 };

                long counterBits = BitConverter.ToInt64(counterBytes);

                long tsid = timeInMilliseconds | counterBits | randomBits;

                return tsid;
            }
        }
    }
}
