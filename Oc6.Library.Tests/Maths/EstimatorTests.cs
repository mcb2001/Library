using Oc6.Library.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Maths
{
    public class EstimatorTests
    {
        [Fact]
        public void Estimate()
        {
            //=B2/10+(0,8*B2/12,5)
            //=365/B3

            Estimator.Estimate(1, x=>365/(x/10 + 0.8*x/12.5))
        }
    }
}
