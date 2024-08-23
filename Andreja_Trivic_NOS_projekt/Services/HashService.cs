using System.Security.Cryptography;
using System.Text;

namespace Andreja_Trivic_NOS_projekt.Services
{
    public class HashService
    {
        FileService _fileSerivce = new FileService();        

        public static string sazetakFilePath =  "sazetak.txt";
        
        public string GenerateHash(string textToHash)
        {
            StringBuilder builder = new StringBuilder();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(textToHash));
                
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
            }
            var hashString = builder.ToString();
            _fileSerivce.WriteTextIntoFile(sazetakFilePath, hashString);
            return hashString;
        }
    }
}
