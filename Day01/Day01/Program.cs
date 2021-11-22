using System;
using System.Collections.Generic;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Gotham!");
            int num = 5;
            string best = "Batman";

            var sum = Add(2, 5);

            PrintMessage();
            string myMessage = GetMessage();
            PrintMessage(myMessage);

            int result = Factor(num, 3);
            Factor2(ref result, 2);//result has a new name: number
            Factor2(ref num, 5);//num has a new name: number

            TimeStamp(ref myMessage);
            PrintMessage(myMessage);

            int grade = 55;
            int curve = 5;
            int newGrade;//do NOT need to initialize
            Curve(grade, curve, out newGrade);//pass by reference using out
            Console.WriteLine($"Old Grade: {grade} curved by {curve} to be {newGrade}.");

            MyFavoriteNumber(out int myFave);
            Console.WriteLine($"My favorite: {myFave}");

            Console.ReadKey();
        }

        static void MyFavoriteNumber(out int myNumber)
        {
            Console.Write("What is your favorite number? ");
            string numberStr = Console.ReadLine();

            //int.Parse. can throw an exception
            // use a try-catch
            //int.TryParse
            //try
            //{
            //    myNumber = int.Parse(numberStr);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"That is not a number.{ex.Message}");
            //}

            bool success = int.TryParse(numberStr, out myNumber);
            if(!success) //if(success == false)
            {
                Console.WriteLine("That is not a number.");
            }

            string newMsg = PostFix("Detective Comics", 5);
        }


        static string PostFix(string msg, int num = 1)
        {
            return $"{msg} #{num}";
        }

        static void Curve(int oldGrade, int curve, out int curvedGrade)
        {
            oldGrade += curve;
            if (oldGrade > 100) oldGrade = 100;
            curvedGrade = oldGrade;//assign the value to the out parameter
        }

        static void TimeStamp(ref string msg)//pass by reference
        {
            //msg is "Bob", result to be "11/22/2021 Bob"
            //$ starts an interpolated string
            msg = $"{DateTime.Now} {msg}";
        }

        static int Factor(int number, int factor)
        {
            return number * factor;
        }

        static void Factor2(ref int number, int factor)
        {
            number *= factor;//number = number * factor;
        }

        static string GetMessage()
        {
            string message;
            Console.Write("Please enter a message: ");
            message = Console.ReadLine();
            return message;
        }

        static void PrintMessage(string message = "Because I'm Batman!")//pass by value. making a copy
        {
            Console.WriteLine("Your message: ");
            Console.WriteLine(message);
        }

        //static void PrintMessage()
        //{
        //    Console.WriteLine("Because I'm Batman!");
        //}

        public static int Add(int n1, int n2)
        {
            int result = n1 + n2;
            return result;
        }
    }
}
