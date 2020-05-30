using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MagazineStateImporterBackend.Core.MapperToMagazineState
{
    public class MapperToMagazineState
    {
        public IEnumerable<MagazineMaterialsState> Map(IEnumerable<MaterialInventoryState> materialInventoryStates)
        {
            Dictionary<string, MagazineMaterialsState> mapperHelperDictionary = new Dictionary<string, MagazineMaterialsState>();

            if(materialInventoryStates == null)
            {
                throw new ArgumentNullException("materialInventoryStates in MapperToMagazineState is null");
            }

            MagazineMaterialsState magazineMaterialsState;
            foreach (MaterialInventoryState materialInventoryState in materialInventoryStates)
            {
                foreach (var amoutPerMagazine in materialInventoryState.AmoutsPerMagazine)
                {
                    if (mapperHelperDictionary.ContainsKey(amoutPerMagazine.MagazineName))
                    {
                        magazineMaterialsState = mapperHelperDictionary[amoutPerMagazine.MagazineName];
                    }
                    else
                    {
                        magazineMaterialsState = new MagazineMaterialsState
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
