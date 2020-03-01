using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ultragen.Shell
{
    public sealed class BritishCityNameGenerator : INameGenerator
    {

        public async Task<IEnumerable<string>> GenerateNames()
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
