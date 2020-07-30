using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Calc
{
    public sealed class State
    {
        private readonly Dictionary<string, decimal> values;

        public State()
        {
            values = new Dictionary<string, decimal>();
        }

        public decimal Get(string variable)
        {
            return values[variable];
        }

        public void Set(string variable, decimal value)
        {
            if (!values.ContainsKey(variable))
            {
                values.Add(variable, value);
            }
            else
            {
                values[variable] = value;
            }
        }

        internal static decimal Invoke(string function, params decimal[] values)
        {
            function = function.ToUpperInvariant();

            switch (function)
            {
                case "MIN":
                    {
                        return Math.Min(values[0], values[1]);
                    }
            }

            throw new NotImplementedException(string.Format(CultureInfo.InvariantCulture, ErrorMessages.State_UnknownFunction, function));
        }
    }
}
