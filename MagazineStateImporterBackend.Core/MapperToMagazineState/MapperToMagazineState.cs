using MagazineStateImporterBackend.Core.Shared.Interfaces;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Core.MapperToMagazineState
{
    public class MapperToMagazineState : IMapperToDestinationState<MagazineState, MagazineStateSource>
    {
        public IEnumerable<MagazineState> Map(IEnumerable<MagazineStateSource> source)
        {
            if (source == null || !source.Any())
            {
                throw new ArgumentNullException("Source is null or empty");
            }

            List<MagazineState> magazineStates = new List<MagazineState>();

            var magazinesNames = source.SelectMany(s => s.AmoutsPerMagazine).Select(a => a.MagazineName).Distinct();
            foreach (string magazineName in magazinesNames)
            {
                magazineStates.Add(Map(source, magazineName));
            }

            return magazineStates;
        }

        public MagazineState Map(IEnumerable<MagazineStateSource> source, string magazineName)
        {
            var sourcePerMagazine = source.Where(s => s.AmoutsPerMagazine.Any(a => a.MagazineName == magazineName));

            return new MagazineState()
            {
                MagazineName = magazineName,
                MaterialsStates = sourcePerMagazine.Select(s => new MaterialState()
                {
                    MaterialAmount = s.AmoutsPerMagazine.FirstOrDefault(a => a.MagazineName == magazineName).Amout,
                    MaterialId = s.MaterialId
                }).ToList()
            };
        }

    }
}
