using log4net;
using ServiceStack;
using ServiceStack.Configuration;
using System;
using System.IO;

namespace CardProHost.Utils {
    public static class CardProCryptUtils {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CardProCryptUtils));
        private static readonly IAppSettings appSettings = new AppSettings();

        public static string Encrypt(this string content, string key) {
            var encryptedContent = string.Empty;
            try {
                var iv = AesUtils.CreateIv();
                encryptedContent = AesUtils.Encrypt(content, key.ToUtf8Bytes(), iv);
            } catch(Exception exception) {
                logger.Error("encrypt failed");
                logger.Error(exception);
            } 
            return encryptedContent;
        }

        public static string Decrypt(this string encryptedContent, string privateKey = null) {
            var content = string.Empty;
            try {
                var iv = AesUtils.CreateIv();
                privateKey = privateKey ??
                               LoadXmlStringFromFile(appSettings.GetString("PrivateKeyXml"));
                content = AesUtils.Decrypt(encryptedContent, privateKey.ToUtf8Bytes(), iv);
            }
            catch (Exception exception) {
                logger.Error("decrypt failed");
                logger.Error(exception);
            }
            
            return content;
        }

        public static string LoadXmlStringFromFile(string path) {
            return File.ReadAllText(path);
        }
    }
}