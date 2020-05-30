using MagazineStateImporterBackend.Core.MagazineInventoryStateParser.Models;
using MagazineStateImporterBackend.Core.MaterialInventoryStateParser;
using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter
{
    public class MaterialInventoryStateParser : IParsedMagazineInventoryGetter<MaterialInventoryState, MaterialInventoryStateParserInput>, 
                                                IMagazineInventoryStateParser<MaterialInventoryState>
    {
        public IEnumerable<MaterialInventoryState> GetParsedMaterialInventoryStates(MaterialInventoryStateParserInput input)
        {
            var materialInventoryStates = new List<MaterialInventoryState>();

            foreach (var unparsedState in input?.UnparsedStates?.SkipWhile(us=>us.StartsWith("#")))
            {
                materialInventoryStates.Add(Parse(unparsedState));
            }

            return materialInventoryStates;
        }

        public MaterialInventoryState Parse(string unparsedState)
        {
            if (string.IsNullOrEmpty(unparsedState))
            {
                throw new ArgumentNullException("Passed unparsed state is null");
            }

            try
            {
                MaterialInventoryState materialInventoryState = new MaterialInventoryState();
                string[] splitedState = unparsedState.Split(";");
                materialInventoryState.MaterialName = splitedState[0];
                materialInventoryState.MaterialId = splitedState[1];
                foreach (string amoutPerMagazine in splitedState[2].Split("|"))
                {
                    string magazineName = amoutPerMagazine.Split(",")[0];
                    int amout = int.Parse(amoutPerMagazine.Split(",")[1]);
                    materialInventoryState.AmoutsPerMagazine
                        .Add(new MaterialAmoutPerMagazine().InMagazine(magazineName).IsAmoutOf(amout));
                }

                return materialInventoryState;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
