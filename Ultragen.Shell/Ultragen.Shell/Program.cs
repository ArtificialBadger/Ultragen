using Markov;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ultragen.Shell
{
    class Program
    {
        static async Task Main()
        {
            // Create a chain with letters as the unit of data, basing each letter on the previous 2 letters
            var chain = new MarkovChain<char>(3);
            //chain.

            foreach (var name in await GetCityNames())
            {
                chain.Add(name);
            }

            //var uniqueNames = 100;

            // Randomly generate words that resemble the words in the dictionary.
            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                var word = new string(chain.Chain(rand).ToArray());
                Console.WriteLine(word.Trim());
            }

            Console.ReadLine();
        }

        public static async Task<IEnumerable<string>> GetCityNames()
        {

            string filePath = System.IO.Path.GetFullPath(@"..\..\..\British Names.txt");
            var file = new StreamReader(filePath);

            var rawNames = await file.ReadToEndAsync();

            return rawNames
                .Split(Environment.NewLine)
                .Select(n => n.Trim())
                .Select(n => n.Replace("(", ""))
                .Select(n => n.Replace(")", ""))
                .Select(n => n.Contains(',') ? String.Join(' ', n.Split(',').Reverse()) : n);
        }
    }
}
