using System;
using System.Collections.Generic;
using System.IO;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\temp\2112\sample.txt";

            char delimiter = '~';

            #region Writing CSV
            //1) open the file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                //2. write to the file
                sw.Write(5);
                sw.Write(delimiter);
                sw.Write(13.7);
                sw.Write(delimiter);
                sw.Write("Batman #1");
                sw.Write(delimiter);
                sw.Write(true);
            }//3. close the file

            WriteData(filePath);
            #endregion

            #region Reading CSV
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                delimiter = '%';
                Console.WriteLine("----------Data---------");
                while (true)
                {
                    line = sr.ReadLine();
                    if (line == null) break;

                    string[] lineData = line.Split(delimiter);
                    for (int i = 0; i < lineData.Length; i++)
                    {
                        Console.WriteLine(lineData[i]);
                    }
                }

                //OR

                Console.WriteLine("----------Data2---------");
                string fileData = File.ReadAllText(filePath);//opens,reads,closes the file
                string[] data = fileData.Split(delimiter);
                for (int i = 0; i < data.Length; i++)
                {
                    Console.WriteLine(data[i]);
                }
            }
            #endregion
        }

        private static void WriteData(string filePath)
        {
            List<int> numbers = new List<int>() { 1, 2, 4, 5, 6, 7 };

            char delimiter = '%';

            //1) open the file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                bool notFirst = false;
                foreach (var number in numbers)
                {
                    if (notFirst)
                        sw.Write(delimiter);
                    sw.Write(number);
                    notFirst = true;
                }
            }//3. close the file
        }
    }
}
