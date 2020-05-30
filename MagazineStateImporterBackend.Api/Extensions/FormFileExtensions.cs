using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineStateImporterBackend.Api.Extensions
{
    public static class FormFileExtensions
    {
        public static async Task<IEnumerable<string>> GetFileLines(this IFormFile file)
        {
            List<string> lines = new List<string>();

            if(file == null)
            {
                return lines;
            }
            
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    lines.Add(await reader.ReadLineAsync());
            }

            return lines;
        }
    }
}
