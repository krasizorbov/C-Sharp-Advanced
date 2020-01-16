using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words;
            string[] text;
            string wordsList = string.Empty; ;
            string textList = string.Empty; ;

            var fileStream1 = new FileStream(@"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\03. Word Count\words.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream1, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    wordsList = wordsList + line; ;
                }
            }
            words = wordsList.Split().ToArray();

            var fileStream2 = new FileStream(@"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\03. Word Count\text.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream2, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    textList = textList + line;
                }
            }
            string[] delimiter = new string[] { ", ", "!", "?", "-", ".", " " };
            text = textList.Split(delimiter,StringSplitOptions.RemoveEmptyEntries).ToArray();

            string fileName = @"C:\Users\KZ\source\repos\3. C Sharp-Advanced\04. Streams, Files And Dictionaries Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\03. Word Count\Output.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file
                var myDic = new Dictionary<string, int>();
                using (StreamWriter fs = File.CreateText(fileName))
                {
                    int counter = 0;
                    // Add some text to file    
                    for (int i = 0; i < words.Length; i++)
                    {
                        for (int j = 0; j < text.Length; j++)
                        {
                            if (words[i].ToLower() == text[j].ToLower())
                            {
                                counter++;
                            }
                        }
                        myDic.Add(words[i], counter);
                        counter = 0;
                    }

                    foreach (var (word, count) in myDic.OrderByDescending(x => x.Value))
                    {
                        fs.WriteLine(word + " - " + count, 0);
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

