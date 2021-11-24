using System;
using System.Collections.Generic;
using System.Linq;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayChallenge();

            List<int> nums = new List<int>();
            PrintInfo(nums);
            nums.Add(4);
            nums.Add(4);
            nums.Add(4);
            nums.Add(4);
            nums.Add(4);//Count: 5, Capacity: 8
            nums.Add(4);
            nums.Add(4);
            nums.Add(4);
            nums.Add(4);//Count: 9, Capacity: 16
            nums.Add(4);
            PrintInfo(nums);
            //Count: # of items that have been ADDED
            //Capacity: length of the internal array
            for (int i = 0; i < nums.Count; i++)
            {
                Console.WriteLine(nums[i]);
            }

            ListChallenge();

            SplitChallenge();
        }

        private static void SplitChallenge()
        {
            string villains = "Joker,Riddler,Catwoman,Two-face,Bane";
            string[] badGuys = villains.Split(',');

            Console.WriteLine("----------BAD GUYS----------");
            List<string> baddies = badGuys.ToList();
            foreach (string badGuy in baddies)
            {
                Console.WriteLine(badGuy);
            }

            string gothamCharacters = "Joker,,,Riddler,Catwoman,,Two-face,Bane|Gordon||Barbara";
            string[] characters = gothamCharacters.Split(new char[] { ',', '|' },StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("----------GOTHAM CHARACTERS----------");
            for (int i = 0; i < characters.Length; i++)
            {
                Console.WriteLine(characters[i]);
            }
        }

        private static void PrintInfo(List<int> nums)
        {
            Console.WriteLine($"Count: {nums.Count}\tCapacity: {nums.Capacity}");
        }

        static void ListChallenge()
        {
            List<double> grades = new List<double>(10);//presize the internal
            Random rando = new Random();
            for (int i = 0; i < 10; i++)
            {
                grades.Add(rando.NextDouble() * 100);
            }

            List<double> pg2 = grades;//is this cloning? no. pg2 points to the same list.
            pg2 = grades.ToList();//clone the list

            PrintGrades(grades);//pass by value
            int numberDropped = DropFailing(grades);
            Console.WriteLine($"{numberDropped} grades were removed.");
            PrintGrades(grades);

            List<double> curved = CurveGrades(grades);
            PrintGrades(curved);
        }

        private static List<double> CurveGrades(List<double> grades)
        {
            List<double> curved = grades.ToList();
            for (int i = 0; i < curved.Count; i++)
            {
                curved[i] += 5;
                if (curved[i] > 100) curved[i] = 100;
            }
            return curved;
        }

        private static int DropFailing(List<double> grades)
        {
            int numberRemoved = 0;
            //for (int i = 0; i < grades.Count; i++)
            //{
            //    if (grades[i] < 59.5)
            //    {
            //        grades.RemoveAt(i);
            //        numberRemoved++;
            //        i--;
            //    }
            //}
            //OR, use a reverse for loop
            for (int i = grades.Count - 1; i >= 0; i--)
            {
                if (grades[i] < 59.5)
                {
                    grades.RemoveAt(i);
                    numberRemoved++;
                }
            }
            return numberRemoved;
        }

        private static void PrintGrades(List<double> grades)
        {
            Console.WriteLine("------------GRADES-------------");
            for (int i = 0; i < grades.Count; i++)
            {
                //if (grades[i] < 59.5) Console.ForegroundColor = ConsoleColor.Red;
                //else Console.ForegroundColor = ConsoleColor.Green;

                Console.ForegroundColor = (grades[i] < 59.5) ? ConsoleColor.Red :
                                          (grades[i] < 69.5) ? ConsoleColor.DarkYellow : 
                                          (grades[i] < 79.5) ? ConsoleColor.Yellow :
                                          (grades[i] < 89.5) ? ConsoleColor.DarkCyan : ConsoleColor.Green ;

                Console.WriteLine($"{grades[i],7:N2}");
            }
            Console.ResetColor();
        }

        static void ArrayChallenge()
        {
            int[] numbers = new int[10];//cons: allocate ALL the memory upfront
            Random randy = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = randy.Next();
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            //resizing is a con. manually write code to do it.
            int[] temp = new int[15];
            for (int i = 0; i < numbers.Length; i++)
            {
                temp[i] = numbers[i];
            }
            numbers = temp;

            List<int> numberList = new List<int>(numbers);//clone it
            numberList = numbers.ToList();
        }
    }
}
