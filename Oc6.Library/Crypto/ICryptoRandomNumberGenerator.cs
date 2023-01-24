using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Oc6.Library.Crypto
{
    public interface ICryptoRandomNumberGenerator : IDisposable
    {
        int NextInt();
        int NextInt(int from, int upTo);
        int NextUnBounded();
        void Shuffle<T>(IList<T> list);
        public void Shuffle<T>(Span<T> span);
        public void Shuffle<T>(Memory<T> memory);
    }
}