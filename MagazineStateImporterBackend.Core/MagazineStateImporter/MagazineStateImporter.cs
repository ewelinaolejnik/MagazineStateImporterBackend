using MagazineStateImporterBackend.Core.MagazineStateImporter.Models;
using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter
{
    public class MagazineStateImporter : IMagazineStateImporter<MagazineMaterialsState, MagazineMaterialsStateImporterInput>
    {
        public IEnumerable<MagazineMaterialsState> GetImportedMagazinesStates(MagazineMaterialsStateImporterInput magazineStateImporterInput)
        {
            return null;
        }
    }
}
