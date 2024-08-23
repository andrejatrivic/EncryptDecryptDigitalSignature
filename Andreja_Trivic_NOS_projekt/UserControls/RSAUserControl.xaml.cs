using Andreja_Trivic_NOS_projekt.Services;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Andreja_Trivic_NOS_projekt.UserControls
{
    public partial class RSAUserControl : UserControl
    {
        KeyService _keyService = new KeyService();
        FileService _fileService = new FileService();
        RSAService _rsaService = new RSAService();
        HashService _hashService = new HashService();

        public static string RSAKriptiraniFile = "asimetricni_kriptirani_tekst.txt";
        public static string sazetakFile = "sazetak.txt";
        public static string orginalnaDatotekaFile = "orginalna_datoteka.txt";

        public static string errorDecryptedText = "Tekst je dekriptiran.";
        public static string errorOnlyOnce = "Tekst se može kriptirati samo jednom.";
        public static string fileNameConst = "File name";
        

        public RSAUserControl()
        {
            InitializeComponent();
            btnGenerateHash.IsEnabled = false;
        }

        private void btnGeneratePublicAndPrivateKey_Click(object sender, RoutedEventArgs e)
        {
            _keyService.GeneratePublicAndPrivateKey();
        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            var fileName = _fileService.UploadFile();

            var fileText = _fileService.ReadTextFromFile(fileName);

            btnGenerateHash.IsEnabled = true;

            txtFileText.Text = fileText;
            txtFileName.Text = Path.GetFileName(fileName);
        }

        private void btnEncryptRSA_Click(object sender, RoutedEventArgs e)
        {
            var textToEncrypt = txtFileText.Text;
            txtErrorMessage.Text = "";

            try
            {
                var encryptedText = _rsaService.Encrypt(textToEncrypt);

                txtFileText.Text = encryptedText;
            }
            catch(Exception ex)
            {
                txtErrorMessage.Text = errorOnlyOnce;
            }                      
        }

        private void btnDecryptRSA_Click(object sender, RoutedEventArgs e)
        {
            var textToDecrypt = _fileService.ReadTextFromFile(RSAKriptiraniFile);
            txtErrorMessage.Text = "";

            try
            {
                var decryptedText = _rsaService.Decrypt(textToDecrypt);

                txtFileText.Text = decryptedText;
            }
            catch(FormatException ex)
            {
                txtErrorMessage.Text = errorDecryptedText;
            }
        }

        private void btnGenerateHash_Click(object sender, RoutedEventArgs e)
        {
            txtHash.Clear();

            var textToHash = txtFileText.Text;

            var hash = _hashService.GenerateHash(textToHash);

            txtHash.Text = hash;
        }

        private void txtFileText_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var fileName = txtFileName.Text;
            var text = txtFileText.Text;

            btnGenerateHash.IsEnabled = true;
            if (fileName == fileNameConst)
            {
                txtFileName.Text = orginalnaDatotekaFile;
                _fileService.WriteTextIntoFile(orginalnaDatotekaFile, text);
            }
            else
            {
                _fileService.WriteTextIntoFile(fileName, text);
            }
        }
    }
}
