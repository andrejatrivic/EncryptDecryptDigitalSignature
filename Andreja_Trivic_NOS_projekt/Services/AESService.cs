using Andreja_Trivic_NOS_projekt.UserControls;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Andreja_Trivic_NOS_projekt.Services
{
    public class AESService
    {
        KeyService _keyService = new KeyService();
        FileService _fileService = new FileService();

        public static string AESKriptiraniFile = "simetricni_kriptirani_tekst.txt";
        public static string AESDekriptiraniFile = "simetricni_dekriptirani_tekst.txt";

        public string Encrypt(string textToEncrypt)
        {
            var key = _keyService.GetSecretKey();
            var iv = _keyService.GetIV();

            using(Aes aes = Aes.Create())
            {
                var encryptor = aes.CreateEncryptor(key, iv);
                byte[] encryptedTextBytes;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using(CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using(StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(textToEncrypt);
                        }
                        encryptedTextBytes = memoryStream.ToArray();
                    }
                }
                _fileService.WriteBytesIntoFile(AESKriptiraniFile, encryptedTextBytes);

                var encryptedText = Convert.ToBase64String(encryptedTextBytes);
                return encryptedText;
            } 
        }

        public string Decrypt(string textToDecrypt)
        {
            var key = _keyService.GetSecretKey();
            var iv = _keyService.GetIV();
            var decryptedText = "";

            var cipher = Convert.FromBase64String(textToDecrypt);

            using (Aes aes = Aes.Create())
            {
                var decryptor = aes.CreateDecryptor(key, iv);

                using (MemoryStream memoryStream = new MemoryStream(cipher))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            decryptedText = streamReader.ReadToEnd();
                        }
                    }
                }
                _fileService.WriteTextIntoFile(AESKriptiraniFile, decryptedText);
                _fileService.WriteTextIntoFile(AESDekriptiraniFile, decryptedText);

                return decryptedText;
            }
        }
    }
}
