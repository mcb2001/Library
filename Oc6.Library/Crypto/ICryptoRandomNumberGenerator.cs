using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Oc6.Library.Crypto
{
    /// <summary>
    /// Uses a <see cref="RandomNumberGenerator"/> to generate Int32 values
    /// </summary>
    public interface ICryptoRandomNumberGenerator : IDisposable
    {
        /// <summary>
        /// Get non-negative int
        /// </summary>
        int Next();

        /// <summary>
        /// Get bounded int
        /// </summary>
        int Next(int from, int to);

        /// <summary>
        /// Fisher-Yates shuffles any <see cref="IList{T}"/> (includes <see cref="List{T}"/> and T[]
        /// </summary>
        void Shuffle<T>(IList<T> list);

        /// <summary>
        /// Fisher-Yates shuffles any <see cref="Span{T}"/>
        /// </summary>
        public void Shuffle<T>(Span<T> span);

        /// <summary>
        /// Fisher-Yates shuffles any <see cref="Memory{T}"/>
        /// </summary>
        public void Shuffle<T>(Memory<T> memory);
    }
}