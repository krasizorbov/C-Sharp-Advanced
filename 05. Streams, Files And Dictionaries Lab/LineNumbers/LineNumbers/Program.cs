using System;
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
            var fileStream = new FileStream(@"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\02. Line Numbers\Input.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();

            string fileName = @"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\02. Line Numbers\Output.txt";

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
                    int index = 0;
                    // Add some text to file    
                    for (int i = 0; i < lines.Length; i++)
                    {
                        index++;
                        fs.WriteLine(index.ToString() + " " + lines[i], 0, lines[i].Length);
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
