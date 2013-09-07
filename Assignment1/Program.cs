using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        private const String defaultAns = "no";
        static void Main(string[] args)
        {
            String ans = defaultAns;
            do
            {
                int index = 1;
                powerTo implement = new powerTo();
                int a, b;
                int result;
                implement.getNumber(out a, ref index);
                implement.getNumber(out b, ref index);
                int[] arr = new int[b + 1];

                for (int i = 1; i <= b; i++)
                {
                    implement.getResult(a, i, out result);
                    arr[i] = result;
                }
                implement.showResult(a, b, arr);
                while (true)
                {
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Continue (y/n)");
                    Console.ResetColor();
                   
                    try
                    {
                        if ((ans = Console.ReadLine()) == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new System.ArgumentException("Empty String Detected");

                        }
                        break;
                    }
                    catch (System.ArgumentException ex)// took e variable out
                    {
                        
                        Console.WriteLine(ex.Message + "\nPlease re-Enter");
                        Console.ResetColor();

                    }

                }

            } while (ans[0] == 'y');
        }
    }

    class powerTo
    {
        public void getNumber(out int temp, ref int index)
        {
            while (true)
            {
                try
                {
                    if (index == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Please Enter Base Number and Press Enter:");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Please Enter Power:");
                        Console.ResetColor();
                    }
                    temp = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Invalid Input");
                    Console.ResetColor();
                }
                catch (System.OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Entered Number was more than memory can handle");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unknown Error " + e.Message);
                }
            }
            index *= -1;
        }

        public void getResult(int a, int b, out int result)
        {
            result = Convert.ToInt32(Math.Pow(a, b));
        }
        public void showResult(int a, int b, int[] arr)
        {
            float zero = 0;
            float positive = 1 / zero;
            float negative = -1 / zero;

            for (int i = 1; i <= b; i++)
            {
                if (arr[i] == positive || arr[i] == negative)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Result was more than memory can handle\nPlease Try Lower Number");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(a + " ^ " + i + " = " + arr[i]);
                    Console.ResetColor();
                }
            }
        }
    }
}