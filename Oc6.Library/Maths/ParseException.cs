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
    public class ParseException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ParseException(string message)
            : base(message)
        {
        }
    }
}
