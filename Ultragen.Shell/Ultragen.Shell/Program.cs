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

            var generator = new BritishCityNameGenerator();
            var names = await generator.GenerateNames();

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
    }
}
