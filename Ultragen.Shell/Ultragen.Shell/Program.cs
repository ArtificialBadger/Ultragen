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

            var names = await GetCityNames();

            foreach (var name in names)
            {
                chain.Add(name);
            }

            var uniqueNameCount = 50;
            var generatedNames = new List<string>();

            // Randomly generate words that resemble the words in the dictionary.
            var rand = new Random();
            while (generatedNames.Count < uniqueNameCount)
            {
                var word = new string(chain.Chain(rand).ToArray());

                if (!names.Contains(word))
                {
                    generatedNames.Add(word.Trim());
                }
            }

            foreach (var name in generatedNames)
            {
                Console.WriteLine(name);
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
