using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
     
            var files = "copyMe.png";
            string outputPath = "Output";
            var fileName = @"Input\copyMe.zip";

            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (ZipArchive zip = ZipFile.Open(fileName, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(files, Path.GetFileName(files));
                
            }

            ZipFile.ExtractToDirectory(fileName, outputPath);
        }
    }
}
