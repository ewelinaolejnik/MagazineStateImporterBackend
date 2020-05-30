using MagazineStateImporterBackend.Core.MaterialInventoryStateParser.Models;
using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.MaterialInventoryStateParser
{
    public interface IParsedMagazineInventoryGetter<TOuput, TInput> where TOuput : MagazineInventoryState
                                                                    where TInput: MagazineInventoryStateParserInput
    {
        IEnumerable<TOuput> GetParsedMaterialInventoryStates(TInput input);
    }
}
