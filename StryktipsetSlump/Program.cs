using System;
using System.Collections.Generic;
using System.Threading;

namespace StryktipsetSlump
{
    class Program
    {
        static Random random = new Random();
        static List<int> halfs = new List<int>();
        static List<int> wholes = new List<int>();
        static List<string> singles = new List<string>();

        static void Main(string[] args)
        {
            int numberOfHalfs = 6;
            int numberOfWholes = 3;
            bool isRunning = true;

            while (isRunning)
            {
                try
                {
                    do
                    {
                        Console.Clear();
                        Console.Write("\n\tVälkommen till Stryktipsgeneratorn!\n\n\tHur många halvgarderingar vill du ha (max 13): ");
                        numberOfHalfs = int.Parse(Console.ReadLine());
                    } while (numberOfHalfs > 13 && numberOfHalfs < 0);
                    do
                    {
                        Console.Clear();
                        Console.Write($"\n\tHur många helgarderingar vill du ha (max {13 - numberOfHalfs}): ");
                        numberOfWholes = int.Parse(Console.ReadLine());
                    } while (numberOfWholes > (13 - numberOfHalfs) && numberOfWholes < 0);
                    isRunning = false;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("\n\tOGILTIG INMATNING!");
                }
            }
            Console.Clear();
            Console.Write("\n\tGenererar stryktipsrad.");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Console.Clear();

            string sign = "";
            Console.WriteLine("\n\t\tSTRYKTIPSET\n");
            for (int i = 0; i < 13; i++)
            {
                int number = random.Next(1, 3 + 1);
                switch (number)
                {
                    case 1:
                        sign = "1";
                        break;
                    case 2:
                        sign = "X";
                        break;
                    case 3:
                        sign = "2";
                        break;
                    default:
                        break;
                }
                singles.Add(sign);
            }
            for (int i = 0; i < numberOfWholes; i++)
            {
                int whole = random.Next(1, 13 + 1);
                if (wholes.Contains(whole))
                {
                    i -= 1;
                }
                else
                {
                    wholes.Add(whole);
                }
            }
            for (int i = 0; i < numberOfHalfs; i++)
            {
                int half = random.Next(1, 13 + 1);
                if (halfs.Contains(half) || wholes.Contains(half))
                {
                    i -= 1;
                }
                else
                {
                    halfs.Add(half);
                }
            }
            Console.WriteLine();
            string signTwo = "";
            for (int i = 1; i < 13 + 1; i++)
            {
                Console.Write("\t");
                if (halfs.Contains(i))
                {
                    do
                    {
                        int number = random.Next(1, 3 + 1);
                        switch (number)
                        {
                            case 1:
                                signTwo = "1";
                                break;
                            case 2:
                                signTwo = "X";
                                break;
                            case 3:
                                signTwo = "2";
                                break;
                            default:
                                break;
                        }

                    } while (singles[i - 1] == signTwo);
                    if (singles[i - 1] == "1" && signTwo == "X")
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{singles[i - 1]} {signTwo}  ");
                        Console.ResetColor();
                    }
                    else if (singles[i - 1] == "1" && signTwo == "2")
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{singles[i - 1]}   {signTwo}");
                        Console.ResetColor();
                    }
                    else if (singles[i - 1] == "X" && signTwo == "1")
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{signTwo} {singles[i - 1]}  ");
                        Console.ResetColor();
                    }
                    else if (singles[i - 1] == "X" && signTwo == "2")
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"  {singles[i - 1]} {signTwo}");
                        Console.ResetColor();
                    }
                    else if (singles[i - 1] == "2" && signTwo == "1")
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{signTwo}   {singles[i - 1]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"  {signTwo} {singles[i - 1]}");
                        Console.ResetColor();
                    }
                }
                else if (wholes.Contains(i))
                {
                    Console.Write($"Match {i}:\t");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("1 X 2");
                    Console.ResetColor();
                }
                else
                {
                    if (singles[i - 1] == "1")
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{singles[i - 1]}    ");
                        Console.ResetColor();
                    }
                    else if (singles[i - 1] == "X")
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"  {singles[i - 1]}  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"Match {i}:\t");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"    {singles[i - 1]}");
                        Console.ResetColor();
                    }
                }
            }
            double value1 = Math.Pow(2, numberOfHalfs);
            double value2 = Math.Pow(3, numberOfWholes);
            double result = value1 * value2;
            Console.Write("\n\t");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"SPIK: {13 - numberOfWholes - numberOfHalfs} ");
            Console.ResetColor();
            Console.Write("\n\t");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"HALV: {numberOfHalfs} ");
            Console.ResetColor();
            Console.Write("\n\t");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"HEL:  {numberOfWholes} ");
            Console.ResetColor();
            Console.WriteLine($"\n\tTotal kostnad för denna rad: {result}kr");
            Console.ReadLine();
        }
    }
}
