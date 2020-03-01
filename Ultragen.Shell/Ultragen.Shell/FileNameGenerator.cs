using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ultragen.Shell
{
    public sealed class FileNameGenerator : INameGenerator
    {
        public string FileLocation { get; set; }

        public async Task<IEnumerable<string>> GenerateNames()
        {
            var filePath = System.IO.Path.GetFullPath(this.FileLocation);
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
