using System.Security.Cryptography;
using System.Text;

namespace LabOfClouds.Library.Security
{
    public static class Criptography
    {
        public static string Encrypt(string stringToEncrypt)
        {
            var sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(stringToEncrypt));

                foreach (var b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}