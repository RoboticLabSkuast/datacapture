
using System.Security.Cryptography;
using System.Text;


namespace datacapture.services
{
   public class Encrption
    {
        public  string Encrypt(string plainText, string key)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // AES-256 key
            aes.IV = new byte[16]; // Zero IV for simplicity — use a random IV for production!

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using var ms = new MemoryStream();
            using var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using (var writer = new StreamWriter(cryptoStream))
            {
                writer.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public  string Decrypt(string cipherText, string key)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // AES-256 key
            aes.IV = new byte[16]; // Must match the IV used in encryption

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            var buffer = Convert.FromBase64String(cipherText);

            using var ms = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}
