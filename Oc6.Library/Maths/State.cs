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
    public class State
    {
        private readonly Dictionary<string, decimal> state;

        /// <summary>
        /// 
        /// </summary>
        public State()
        {
            state = new Dictionary<string, decimal>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public decimal this[string variable]
        {
            get
            {
                return state[variable];
            }
            set
            {
                if (state.ContainsKey(variable))
                {
                    state[variable] = value;
                }
                else
                {
                    state.Add(variable, value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> Variables
        {
            get
            {
                return state.Keys;
            }
        }
    }
}
