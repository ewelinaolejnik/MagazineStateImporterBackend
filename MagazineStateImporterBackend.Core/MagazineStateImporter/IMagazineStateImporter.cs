using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter
{
    public interface IMagazineStateImporter
    {
        IEnumerable<MagazineState> GetImportedMagazinesStates(MagazineStateImporterInput magazineStateImporterInput);
    }
}
