using System;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace TXC.Common.Security
{
    public static class Hash
    {

        public static string ComputeCheckSumWithKey(string source, string key, int encoding = 0)
        {
            string toHash = $"{source}={key}";
            byte[] byteSource = default;

            switch (encoding)
            {
                case 1:
                    byteSource = Encoding.UTF8.GetBytes(toHash);
                    break;
                case 2:
                    byteSource = Encoding.GetEncoding("Big5").GetBytes(toHash);
                    break;
                case 0:
                default:
                    byteSource = Encoding.ASCII.GetBytes(toHash);
                    break;
            }

            return ComputeSha256Hash(byteSource);
        }

        public static string ComputeSha256Hash(string source)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                return Convert.ToHexString(bytes);
            }
        }

        public static string ComputeSha256Hash(byte[] source)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(source);
                return Convert.ToHexString(bytes);
            }
        }

        public static int GetPartitionNumber(string source, int totalPartition = 1000)
        {
            //15000, the max partition sql server can support
            if (totalPartition > 15000 || totalPartition < 2)
                throw new ArgumentException("Invalid total partition number, the number must beween 2 and 15000");

            if (string.IsNullOrEmpty(source))
                throw new ArgumentException("Invalid source, the source cannot be null or empty");

            Crc32 crc32 = new Crc32();
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            crc32.AddData(bytes);
            uint crcvalue = crc32.Crc32Value;
            return (int)(crcvalue % totalPartition) + 1;
        }
    }
}
