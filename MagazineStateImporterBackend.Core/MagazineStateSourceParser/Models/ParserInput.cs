using System.Collections.Generic;

namespace MagazineStateImporterBackend.Core.MagazineStateSourceParser.Models
{
    public class ParserInput
    {
        public IEnumerable<string> UnparsedStates { get; set; }
    }
}
