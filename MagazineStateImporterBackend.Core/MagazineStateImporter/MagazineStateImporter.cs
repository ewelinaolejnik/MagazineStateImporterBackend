using MagazineStateImporterBackend.Core.MagazineStateImporter.Extensions;
using MagazineStateImporterBackend.Core.MagazineStateImporter.Models;
using MagazineStateImporterBackend.Core.MagazineStateSourceParser.Models;
using MagazineStateImporterBackend.Core.Shared.Interfaces;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter
{
    public class MagazineStateImporter : IMagazineStateImporter
    {
        private readonly IMapperToDestinationState<MagazineState, MagazineStateSource> _mapperToMagazineState;
        private readonly IFromSource<MagazineStateSource, ParserInput> _fromSource;

        public MagazineStateImporter(IMapperToDestinationState<MagazineState, MagazineStateSource> mapperToMagazineState,
            IFromSource<MagazineStateSource, ParserInput> fromSource)
        {
            _mapperToMagazineState = mapperToMagazineState;
            _fromSource = fromSource;
        }

        public IEnumerable<MagazineState> GetImportedMagazinesStates(ImporterInput input)
        {
            var parserInput = new ParserInput()
            {
                UnparsedStates = input.UnparsedInput
            };
            var parsedMaterialInventoryStates = _fromSource.GetDataFromSource(parserInput)
                .OrderBy(s=>s.MaterialId);
            return _mapperToMagazineState.Map(parsedMaterialInventoryStates)
                .OrderMaterialsBy(s => s.MaterialId)
                .OrderByDescending(s => s.MaterialsAmout)
                .ThenByDescending(s => s.MagazineName);
        }
    }
}
