using MagazineStateImporterBackend.Core.MagazineStateBuilder.Models;
using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter
{
    public interface IMagazineStateImporter<TOutput, TInput> where TOutput: MagazineState
                                                             where TInput: MagazineStateImporterInput
    {
        IEnumerable<TOutput> GetImportedMagazinesStates(TInput magazineStateImporterInput);
    }
}
