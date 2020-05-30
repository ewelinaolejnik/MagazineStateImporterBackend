using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.Models
{
    public class MagazineInventoryStateParserInput
    {
        public IEnumerable<string> UnparsedStates { get; set; }
    }
}
