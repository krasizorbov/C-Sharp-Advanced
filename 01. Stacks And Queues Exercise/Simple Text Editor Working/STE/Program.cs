using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string text = string.Empty;

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < number; i++)
            {
                string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(line[0]);

                switch (command)
                {
                    case 1:
                        string textToAdd = line[1];
                        text += textToAdd;
                        stack.Push(text);
                        break;
                    case 2:
                        int textToDelete = int.Parse(line[1]); ;
                        text = text.Substring(0, text.Length - textToDelete);
                        stack.Push(text);
                        break;
                    case 3:
                        int index = int.Parse(line[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        stack.Pop();
                        if (stack.Count > 0)
                        {
                            text = stack.Peek();
                        }
                        else
                        {
                            text = string.Empty;
                        }
                        break;
                }
            }
        }
    }
}