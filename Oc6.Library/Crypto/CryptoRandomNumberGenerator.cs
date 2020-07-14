using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Crypto
{
    /// <summary>
    /// Uses a <see cref="RandomNumberGenerator"/> to generate Int32 values
    /// </summary>
    public sealed class CryptoRandomNumberGenerator : IDisposable, ICryptoRandomNumberGenerator
    {
        private readonly object syncRoot = new object();
        private readonly byte[] buffer = new byte[4];
        private readonly RandomNumberGenerator randomNumberGenerator;
        private readonly bool shouldDispose;

        /// <summary>
        /// Creates a new default and shouldDispose = true
        /// </summary>
        public CryptoRandomNumberGenerator()
            : this(RandomNumberGenerator.Create())
        {

        }

        /// <summary>
        /// Uses supplied numbergenerator and shouldDispose = true
        /// </summary>
        public CryptoRandomNumberGenerator(RandomNumberGenerator randomNumberGenerator)
            : this(randomNumberGenerator, true)
        {
        }

        /// <summary>
        /// Uses supplied parameters
        /// </summary>
        public CryptoRandomNumberGenerator(RandomNumberGenerator randomNumberGenerator, bool shouldDispose)
        {
            this.randomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
            this.shouldDispose = shouldDispose;
        }

        /// <summary>
        /// Fisher-Yates shuffles any <see cref="IList{T}"/> (includes <see cref="List{T}"/> and T[]
        /// </summary>
        public void Shuffle<T>(IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; --i)
            {
                int j = this.Next(0, i + 1);
                T a = list[i];
                list[i] = list[j];
                list[j] = a;
            }
        }

        /// <summary>
        /// Fisher-Yates shuffles any <see cref="Span{T}"/>
        /// </summary>
        public void Shuffle<T>(Span<T> span)
        {
            for (int i = span.Length - 1; i > 0; --i)
            {
                int j = this.Next(0, i + 1);
                T a = span[i];
                span[i] = span[j];
                span[j] = a;
            }
        }

        /// <summary>
        /// Fisher-Yates shuffles any <see cref="Memory{T}"/>
        /// </summary>
        public void Shuffle<T>(Memory<T> memory)
        {
            var span = memory.Span;

            for (int i = span.Length - 1; i > 0; --i)
            {
                int j = this.Next(0, i + 1);
                T a = span[i];
                span[i] = span[j];
                span[j] = a;
            }
        }

        /// <summary>
        /// Get non-negative int
        /// </summary>
        public int Next()
        {
            var i = Yield();

            if (i == int.MinValue)
            {
                //There are two 0s
                return 0;
            }
            else
            {
                //And two of everything else
                return Math.Abs(i);
            }
        }

        /// <summary>
        /// Get bounded int
        /// </summary>
        public int Next(int from, int to)
        {
            if (to <= from)
            {
                throw new ArgumentException($"[{nameof(from)}] must be smaller than [{nameof(to)}]");
            }

            return (Next() / (int.MaxValue / (to - from))) + from;
        }

        private int Yield()
        {
            lock (syncRoot)
            {
                randomNumberGenerator.GetBytes(buffer);

                return BitConverter.ToInt32(buffer, 0);
            }
        }

        /// <summary>
        /// Disposes the internal numbergenerator if shouldDispose is true
        /// </summary>
        public void Dispose()
        {
            if (shouldDispose)
            {
                randomNumberGenerator.Dispose();
            }
        }
    }
}
