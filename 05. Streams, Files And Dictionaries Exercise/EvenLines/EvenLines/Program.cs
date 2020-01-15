using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
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
            var outputLines = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                var replacedLine = ReplacedSymbols(lines[i]);
                var reversed = ReversedLine(replacedLine);
                outputLines.Add(reversed);
            }
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
                    for (int i = 0; i < outputLines.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            fs.WriteLine(outputLines[i], 0, outputLines[i].Length);
                        }
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

        private static string ReversedLine(string replacedLine)
        {
            return string.Join(" ", replacedLine.Split().Reverse());
        }

        private static string ReplacedSymbols(string v)
        {
            // { ".", ", ", "!", "?", "-" };
            return v.Replace("-", "@").Replace(".", "@").Replace(", ", "@").Replace("!", "@").Replace("?", "@");
            
        }
    }
}
