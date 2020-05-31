using MagazineStateImporterBackend.Core.Shared.Interfaces;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using System;
using System.Collections.Generic;

namespace MagazineStateImporterBackend.Core.MapperToMagazineState
{
    public class MapperToMagazineState: IMapperToDestinationState<MagazineState, MagazineStateSource>
    {
        public IEnumerable<MagazineState> Map(IEnumerable<MagazineStateSource> source)
        {
            Dictionary<string, MagazineState> mapperHelperDictionary = new Dictionary<string, MagazineState>();

            if(source == null)
            {
                throw new ArgumentNullException("materialInventoryStates in MapperToMagazineState is null");
            }

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
