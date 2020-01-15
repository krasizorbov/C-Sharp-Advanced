using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
namespace GetSizeOfFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            string output = "report.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(output))
                {
                    File.Delete(output);
                }
                var myDic = new Dictionary<string, Dictionary<string, double>>();

                // Path to the source folder containing the files!
                string path = "TestFolder";

                // Get array of all file names.
                string[] fileNames = Directory.GetFiles(path, "*.*");

                // Calculate total bytes of every file in a loop.
                double b = 0;
                foreach (string name in fileNames)
                {
                    // Use FileInfo to get length of each file.
                    // This is the way to get the file name and extension from a directory!!!!!!!!!!
                    string nameExtension = Path.GetExtension(name);
                    string fileName = Path.GetFileName(name);

                    FileInfo info = new FileInfo(name);
                    b = info.Length / 1000000.00;

                    if (!myDic.ContainsKey(nameExtension))
                    {
                        myDic.Add(nameExtension, new Dictionary<string, double>());
                        myDic[nameExtension].Add(fileName, b);
                    }
                    else
                    {
                        if (!myDic[nameExtension].ContainsKey(fileName))
                        {
                            myDic[nameExtension].Add(fileName, b);
                        }
                    }
                }

                // Create a new file     
                using (StreamWriter fs = File.CreateText(output))
                {
                    // Add some text to file
                    foreach (var extension in myDic.OrderByDescending(x => x.Value.Count()))
                    {
                        fs.WriteLine(extension.Key);
                        foreach (var filename in extension.Value.OrderBy(x => x.Value))
                        {
                            fs.WriteLine($"--{filename.Key} - {filename.Value:F3}kb");
                        }
                    }   
                }

                //Open the stream and read it back.
                using (StreamReader sr = File.OpenText(output))
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
