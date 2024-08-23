using System;
using System.Security.Cryptography;
using System.Text;

namespace Andreja_Trivic_NOS_projekt.Services
{
    public class RSAService
    {
        public static string RSAKriptiraniFile = "asimetricni_kriptirani_tekst.txt";
        public static string RSADekriptiraniFile = "asimetricni_dekriptirani_tekst.txt";

        KeyService _keyService = new KeyService();
        FileService _fileService = new FileService();

        public string Encrypt(string textToEncrypt)
        {
            byte[] encryptedTextBytes;
            var textBytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);

            var publicKey = _keyService.GetPublicKey();

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);

                encryptedTextBytes = rsa.Encrypt(textBytesToEncrypt, false);
               
            }
            _fileService.WriteBytesIntoFile(RSAKriptiraniFile, encryptedTextBytes);
            
            var encryptedText = Convert.ToBase64String(encryptedTextBytes);
            return encryptedText;
        }

        public string Decrypt(string textToDecrypt)
        {
            byte[] decryptedTextBytes;
            var textBytesToDecrypt = Convert.FromBase64String(textToDecrypt); 

            var privateKey = _keyService.GetPrivateKey();

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);

                decryptedTextBytes = rsa.Decrypt(textBytesToDecrypt, false);
            }
            var decryptedText = Encoding.UTF8.GetString(decryptedTextBytes);

            _fileService.WriteTextIntoFile(RSADekriptiraniFile, decryptedText);

            return decryptedText;
        }
    }
}
