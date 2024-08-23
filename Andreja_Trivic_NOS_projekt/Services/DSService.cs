using System.Security.Cryptography;
using System.Text;

namespace Andreja_Trivic_NOS_projekt.Services
{
    public class DSService
    {
        FileService _fileService = new FileService();
        KeyService _keyService = new KeyService();
        HashService _hashService = new HashService();   

        private static string digitalniPotpisFile = "digitalni_potpis.txt";

        byte[] hash;

        public byte[] ComputeHash(string textToHash)
        {
            using SHA256 sha256 = SHA256.Create();
            var textBytesToSign = Encoding.ASCII.GetBytes(textToHash);
            hash = sha256.ComputeHash(textBytesToSign);
            return hash;
        }

        public byte[] GenerateDigitalSignature(string textToSign)
        {
            var privateKey = _keyService.GetPrivateKey();
            hash = ComputeHash(textToSign);
            byte[] signature;

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
                rsaFormatter.SetHashAlgorithm(nameof(SHA256));

                signature = rsaFormatter.CreateSignature(hash);
            }
            _fileService.WriteBytesIntoFile(digitalniPotpisFile, signature);
            return signature;
        }

        public bool VerifySignature(byte[] signature)
        {
            var publicKey = _keyService.GetPublicKey();
            bool isValid;

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);
                RSAPKCS1SignatureDeformatter rsaDeformatter = new(rsa);
                rsaDeformatter.SetHashAlgorithm(nameof(SHA256));

                isValid = rsaDeformatter.VerifySignature(hash, signature);
            }

            return isValid;
        }
    }
}
