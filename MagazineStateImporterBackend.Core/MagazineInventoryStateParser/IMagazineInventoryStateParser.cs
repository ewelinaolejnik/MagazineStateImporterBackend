using MagazineStateImporterBackend.Core.MaterialInventoryStateParser.Models;
using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter
{
    public interface IMagazineInventoryStateParser<TOuput> where TOuput : MagazineInventoryState
    {
        TOuput Parse(string unparsedState);
    }
}
