using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    public sealed class IterationsExceededException<T> : Exception where T : struct
    {
        public T LastValue { get; }

        public IterationsExceededException(T value)
        {
            LastValue = value;
        }
    }
}
