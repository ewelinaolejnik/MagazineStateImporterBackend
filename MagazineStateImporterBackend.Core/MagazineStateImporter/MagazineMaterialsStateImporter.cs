using MagazineStateImporterBackend.Core.MagazineInventoryStateParser.Models;
using MagazineStateImporterBackend.Core.MagazineStateImporter.Models;
using MagazineStateImporterBackend.Core.MapperToMagazineState;
using MagazineStateImporterBackend.Core.MaterialInventoryStateParser;
using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter
{
    public class MagazineMaterialsStateImporter : IMagazineStateImporter<MagazineMaterialsState, MagazineMaterialsStateImporterInput>
    {
        private readonly IMapperToMagazineState<MagazineMaterialsState, MaterialInventoryState> _mapperToMagazineState;
        private readonly IParsedMagazineInventoryGetter<MaterialInventoryState, MaterialInventoryStateParserInput> _parsedMagazineInventoryGetter;
        public MagazineMaterialsStateImporter(IMapperToMagazineState<MagazineMaterialsState, MaterialInventoryState> mapperToMagazineState, 
            IParsedMagazineInventoryGetter<MaterialInventoryState, MaterialInventoryStateParserInput> parsedMagazineInventoryGetter)
        {
            _mapperToMagazineState = mapperToMagazineState;
            _parsedMagazineInventoryGetter = parsedMagazineInventoryGetter;
        }

        public IEnumerable<MagazineMaterialsState> GetImportedMagazinesStates(MagazineMaterialsStateImporterInput magazineStateImporterInput)
        {
            var parserInput = new MaterialInventoryStateParserInput()
            {
                UnparsedStates = magazineStateImporterInput.UnparsedInput
            };
            var parsedMaterialInventoryStates = _parsedMagazineInventoryGetter.GetParsedMaterialInventoryStates(parserInput);
            return _mapperToMagazineState.Map(parsedMaterialInventoryStates)
                .OrderByDescending(s => s.MaterialsAmout)
                .ThenByDescending(s => s.MagazineName);
        }
    }
}
