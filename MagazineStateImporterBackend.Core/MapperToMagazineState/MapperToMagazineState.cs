using MagazineStateImporterBackend.Core.Shared.Interfaces;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Core.MapperToMagazineState
{
    public class MapperToMagazineState: IMapperToDestinationState<MagazineState, MagazineStateSource>
    {
        public IEnumerable<MagazineState> Map(IEnumerable<MagazineStateSource> source)
        {
            if(source == null || !source.Any())
            {
                throw new ArgumentNullException("Source is null or empty");
            }

            Dictionary<string, MagazineState> mapperHelperDictionary = new Dictionary<string, MagazineState>();
            MagazineState magazineMaterialsState;

            foreach (MagazineStateSource materialInventoryState in source)
            {
                foreach (var amoutPerMagazine in materialInventoryState.AmoutsPerMagazine)
                {
                    if (mapperHelperDictionary.ContainsKey(amoutPerMagazine.MagazineName))
                    {
                        magazineMaterialsState = mapperHelperDictionary[amoutPerMagazine.MagazineName];
                    }
                    else
                    {
                        magazineMaterialsState = new MagazineState
                        {
                            MagazineName = amoutPerMagazine.MagazineName
                        };

                        mapperHelperDictionary.Add(amoutPerMagazine.MagazineName, magazineMaterialsState);
                    }

                    magazineMaterialsState.MaterialsStates
                            .Add(new MaterialState()
                            {
                                MaterialAmout = amoutPerMagazine.Amout,
                                MaterialId = materialInventoryState.MaterialId
                            });
                }
            }

            return mapperHelperDictionary.Values;
        }

    }
}
