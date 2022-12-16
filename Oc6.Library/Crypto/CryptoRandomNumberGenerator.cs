using Oc6.Library.Resources;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Crypto
{
    public sealed class CryptoRandomNumberGenerator : IDisposable, ICryptoRandomNumberGenerator
    {
        private readonly object syncRoot = new();
        private readonly RandomNumberGenerator randomNumberGenerator;
        private readonly bool shouldDispose;
        private bool isDisposed = false;

        public CryptoRandomNumberGenerator()
            : this(RandomNumberGenerator.Create())
        {

        }

        public CryptoRandomNumberGenerator(RandomNumberGenerator randomNumberGenerator)
            : this(randomNumberGenerator, true)
        {
        }

        public CryptoRandomNumberGenerator(RandomNumberGenerator randomNumberGenerator, bool shouldDispose)
        {
            this.randomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
            this.shouldDispose = shouldDispose;
        }

        public void Shuffle<T>(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            for (int i = list.Count - 1; i > 0; --i)
            {
                int j = this.NextInt(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }

        public void Shuffle<T>(Span<T> span)
        {
            for (int i = span.Length - 1; i > 0; --i)
            {
                int j = this.NextInt(0, i + 1);
                (span[j], span[i]) = (span[i], span[j]);
            }
        }

        public void Shuffle<T>(Memory<T> memory)
        {
            Shuffle(memory.Span);
        }

        public int NextInt()
        {
            var i = NextUnBounded();

            if (i == int.MinValue)
            {
                //There are currently one 0, this is the second
                return 0;
            }
            //There are two of everything else
            else if (i < 0)
            {
                return -i;
            }

            return i;
        }

        public int NextInt(int from, int upTo)
        {
            if (upTo <= from)
            {
                var message = string.Format(CultureInfo.CurrentCulture, ErrorMessages.CryptoRandomNumberGenerator_MustBeOrdered, nameof(from), nameof(upTo));

                throw new ArgumentException(message);
            }

            return (NextInt() / (int.MaxValue / (upTo - from))) + from;
        }

        public int NextUnBounded()
        {
            lock (syncRoot)
            {
                Span<byte> buffer = stackalloc byte[4];

                randomNumberGenerator.GetBytes(buffer);

                return BitConverter.ToInt32(buffer);
            }
        }

        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }

            if (shouldDispose)
            {
                randomNumberGenerator.Dispose();
            }

            isDisposed = true;
        }
    }
}
