using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines1;
            string[] lines2;
            var list1 = new List<string>();
            var list2 = new List<string>();

            var fileStream1 = new FileStream(@"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\04. Merge Files\FileOne.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream1, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list1.Add(line);
                }
            }
            lines1 = list1.ToArray();

            var fileStream2 = new FileStream(@"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\04. Merge Files\FileTwo.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream2, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list2.Add(line);
                }
            }
            lines2 = list2.ToArray();

            string fileName = @"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\04. Merge Files\Output.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (StreamWriter fs = File.CreateText(fileName))
                {
                    // Add some text to file
                    if (lines1.Length > lines2.Length)
                    {
                        for (int i = 0; i < lines1.Length; i++)
                        {
                            fs.WriteLine(lines1[i], 0, lines1[i].Length);
                            fs.WriteLine(lines2[i], 0, lines2[i].Length);
                        }
                    }
                    else if (lines1.Length < lines2.Length)
                    {
                        for (int i = 0; i < lines2.Length; i++)
                        {
                            fs.WriteLine(lines1[i], 0, lines1[i].Length);
                            fs.WriteLine(lines2[i], 0, lines2[i].Length);
                        }
                    }
                    else if (lines1.Length == lines2.Length)
                    {
                        for (int i = 0; i < lines2.Length; i++)
                        {
                            fs.WriteLine(lines1[i], 0, lines1[i].Length);
                            fs.WriteLine(lines2[i], 0, lines2[i].Length);
                        }
                    }

                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))
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
