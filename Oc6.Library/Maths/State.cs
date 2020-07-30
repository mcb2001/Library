using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    public class State
    {
        private readonly Dictionary<string, decimal> state;

        public State()
        {
            state = new Dictionary<string, decimal>();
        }

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

        public IEnumerable<string> Variables
        {
            get
            {
                return state.Keys;
            }
        }
    }
}
