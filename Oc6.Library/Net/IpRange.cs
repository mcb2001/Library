using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Oc6.Library.Net
{
    public class IpRange : IEquatable<IpRange>
    {
        private byte[] Address { get; }

        private int Mask { get; }

        public Span<byte> GetAddress()
            => Address;

        public int GetMask()
            => Mask;

        public AddressFamily Family => Address.Length == 4 ? AddressFamily.InterNetwork : AddressFamily.InterNetworkV6;

        private static readonly char[] ValidChars = new[] {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A','B','C','D','E','F',
            '.', ':', '/', };
        private string Comparable { get; }
        private Regex Comparer { get; }

        public IpRange(byte[] addressBytes, int mask)
        {
            if (addressBytes == null)
            {
                throw new ArgumentNullException(nameof(addressBytes));
            }

            if (!(addressBytes.Length == 16 || addressBytes.Length == 4))
            {
                throw new ArgumentOutOfRangeException(nameof(addressBytes), ErrorMessages.InvalidAddressSize);
            }

            if (mask > addressBytes.Length * 8 || mask < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(mask), ErrorMessages.InvalidMask);
            }

            Address = addressBytes;
            Mask = mask;

            List<char> chars = new(Address.Length * 8);

            foreach (var value in Address)
            {
                chars.AddRange(Convert.ToString(value, 2).PadLeft(8, '0'));
            }

            for (int i = Mask; i < chars.Count; ++i)
            {
                chars[i] = '.';
            }

            Comparable = new string(chars.ToArray());

            Comparer = new Regex('^' + Comparable + '$');
        }

        public IpRange(byte[] addressBytes)
            : this(addressBytes ?? throw new ArgumentNullException(nameof(addressBytes)),
                  addressBytes.Length * 8)
        {

        }

        public static bool TryParseCidr(string value, out IpRange? ipCidr)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = value.ToUpperInvariant();

            if (value.Any(c => !ValidChars.Contains(c)))
            {
                ipCidr = null;
                return false;
            }

            var indexOfSlash = value.IndexOf('/', StringComparison.Ordinal);

            if (indexOfSlash < 0)
            {
                return GetIpCidr(value, out ipCidr);
            }
            else
            {
                var maskString = value[(indexOfSlash + 1)..];

                if (!int.TryParse(maskString, out int mask))
                {
                    ipCidr = null;
                    return false;
                }
                else
                {
                    var ip = value[0..indexOfSlash];

                    return GetIpCidr(ip, out ipCidr, mask);
                }
            }
        }

        private static bool GetIpCidr(string ip, out IpRange? ipCidr, int? mask = null)
        {
            if (IPAddress.TryParse(ip, out IPAddress? ipaddr))
            {
                if (ipaddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (!ValidateIPv4(ip))
                    {
                        ipCidr = null;
                        return false;
                    }
                }
                else if (ipaddr.AddressFamily != AddressFamily.InterNetworkV6)
                {
                    ipCidr = null;
                    return false;
                }

                try
                {
                    if (mask.HasValue)
                    {
                        ipCidr = new IpRange(ipaddr.GetAddressBytes(), mask.Value);
                    }
                    else
                    {
                        ipCidr = new IpRange(ipaddr.GetAddressBytes());
                    }
                    return true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    ipCidr = null;
                    return false;
                }
            }
            else
            {
                ipCidr = null;
                return false;
            }
        }

        public bool Overlap(IpRange other)
            => other == null ? throw new ArgumentNullException(nameof(other))
            : this.Comparer.Match(other.Comparable).Success
            || other.Comparer.Match(this.Comparable).Success;

        private static bool ValidateIPv4(string ip)
        {
            var count = ip.Split('.', StringSplitOptions.RemoveEmptyEntries).Length;
            return count == 4;
        }

        public override string ToString()
            => $"{new IPAddress(Address)}/{Mask}";

        public bool Equals(IpRange? other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Comparable.Equals(other.Comparable, StringComparison.Ordinal);
        }

        public override bool Equals(object? obj)
        {
            if (obj is IpRange other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
            => string.GetHashCode(this.Comparable, StringComparison.Ordinal);
    }
}
