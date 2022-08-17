using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oc6.Library;
using Oc6.Library.Net;

namespace Oc6.Library.Tests.Net
{
    [TestClass]
    public class IpCidrTests
    {
        [TestMethod]
        public void TryParse_Success()
        {
            Assert.IsTrue(IpCidr.TryParse("1.2.3.4", out IpCidr _));
            Assert.IsTrue(IpCidr.TryParse("1.2.3.4/32", out IpCidr _));
            Assert.IsTrue(IpCidr.TryParse("::1", out IpCidr _));
            Assert.IsTrue(IpCidr.TryParse("::1/32", out IpCidr _));
            Assert.IsTrue(IpCidr.TryParse("2001::1", out IpCidr _));
            Assert.IsTrue(IpCidr.TryParse("2001::1/32", out IpCidr _));
            Assert.IsTrue(IpCidr.TryParse("2001:1803:1234:1234:1234:1234:1234:0001", out IpCidr _));
            Assert.IsTrue(IpCidr.TryParse("2001:1803:1234:1234:1234:1234:1234:0001/32", out IpCidr _));
        }

        [TestMethod]
        public void TryParse_InvalidIp()
        {
            Assert.IsFalse(IpCidr.TryParse("2.3.4", out IpCidr _));
            Assert.IsFalse(IpCidr.TryParse("1803:1234:1234:1234:1234:1234:0001", out IpCidr _));
        }

        [TestMethod]
        public void TryParse_InvalidMask()
        {
            Assert.IsFalse(IpCidr.TryParse("1.2.3.4/33", out IpCidr _));
            Assert.IsFalse(IpCidr.TryParse("::1/129", out IpCidr _));
        }
    }
}
