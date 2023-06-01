using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    public static class Estimator
    {
        public static IterationResult<double> Estimate(double expected, Expression<Func<double, double>> expression, double guess = 0, double iterations = 1000)
        {
            double x0 = guess;

            var function = expression.Compile();



            return new(x0, true);
        }

        private static IterationResult<double> Estimate()
    }
}
