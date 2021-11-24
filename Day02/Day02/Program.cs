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
            int[] temp =numbers.ToArray();// new int[15];
            for (int i = 0; i < numbers.Length; i++)
            {
                temp[i] = numbers[i];
            }
            numbers = temp;
        }
    }
}
