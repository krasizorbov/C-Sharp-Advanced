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
            string[] text;
            var wordsList = new List<string>();
            string textList = string.Empty;
            string wordsPath = "words.txt";
            var fileStream1 = new FileStream(wordsPath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream1, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    wordsList.Add(line);
                }
            }
            string textPath = "text.txt";
            var fileStream2 = new FileStream(textPath, FileMode.Open, FileAccess.Read);
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

            string actualResult = "actualResult.txt";
            string expectedResult = "expectedResult.txt";
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(actualResult) && File.Exists(expectedResult))
                {
                    File.Delete(actualResult);
                    File.Delete(expectedResult);
                }

                // Create a new file
                var myDic = new Dictionary<string, int>();
                using (StreamWriter fs = File.CreateText(actualResult))
                {
                    int counter = 0;
                    // Add some text to file    
                    for (int i = 0; i < wordsList.Count; i++)
                    {
                        for (int j = 0; j < text.Length; j++)
                        {
                            if (wordsList[i].ToLower() == text[j].ToLower())
                            {
                                counter++;
                            }
                        }
                        myDic.Add(wordsList[i], counter);
                        counter = 0;
                    }

                    foreach (var (word, count) in myDic)
                    {
                        fs.WriteLine(word + " - " + count, 0);
                    }
                    
                }

                using (StreamWriter fs = File.CreateText(expectedResult))
                {
                    // Add some text to file    
                    foreach (var (word, count) in myDic.OrderByDescending(x => x.Value))
                    {
                        fs.WriteLine(word + " - " + count, 0);
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

