using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.Models
{
    public class MagazineStateImporterInput
    {
        public IEnumerable<string> FileLines { get; set; }
    }
}
