using ServiceStack;
using ServiceStack.Text;
using System;
using System.IO;
using System.Security.Cryptography;

namespace CardProHost.Utils {
    public static class AesUtils {
        public const int KeySize = 256;
        public const int KeySizeBytes = 256 / 8;
        public const int BlockSize = 128;
        public const int BlockSizeBytes = 128 / 8;

        public static SymmetricAlgorithm CreateSymmetricAlgorithm() {
            return new AesCryptoServiceProvider {
                KeySize = KeySize,
                BlockSize = BlockSize,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };
        }

        public static byte[] CreateKey() {
            using (var aes = CreateSymmetricAlgorithm()) {
                return aes.Key;
            }
        }

        public static byte[] CreateIv() {
            using (var aes = CreateSymmetricAlgorithm()) {
                return aes.IV;
            }
        }

        public static void CreateKeyAndIv(out byte[] cryptKey, out byte[] iv) {
            using (var aes = CreateSymmetricAlgorithm()) {
                cryptKey = aes.Key;
                iv = aes.IV;
            }
        }

        public static void CreateCryptAuthKeysAndIv(out byte[] cryptKey, out byte[] authKey, out byte[] iv) {
            using (var aes = CreateSymmetricAlgorithm()) {
                cryptKey = aes.Key;
                iv = aes.IV;
            }
            using (var aes = CreateSymmetricAlgorithm()) {
                authKey = aes.Key;
            }
        }

        public static string Encrypt(string text, byte[] cryptKey, byte[] iv) {
            var encBytes = Encrypt(text.ToUtf8Bytes(), cryptKey, iv);
            return Convert.ToBase64String(encBytes);
        }

        public static byte[] Encrypt(byte[] bytesToEncrypt, byte[] cryptKey, byte[] iv) {
            using (var aes = CreateSymmetricAlgorithm())
            using (var encrypter = aes.CreateEncryptor(cryptKey, iv))
            using (var cipherStream = MemoryStreamFactory.GetStream()) {
                using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                using (var binaryWriter = new BinaryWriter(cryptoStream)) {
                    binaryWriter.Write(bytesToEncrypt);
                }
                return cipherStream.ToArray();
            }
        }

        public static string Decrypt(string encryptedBase64, byte[] cryptKey, byte[] iv) {
            var bytes = Decrypt(Convert.FromBase64String(encryptedBase64), cryptKey, iv);
            return bytes.FromUtf8Bytes();
        }

        public static byte[] Decrypt(byte[] encryptedBytes, byte[] cryptKey, byte[] iv) {
            using (var aes = CreateSymmetricAlgorithm())
            using (var decryptor = aes.CreateDecryptor(cryptKey, iv))
            using (var ms = MemoryStreamFactory.GetStream(encryptedBytes))
            using (var cryptStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {
                return cryptStream.ReadFully();
            }
        }
    }
}