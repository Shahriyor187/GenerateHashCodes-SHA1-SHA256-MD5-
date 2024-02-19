using System.Security.Cryptography;
using System.Text;

namespace MvcWebApp.Models
{
    public class HashGenerator
    {
        public static string GetHash(string input, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = algorithm.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                return GetHash(input, md5);
            }
        }

        public static string GetSHA1Hash(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return GetHash(input, sha1);
            }
        }

        public static string GetSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return GetHash(input, sha256);
            }
        }
    }
}