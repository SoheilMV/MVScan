using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVScan
{
    public class IPRange
    {
        public static long AddrToLong(string address)
        {
            return BitConverter.ToInt32(IPAddress.Parse(address).GetAddressBytes().Reverse().ToArray(), 0);
        }

        public static string LongToAddr(long address)
        {
            return IPAddress.Parse(address.ToString()).ToString();
        }

        public static bool IsInRange(string startAddress, string endAddress, string address)
        {
            long ipStart = BitConverter.ToInt32(IPAddress.Parse(startAddress).GetAddressBytes().Reverse().ToArray(), 0);
            long ipEnd = BitConverter.ToInt32(IPAddress.Parse(endAddress).GetAddressBytes().Reverse().ToArray(), 0);
            long ip = BitConverter.ToInt32(IPAddress.Parse(address).GetAddressBytes().Reverse().ToArray(), 0);
            return ip >= ipStart && ip <= ipEnd;
        }

        public static bool IsInRange(long startAddress, long endAddress, long address)
        {
            return address >= startAddress && address <= endAddress;
        }

        public static string[] GetRange(string startAddress, string endAddress)
        {
            long start = AddrToLong(startAddress);
            long end = AddrToLong(endAddress);
            List<string> list = new List<string>();
            for (long i = start; i <= end; i++)
            {
                list.Add(LongToAddr(i));
            }
            return list.ToArray();
        }

        public static string[] GetRange(long startAddress, long endAddress)
        {
            List<string> list = new List<string>();
            for (long i = startAddress; i <= endAddress; i++)
            {
                list.Add(LongToAddr(i));
            }
            return list.ToArray();
        }
    }
}
