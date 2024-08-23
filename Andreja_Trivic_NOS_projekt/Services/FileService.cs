using Microsoft.Win32;
using System;
using System.IO;

namespace Andreja_Trivic_NOS_projekt.Services
{
    public class FileService
    {
        public static string orginalnaDatotekaFile = "orginalna_datoteka.txt"; 

        public string GetFilePath(string fileName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            var folderPath = Path.Combine(parentDirectory, "TextFiles");
            var filePath = Path.Combine(folderPath, fileName);
            return filePath;
        }

        public void WriteTextIntoFile(string fileName, string fileText)
        {
            var filePath = GetFilePath(fileName);
            File.WriteAllText(filePath, fileText);
        }

        public void WriteBytesIntoFile(string fileName, byte[] fileBytes)
        {
            var filePath = GetFilePath(fileName);
            var fileText = Convert.ToBase64String(fileBytes);
            File.WriteAllText(filePath, fileText);
        }

        public string ReadTextFromFile(string fileName) 
        {
            var file = GetFilePath(fileName);
            var fileText = File.ReadAllText(file);
            return fileText;
        }

        public string UploadFile()
        {
            var fileName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                fileName = openFileDialog.FileName;
                return fileName;
            }
            else return GetFilePath(orginalnaDatotekaFile);            
        }
    }
}
