using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Data
{
    [TestClass]
    public class TsidFactoryTests
    {
        [TestMethod]
        public void Create_Validate_Sortable()
        {
            List<long> unsorted = Enumerable.Range(0, 100)
                .Select(_ => TsidFactory.Create())
                .ToList();

            List<long> sorted = new(unsorted);

            sorted.Sort();

            for (int i = 0; i < sorted.Count; ++i)
            {
                //7009506480378363230
                //7009506480378422900
                if (sorted[i] != unsorted[i])
                {
                    Assert.AreEqual(sorted[i], unsorted[i]);
                }
            }
        }
    }
}
