using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Day04
{
    enum SuperPowers
    {
        Flight, Strength, Speed, Money, Intelligence, Acrobatics, Swimming
    }
    class Superhero
    {
        public string Name { get; set; }
        public string SecretIdentity { get; set; }
        public SuperPowers Powers { get; set; }
    }
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

            ReadData(filePath);
            #endregion

            #region Serializing

            WriteJson(filePath);

            List<Superhero> heroes = new List<Superhero>();
            heroes.Add(new Superhero() { Name = "Batman", SecretIdentity = "Bruce Wayne", Powers = SuperPowers.Money });
            heroes.Add(new Superhero() { Name = "Superman", SecretIdentity = "Clark Kent", Powers = SuperPowers.Flight });
            heroes.Add(new Superhero() { Name = "Wonder Woman", SecretIdentity = "Diana Prince", Powers = SuperPowers.Strength });
            heroes.Add(new Superhero() { Name = "Flash", SecretIdentity = "Barry Allen", Powers = SuperPowers.Speed });
            heroes.Add(new Superhero() { Name = "Aquaman", SecretIdentity = "Arther Curry", Powers = SuperPowers.Swimming });

            filePath = Path.ChangeExtension(filePath, ".json");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    //serialize the data
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, heroes);
                }
            }
            #endregion

            #region Deserializing
            //filePath = "steev.json";
            if (File.Exists(filePath))
            {
                string heroText = File.ReadAllText(filePath);
                List<Superhero> justice;

                try
                {
                    justice = JsonConvert.DeserializeObject<List<Superhero>>(heroText);
                    Console.WriteLine("------------Justice League----------");
                    foreach (var super in justice)
                    {
                        Console.WriteLine($"I am {super.Name} and I'm good at {super.Powers}!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The file is incorrect!");
                }
            }

            WriteJson(filePath);
            List<int> myNums = ReadJson(filePath);
            Console.WriteLine("------------Numbers----------");
            foreach (var num in myNums)
            {
                Console.WriteLine(num);
            }
            #endregion
        }

        private static List<int> ReadJson(string filePath)
        {
            List<int> numbers = null;
            if (File.Exists(filePath))
            {
                string heroText = File.ReadAllText(filePath);

                try
                {
                    numbers = JsonConvert.DeserializeObject<List<int>>(heroText);
                }
                catch (Exception)
                {
                    Console.WriteLine("The file is incorrect!");
                }
            }
            return numbers;
        }

        private static void WriteJson(string filePath)
        {
            List<int> nums = new List<int>() { 5, 4, 3, 2, 1 };

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    //serialize the data
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, nums);
                }
            }

            //OR
            string jsonText = JsonConvert.SerializeObject(nums,Formatting.Indented);
            File.WriteAllText(filePath, jsonText);
        }

        private static void ReadData(string filePath)
        {
            char delimiter = '%';
            Console.WriteLine("----------ReadData---------");
            string fileData = File.ReadAllText(filePath);//opens,reads,closes the file
            string[] data = fileData.Split(delimiter);

            List<int> numbers = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                if(int.TryParse(data[i], out int number))
                {
                    numbers.Add(number);
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
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
