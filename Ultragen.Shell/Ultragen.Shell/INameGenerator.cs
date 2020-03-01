using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ultragen.Shell
{
    public interface INameGenerator
    {
        Task<IEnumerable<string>> GenerateNames();
    }
}
