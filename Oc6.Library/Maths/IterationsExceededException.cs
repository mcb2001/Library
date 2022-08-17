using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class IterationsExceededException<T> : Exception where T : struct
    {
        /// <summary>
        /// 
        /// </summary>
        public T LastValue { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public IterationsExceededException(T value)
        {
            LastValue = value;
        }
    }
}
