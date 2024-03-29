﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oc6.Library;
using Oc6.Library.Net;

namespace Oc6.Library.Tests.Net
{
    public class IpRangeTests
    {
        [Fact]
        public void TryParseCidr_IPv4_Success()
        {
            Assert.True(IpRange.TryParseCidr("1.2.3.4", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_IPv4CIDR_Success()
        {
            Assert.True(IpRange.TryParseCidr("1.2.3.4/32", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_IPv6_Short_Success()
        {
            Assert.True(IpRange.TryParseCidr("::1", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_IPv6CIDR_Short_Success()
        {
            Assert.True(IpRange.TryParseCidr("::1/32", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_IPv6_Medium_Success()
        {
            Assert.True(IpRange.TryParseCidr("2001::1", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_IPv6_Trailing_Success()
        {
            Assert.True(IpRange.TryParseCidr("2a01:111:f400::/48", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_IPv6CIDR_Medium_Success()
        {
            Assert.True(IpRange.TryParseCidr("2001::1/32", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_IPv6_Long_Success()
        {
            Assert.True(IpRange.TryParseCidr("2001:1803:1234:1234:1234:1234:1234:0001", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_IPv6CIDR_Long_Success()
        {
            Assert.True(IpRange.TryParseCidr("2001:1803:1234:1234:1234:1234:1234:0001/32", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_InvalidIp_Fail()
        {
            Assert.False(IpRange.TryParseCidr("2.3.4", out IpRange _));
            Assert.False(IpRange.TryParseCidr("1803:1234:1234:1234:1234:1234:0001", out IpRange _));
        }

        [Fact]
        public void TryParseCidr_InvalidMask_Fail()
        {
            Assert.False(IpRange.TryParseCidr("1.2.3.4/33", out IpRange _));
            Assert.False(IpRange.TryParseCidr("::1/129", out IpRange _));
        }

        [Fact]
        public void Overlap_SingleVsRange_Success()
        {
            IpRange range = new(new byte[] { 10, 0, 0, 0 }, 24);
            IpRange single = new(new byte[] { 10, 0, 0, 12 });
            Assert.True(single.Overlap(range));
        }

        [Fact]
        public void Overlap_Commutatitve_Success()
        {
            IpRange range = new(new byte[] { 10, 0, 0, 0 }, 24);
            IpRange single = new(new byte[] { 10, 0, 0, 12 });
            Assert.True(single.Overlap(range));
            Assert.True(range.Overlap(single));
        }

        [Fact]
        public void Overlap_RangeVsRange_TrueSubset_Success()
        {
            IpRange first = new(new byte[] { 10, 0, 0, 0 }, 8);
            IpRange second = new(new byte[] { 10, 2, 8, 0 }, 24);
            Assert.True(first.Overlap(second));
        }

        [Fact]
        public void Overlap_RangeVsRange_NotSubset_Success()
        {
            IpRange first = new(new byte[] { 10, 0, 0, 0 }, 16);
            IpRange second = new(new byte[] { 10, 0, 4, 0 }, 16);
            Assert.True(first.Overlap(second));
        }

        [Fact]
        public void Overlap_RangeVsRange_Distinct_Fail()
        {
            IpRange first = new(new byte[] { 10, 0, 0, 0 }, 16);
            IpRange second = new(new byte[] { 10, 1, 0, 0 }, 16);
            Assert.False(first.Overlap(second));
        }

        [Fact]
        public void Overlap_SingleVsRange_Distinct_Fail()
        {
            IpRange first = new(new byte[] { 10, 0, 0, 0 }, 16);
            IpRange second = new(new byte[] { 10, 1, 0, 0 });
            Assert.False(first.Overlap(second));
        }

        [Fact]
        public void Overlap_Self_Success()
        {
            IpRange self = new(new byte[] { 10, 0, 0, 12 });
            Assert.True(self.Overlap(self));
        }

        [Fact]
        public void TryParseCidr_IPv4_Equals_Self_Success()
        {
            IpRange.TryParseCidr("1.0.0.0", out IpRange range);
            IpRange.TryParseCidr(range.ToString(), out IpRange self);
            Assert.True(self.Equals(range));
        }

        [Fact]
        public void TryParseCidr_IPv4CIDR_Equals_Self_Success()
        {
            IpRange.TryParseCidr("1.0.0.0/24", out IpRange range);
            IpRange.TryParseCidr(range.ToString(), out IpRange self);
            Assert.True(self.Equals(range));
        }

        [Fact]
        public void TryParseCidr_IPv6_Equals_Self_Success()
        {
            IpRange.TryParseCidr("::1", out IpRange range);
            IpRange.TryParseCidr(range.ToString(), out IpRange self);
            Assert.True(self.Equals(range));
        }

        [Fact]
        public void TryParseCidr_IPv6CIDR_Equals_Self_Success()
        {
            IpRange.TryParseCidr("::1/24", out IpRange range);
            IpRange.TryParseCidr(range.ToString(), out IpRange self);
            Assert.True(self.Equals(range));
        }

        [Fact]
        public void ToString_IPv4_Success()
        {
            Assert.Equal("1.2.3.4/32", new IpRange(new byte[] { 1, 2, 3, 4 }).ToString());
        }

        [Fact]
        public void ToString_IPv4Cidr_Success()
        {
            Assert.Equal("1.2.3.4/16", new IpRange(new byte[] { 1, 2, 3, 4 }, 16).ToString());
        }

        [Fact]
        public void ToString_IPv6_Success()
        {
            Assert.Equal("::1/128", new IpRange(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }).ToString());
        }

        [Fact]
        public void ToString_IPv6Cidr_Success()
        {
            Assert.Equal("::1/12", new IpRange(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 12).ToString());
        }

        [Fact]
        public void ToString_IPv6_Long_Success()
        {
            Assert.Equal("101:101:101:101:101:101:101:101/128", new IpRange(new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }).ToString());
        }

        [Fact]
        public void ToString_IPv6Cidr_Long_Success()
        {
            Assert.Equal("101:101:101:101:101:101:101:101/12", new IpRange(new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 12).ToString());
        }
    }
}
