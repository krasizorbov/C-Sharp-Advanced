using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines;

            var list = new List<string>();

            var fileStream1 = new FileStream(@"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\05. Slice File\sliceMe.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream1, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();


            string fileName1 = @"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\05. Slice File\Part-1.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName1))
                {
                    File.Delete(fileName1);
                }

                // Create a new file     
                using (StreamWriter fs = File.CreateText(fileName1))
                {
                    // Add some text to file
                    for (int i = 0; i < lines.Length / 4; i++)
                    {
                        fs.WriteLine(lines[i], 0, lines[i].Length);
                    }
                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName1))
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

            string fileName2 = @"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\05. Slice File\Part-2.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName2))
                {
                    File.Delete(fileName2);
                }

                // Create a new file     
                using (StreamWriter fs = File.CreateText(fileName2))
                {
                    // Add some text to file
                    for (int i = lines.Length / 4; i < lines.Length / 4 * 2; i++)
                    {
                        fs.WriteLine(lines[i], 0, lines[i].Length);
                    }
                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName2))
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

            string fileName3 = @"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\05. Slice File\Part-3.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName3))
                {
                    File.Delete(fileName3);
                }

                // Create a new file     
                using (StreamWriter fs = File.CreateText(fileName3))
                {
                    // Add some text to file            
                    for (int i = lines.Length / 4 * 2; i < lines.Length / 4 * 3; i++)
                    {
                        fs.WriteLine(lines[i], 0, lines[i].Length);
                    }
                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName3))
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

            string fileName4 = @"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\05. Slice File\Part-4.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName4))
                {
                    File.Delete(fileName4);
                }

                // Create a new file     
                using (StreamWriter fs = File.CreateText(fileName4))
                {
                    // Add some text to file
                    for (int i = lines.Length / 4 * 3; i < lines.Length; i++)
                    {
                        fs.WriteLine(lines[i], 0, lines[i].Length);
                    }
                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName4))
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
