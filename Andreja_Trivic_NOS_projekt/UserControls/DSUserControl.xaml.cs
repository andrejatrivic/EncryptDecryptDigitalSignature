using Andreja_Trivic_NOS_projekt.Services;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Andreja_Trivic_NOS_projekt.UserControls
{
    public partial class DSUserControl : UserControl
    {
        KeyService _keyService = new KeyService();
        FileService _fileService = new FileService();
        DSService _dsService = new DSService();
        HashService _hashService = new HashService();

        public static string digitalniPotpisFile = "digitalni_potpis.txt";
        public static string orginalnaDatotekaFile = "orginalna_datoteka.txt";

        public static string fileNameConst = "File name";
        
        public static string validSignature = "Potpis je valjan!";
        public static string invalidSignature = "Potpis nije valjan!";
        public static string invalidSignatureFormat = "Potpis nije u valjanom formatu";

        public DSUserControl()
        {
            InitializeComponent();
            btnAddSignature.IsEnabled = false;
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

            _dsService.ComputeHash(fileText);

            btnAddSignature.IsEnabled = true;
        }

        private void btnAddSignature_Click(object sender, RoutedEventArgs e)
        {
            var fileName = txtFileName.Text;
            var fileText = _fileService.ReadTextFromFile(fileName);

            _dsService.GenerateDigitalSignature(fileText);
            var signature = _fileService.ReadTextFromFile(digitalniPotpisFile);

            txtGeneratedSignature.Text = signature;
        }

        private void btnVerifySignature_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var signature = _fileService.ReadTextFromFile(digitalniPotpisFile);
                var signatureByte = Convert.FromBase64String(signature);
                var isValid = _dsService.VerifySignature(signatureByte);
                if (isValid)
                {
                    txtError.Text = "";
                    txtSignatureValid.Text = validSignature;
                }
                else
                {
                    txtSignatureValid.Text = "";
                    txtError.Text = invalidSignature;
                }
            }
            catch (FormatException ex)
            {
                txtError.Text = "";
                txtSignatureValid.Text = "";
                txtError.Text = invalidSignatureFormat;
            }
        }

        private void txtFileText_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            btnAddSignature.IsEnabled = true;
            var fileName = txtFileName.Text;
            var text = txtFileText.Text;

            btnGenerateHash.IsEnabled = true;
            _dsService.ComputeHash(text);

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

        private void txtGeneratedSignature_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var text = txtGeneratedSignature.Text;
            _fileService.WriteTextIntoFile(digitalniPotpisFile, text);
        }

        private void btnGenerateHash_Click(object sender, RoutedEventArgs e)
        {
            txtHash.Clear();

            var textToHash = txtFileText.Text;
            var hash = _hashService.GenerateHash(textToHash);

            txtHash.Text = hash;
        }
    }
}
