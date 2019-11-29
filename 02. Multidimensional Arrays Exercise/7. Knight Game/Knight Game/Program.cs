using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            char[,] game = new char[num, num];

            StringBuilder sb = new StringBuilder();

            for (int m = 0; m < num; m++)
            {
                string line = Console.ReadLine().TrimEnd();

                foreach (var l in line)
                {
                    sb.Append(l);
                }

                for (int n = 0; n < sb.Length; n++)
                {
                    game[m, n] = sb[n];
                }
                sb.Clear();
            }

            int counter = 0;
            int knightsCounter = 0;
            int minValue = 0;
            int maxR = 0;
            int maxC = 0;

            while (true)
            {
                for (int r = 0; r < num; r++)
                {
                    for (int c = 0; c < num; c++)
                    {
                        if (game[r, c] == 'K')
                        {
                            if (r - 2 >= 0 && c - 1 >= 0)
                            {
                                if (game[r - 2, c - 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (r - 2 >= 0 && c + 1 < num)
                            {
                                if (game[r - 2, c + 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (r - 1 >= 0 && c - 2 >= 0)
                            {
                                if (game[r - 1, c - 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (r + 1 < num && c - 2 >= 0)
                            {
                                if (game[r + 1, c - 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (r + 2 < num && c - 1 >= 0)
                            {
                                if (game[r + 2, c - 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (r + 2 < num && c + 1 < num)
                            {
                                if (game[r + 2, c + 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (r - 1 >= 0 && c + 2 < num)
                            {
                                if (game[r - 1, c + 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (r + 1 < num && c + 2 < num)
                            {
                                if (game[r + 1, c + 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (counter > minValue)
                            {
                                minValue = counter;
                                maxR = r;
                                maxC = c;
                            }
                            counter = 0;
                        }

                    }//for ends here
                }//for ends here

                if (minValue > 0)
                {
                    knightsCounter++;

                    for (int r = 0; r < num; r++)
                    {
                        for (int c = 0; c < num; c++)
                        {
                            game[maxR, maxC] = '0';
                        }
                    }

                    minValue = 0;
                }
                else if(minValue == 0)
                {
                    break;
                }   
            }

            Console.WriteLine(knightsCounter);
        }
    }
}
