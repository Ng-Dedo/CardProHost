using log4net;
using ServiceStack;
using ServiceStack.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CardProHost.Utils {
    public static class CardProCryptUtils {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CardProCryptUtils));
        private static readonly IAppSettings appSettings = new AppSettings();

        public static string RSACardProEncrypt(this string content, string key) {
            throw new NotImplementedException();
        }

        public static string RSACardProDecrypt(this string encryptedContent, string privateKey = null) {
            string content = null;
            try {
                privateKey = privateKey ??
                               LoadXmlStringFromFile(appSettings.GetString("PrivateKeyXml"));
                content = RsaUtils.Decrypt(encryptedContent, privateKey);
            }
            catch (Exception exception) {
                logger.Error("decrypt failed");
                logger.Error(exception);
            }
            return content;
        }

        public static string AESCardProDecrypt(this string encryptedContent, string secret)
        {
            try
            {
                byte[] salt = new byte[8];
                byte[] key = new byte[24];
                byte[] iv = new byte[8];

                byte[] saltData = Convert.FromBase64String(encryptedContent);
                Buffer.BlockCopy(saltData, 8, salt, 0, 8);
                byte[] data = new byte[saltData.Length - 16];
                Buffer.BlockCopy(saltData, 16, data, 0, saltData.Length - 16);

                Generate(secret.ToUtf8Bytes(), salt, out key, out iv);

                return Encoding.UTF8.GetString(AesUtils.Decrypt(key, iv, data));
            }
            catch (Exception exception)
            {
                logger.Error("decrypt failed");
                logger.Error(exception);
            }

            return null;
        }

        public static string AESCardProEncrypt(this string content, string secret)
        {
            try
            {
                byte[] salt = new byte[8];
                byte[] key = new byte[24];
                byte[] iv = new byte[16];

                new Random().NextBytes(salt);

                Generate(secret.ToUtf8Bytes(), salt, out key, out iv);
                var contentBytes = AesUtils.Encrypt(content.ToUtf8Bytes(), key, iv);
                byte[] saltData = Combine("Salted__".ToUtf8Bytes(), salt, contentBytes);

                return Convert.ToBase64String(saltData);
            }
            catch (Exception exception)
            {
                logger.Error("decrypt failed");
                logger.Error(exception);
            }

            return null;
        }

        public static string LoadXmlStringFromFile(string path) {
            return File.ReadAllText(path);
        }

        private static void Generate(byte[] data, byte[] salt, out byte[] key, out byte[] iv)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                key = new byte[24];
                iv = new byte[16];

                byte[] block = new byte[16];
                byte[] buffer = new byte[32];
                block = md5.ComputeHash(Combine(data, salt));
                Buffer.BlockCopy(block, 0, buffer, 0, 16);
                block = md5.ComputeHash(Combine(block, data, salt));
                Buffer.BlockCopy(block, 0, buffer, 16, 16);

                Buffer.BlockCopy(buffer, 0, key, 0, 24);
                Buffer.BlockCopy(buffer, 24, iv, 0, 8);
            }
            
        }

        private static byte[] Combine(params byte[][] arrays)
        {
            int offset = 0;
            byte[] buffer = new byte[arrays.Sum(p => p.Length)];
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, buffer, offset, array.Length);
                offset += array.Length;
            }
            return buffer;
        }
    }
}