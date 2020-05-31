using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter.Models
{
    public class ImporterInput
    {
        public IEnumerable<string> UnparsedInput { get; set; }
    }
}
