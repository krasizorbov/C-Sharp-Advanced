using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines;
            var list = new List<string>();
            string inputPath = "text.txt";
            var fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();

            string outputPath = "output.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }

                // Create a new file.     
                using (StreamWriter fs = File.CreateText(outputPath))
                {
                    // Add some text to file.    
                    for (int i = 0; i < lines.Length; i++)
                    {
                        int stringLength = lines[i].ToCharArray().Count(char.IsLetterOrDigit);
                        int punctuationLength = lines[i].ToCharArray().Count(char.IsPunctuation);

                        fs.WriteLine("Line" + " " + (i + 1) + ":" + " " + lines[i] + " " + "(" + stringLength + ")" + "(" + punctuationLength + ")", 0, lines[i].Length);
                    }
                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(outputPath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
