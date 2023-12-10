using System.Net;

namespace MVScan
{
    internal class IPRange
    {
        //https://stackoverflow.com/questions/17875728/conversion-ipv6-to-long-and-long-to-ipv6
        public static long AddrToLong(string address)
        {
            //return (long)BitConverter.ToUInt32(IPAddress.Parse(address).GetAddressBytes().Reverse().ToArray(), 0);

            IPAddress? ip;
            if (IPAddress.TryParse(address, out ip))
            {
                byte[] bytes = ip.GetAddressBytes();
                return ((bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]) & 0x0FFFFFFFF);
            }
            else
                return 0;
        }

        public static string LongToAddr(long address)
        {
            return IPAddress.Parse(address.ToString()).ToString();
        }

        public static bool IsInRange(string startAddress, string endAddress, string address)
        {
            long ipStart = AddrToLong(startAddress);
            long ipEnd = AddrToLong(endAddress);
            long ip = AddrToLong(address);
            return ip >= ipStart && ip <= ipEnd;
        }

        public static bool IsInRange(long startAddress, long endAddress, long address)
        {
            return address >= startAddress && address <= endAddress;
        }

        public static bool IsInRange(string startAddress, string endAddress, long address)
        {
            long ipStart = AddrToLong(startAddress);
            long ipEnd = AddrToLong(endAddress);
            return address >= ipStart && address <= ipEnd;
        }

        public static bool IsValid(long startAddress, long endAddress)
        {
            return startAddress < endAddress;
        }

        public static bool IsValid(string startAddress, string endAddress)
        {
            long ipStart = AddrToLong(startAddress);
            long ipEnd = AddrToLong(endAddress);
            return IsValid(ipStart, ipEnd);
        }

        public static string[] GetRange(string startAddress, string endAddress)
        {
            List<string> list = new List<string>();

            long start = AddrToLong(startAddress);
            long end = AddrToLong(endAddress);

            if (!IsValid(start, end))
                return list.ToArray();

            for (long i = start; i <= end; i++)
            {
                list.Add(LongToAddr(i));
            }

            return list.ToArray();
        }

        public static string[] GetRange(long startAddress, long endAddress)
        {
            List<string> list = new List<string>();

            if (!IsValid(startAddress, endAddress))
                return list.ToArray();

            for (long i = startAddress; i <= endAddress; i++)
            {
                list.Add(LongToAddr(i));
            }

            return list.ToArray();
        }
    }
}
