using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Oc6.Library.Net
{
    /// <summary>
    /// <para>Packs an IP range in CIDR notation for easy overlap matching</para>
    /// </summary>
    public class IpCidr
    {
        /// <summary>
        /// <para>The address bytes as found in <see cref="System.Net.IPAddress"/> </para>
        /// </summary>
        public byte[] Address { get; }
        public int Mask { get; }

        private static readonly char[] ValidChars = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ':', '/', };
        private string Comparable { get; }
        private Regex Comparer { get; }

        public IpCidr(byte[] bytes, int mask)
        {
            if (!(bytes.Length == 16 || bytes.Length == 4))
            {
                throw new ArgumentOutOfRangeException(nameof(bytes), ErrorMessages.InvalidAddressSize);
            }

            if (mask > bytes.Length * 8 || mask < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(mask), ErrorMessages.InvalidMask);
            }

            Address = bytes;
            Mask = mask;

            List<char> chars = new List<char>(Address.Length * 8);

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

        public IpCidr(byte[] bytes)
            : this(bytes, bytes.Length * 8)
        {

        }

        public static bool TryParse(string value, out IpCidr? ipCidr)
        {
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

        private static bool GetIpCidr(string ip, out IpCidr? ipCidr, int? mask = null)
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
                        ipCidr = new IpCidr(ipaddr.GetAddressBytes(), mask.Value);
                    }
                    else
                    {
                        ipCidr = new IpCidr(ipaddr.GetAddressBytes());
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

        private static bool ValidateIPv4(string ip)
        {
            var count = ip.Split('.', StringSplitOptions.RemoveEmptyEntries).Length;
            return count == 4;
        }

        public override string ToString()
        {
            return $"{string.Join('.', Address)}/{Mask}, Comparable: {Comparable}";
        }

        public bool Overlap(IpCidr other)
            => this.Comparer.Match(other.Comparable).Success
            || other.Comparer.Match(this.Comparable).Success;
    }
}
