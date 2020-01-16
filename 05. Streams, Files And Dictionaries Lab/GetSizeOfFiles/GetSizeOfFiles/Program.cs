using System;
using System.IO;

namespace GetSizeOfFiles
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string fileName1 = @"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\06. Folder Size\Output.txt";

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
                    fs.WriteLine(GetDirectorySize(@"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\06. Folder Size\TestFolder"));
                }

                //Open the stream and read it back.
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
        }

        static double GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            double b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b / 1000000;
        }
    }
}
