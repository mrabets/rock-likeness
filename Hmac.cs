using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockPaper
{
    class Hmac
    {
        public static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        public static string GetRandom128bitKey()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] random = new byte[16];
            rng.GetBytes(random);
            return HashEncode(random);
        }

        public static string GetHash(string str, string key)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);
            using (var hmac = new HMACSHA256(bkey))
            {
                byte[] bstr = Encoding.Default.GetBytes(str);
                var bhash = hmac.ComputeHash(bstr);
                return HashEncode(bhash);
            }
        }
    }
}
