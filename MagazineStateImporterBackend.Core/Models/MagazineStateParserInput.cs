using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.Models
{
    internal class MagazineStateParserInput
    {
        public IEnumerable<string> FileLines { get; set; }
    }
}
