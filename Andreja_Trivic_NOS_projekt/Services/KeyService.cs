using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace Andreja_Trivic_NOS_projekt.Services
{  

    public class KeyService
    {
        FileService _fileService = new FileService();

        public static string tajniKljucFile = "tajni_kljuc.txt";
        public static string privatniKljucFile = "privatni_kljuc.txt";
        public static string javniKljucFile = "javni_kljuc.txt";

        public static string separationText = "*keyEndsIVStarts*";
        public static int AESKeySize = 256;

        public void GenerateKeyAndIV()
        {
            byte[] key;
            byte[] iv;

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = AESKeySize;
                aes.GenerateKey();
                aes.GenerateIV();

                key = aes.Key;
                iv = aes.IV;
            }

            var keyString = Convert.ToBase64String(key);
            var ivString = Convert.ToBase64String(iv);
            var secretKeyFileText = keyString + separationText + ivString;

            _fileService.WriteTextIntoFile(tajniKljucFile, secretKeyFileText);
        }

        public void GeneratePublicAndPrivateKey()
        {
            RSAParameters privateKeyParam;
            RSAParameters publicKeyParam;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                privateKeyParam = rsa.ExportParameters(true);
                publicKeyParam = rsa.ExportParameters(false);
            }

            var privateKey = ConvertRSAParameterToString(privateKeyParam);
            var publicKey = ConvertRSAParameterToString(publicKeyParam);

            _fileService.WriteTextIntoFile(privatniKljucFile, privateKey);
            _fileService.WriteTextIntoFile(javniKljucFile, publicKey);
        }

        public byte[] GetSecretKey()
        {
            var keyAndIV = _fileService.ReadTextFromFile(tajniKljucFile);
            var key = keyAndIV.Split(separationText)[0];
            return Convert.FromBase64String(key);
        }

        public byte[] GetIV()
        {
            var keyAndIV = _fileService.ReadTextFromFile(tajniKljucFile);
            var iv = keyAndIV.Split(separationText)[1];
            return Convert.FromBase64String(iv);
        }

        public RSAParameters GetPublicKey()
        {
            var publicKey = _fileService.ReadTextFromFile(javniKljucFile);

            var publicKeyParam = ConvertStringToRSAParameters(publicKey);

            return publicKeyParam;
        }

        public RSAParameters GetPrivateKey()
        {
            var privateKey = _fileService.ReadTextFromFile(privatniKljucFile);

            var privateKeyParam = ConvertStringToRSAParameters(privateKey); 

            return privateKeyParam;
        }

        public string ConvertRSAParameterToString(RSAParameters rSAParameter)
        {
            using(StringWriter stringWriter = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
                
                xmlSerializer.Serialize(stringWriter, rSAParameter);
                
                return stringWriter.ToString();
            }
        }

        public RSAParameters ConvertStringToRSAParameters(string rsaStringParameter)
        {
            using(StringReader stringReader = new StringReader(rsaStringParameter)) 
            {
                var xmlSerializer = new XmlSerializer(typeof(RSAParameters));

                var rsaParameter = (RSAParameters)xmlSerializer.Deserialize(stringReader);

                return rsaParameter;
            }       
        }
    }
}
