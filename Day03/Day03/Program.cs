using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 ways to add keys/values to a dictionary
            //  1) declaration 
            //  2) Add method
            //  3) [ ]
            Dictionary<string, float> menu = new Dictionary<string, float>()
            {
                //{key,value} Key Value Pair
                {"Hamburger", 0.99F },
                {"Cheesy Hamburger", 1.25F }
            };

            //2) Add
            //      IF the key already exists, you will get an exception
            menu.Add("Fries", 0.99F);

            //3) [ ]
            //      IF the key already exists, it will overwrite the value. NO exception is thrown.
            menu["Milk Shake"] = 1.99F;

            #region Create a Dictionary

            Random randy = new Random();
            Dictionary<string, double> pg2 = new Dictionary<string, double>()
            {
                {"Kyle", randy.NextDouble() * 100.0},
                {"Vrij", randy.NextDouble() * 100.0}
            };

            pg2.Add("Zachary", randy.NextDouble() * 100.0);
            pg2.Add("Luis", randy.NextDouble() * 100.0);
            pg2.Add("David", randy.NextDouble() * 100.0);
            pg2.Add("Ruben", randy.NextDouble() * 100.0);
            pg2.Add("Thomas", randy.NextDouble() * 100.0);
            pg2.Add("Curtis", randy.NextDouble() * 100.0);
            pg2.Add("Luc", randy.NextDouble() * 100.0);
            pg2.Add("Terrel", randy.NextDouble() * 100.0);

            pg2["Chandler"] = randy.NextDouble() * 100.0;
            pg2["Ethan"] = randy.NextDouble() * 100.0;
            pg2["Aleksei"] = randy.NextDouble() * 100.0;
            pg2["Jamari"] = randy.NextDouble() * 100.0;

            pg2["Amarion"] = randy.NextDouble() * 100.0;
            pg2["Amari"] = randy.NextDouble() * 100.0;
            pg2["Myles"] = randy.NextDouble() * 100.0;
            pg2["Cameron"] = randy.NextDouble() * 100.0;
            pg2["Steven"] = randy.NextDouble() * 100.0;
            pg2["Timothy"] = randy.NextDouble() * 100.0;
            pg2["Zia"] = randy.NextDouble() * 100.0;
            pg2["Jamarious"] = randy.NextDouble() * 100.0;
            pg2["Nicklas"] = randy.NextDouble() * 100.0;
            pg2["Bradley"] = randy.NextDouble() * 100.0;
            pg2["Blake"] = randy.NextDouble() * 100.0;
            pg2["Chayoung"] = randy.NextDouble() * 100.0;
            pg2["Christian"] = randy.NextDouble() * 100.0;
            pg2["Erik"] = randy.NextDouble() * 100.0;
            pg2["Khumoyun"] = randy.NextDouble() * 100.0;
            pg2["Nelson"] = randy.NextDouble() * 100.0;
            pg2["William"] = randy.NextDouble() * 100.0;
            pg2["Nicholas"] = randy.NextDouble() * 100.0;
            pg2["Tyler"] = randy.NextDouble() * 100.0;
            pg2["Ulyssa"] = randy.NextDouble() * 100.0;
            pg2["Kyle"] = randy.NextDouble() * 100.0;
            #endregion

            #region Looping
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            Console.WriteLine("\n______\"Dollar\" Burger Menu_________");
            foreach (KeyValuePair<string,float> item in menu)
            {
                Console.WriteLine($"{item.Value,7:C2} {item.Key} ");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            PrintGrades(pg2);
            #endregion

            #region Remove
            if (menu.Remove("Milk Shake"))
                Console.WriteLine("Sorry folks. The machine is broken.");
            else
                Console.WriteLine("That's not on the menu. Go to In-n-Out.");

            DropStudent(pg2);
            #endregion
        }

        /// <summary>
        /// Gets the student's name from the user and attempts to remove from the dictionary.
        /// </summary>
        /// <param name="pg2">The dictionary for the course.</param>
        private static void DropStudent(Dictionary<string, double> pg2)
        {
            Console.Write("Please enter the student's name: ");
            string student = Console.ReadLine();
            bool wasDropped = pg2.Remove(student);
            if(wasDropped)
                Console.WriteLine($"{student} was dropped.");
            else
                Console.WriteLine($"{student} was not in the course.");
        }

        private static void PrintGrades(Dictionary<string, double> grades)
        {
            Console.WriteLine("----------------Grades--------------");
            foreach (KeyValuePair<string,double> student in grades)
            {
                Console.Write($"{student.Key,-10}");
                if (student.Value < 59.5)
                    Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"{student.Value,7:N2}");
                Console.ResetColor();
            }
        }
    }
}
