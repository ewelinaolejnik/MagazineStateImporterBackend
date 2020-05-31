using MagazineStateImporterBackend.Core.MagazineStateImporter.Models;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using System.Collections.Generic;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter
{
    public interface IMagazineStateImporter
    {
        IEnumerable<MagazineState> GetImportedMagazinesStates(ImporterInput input);
    }
}
