using System;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 5;
            JumpToMethod(number);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            number = 0;
            Console.WriteLine("---------Recursive loop---------");
            Recurse(number);
        }

        private static void Recurse(int number)
        {
            //an exit condition! ("Do you have your exit buddy?")
            if (number < 10)
            {
                Console.WriteLine(number);
                Recurse(number + 1);
            }
            Console.WriteLine(number);
        }//returns!

        private static void JumpToMethod(int num)
        {
            Console.WriteLine($"Number: {num}");
        }
    }
}
