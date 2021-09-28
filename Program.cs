using System;
using System.IO;
using System.Collections.Generic;

namespace Names1
{
    class Program
    {
        static void Main() 
        {
            const string FileName = "names.txt";
            StreamReader reader = new StreamReader(FileName);
            Console.WriteLine("Длина = {0}", reader.BaseStream.Length); 
            int i = 1;
            Dictionary<string, int> Names = new Dictionary<string, int>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(' ');
                if (values.Length < 2)
                    continue;

                Console.WriteLine(line); //Вывод всего текста


                string LastName = values[0];
                string FirstName = values[1];
                if (Names.ContainsKey(FirstName))
                    Names[FirstName]++;
                else
                    Names.Add(FirstName, 1);

                if (Names.ContainsKey(LastName))
                    Names[LastName]++;
                else
                    Names.Add(LastName, 1);

            }
            foreach (var name in Names)
                Console.WriteLine("{0} - {1}", name.Key, name.Value);
            foreach (var lastname in Names)
                Console.WriteLine("{0} - {1}", lastname.Key, lastname.Value);
            reader.Close();
        }
    }
}
