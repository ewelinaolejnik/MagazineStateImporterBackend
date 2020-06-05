using MagazineStateImporterBackend.Core.MagazineStateSourceParser.Models;
using MagazineStateImporterBackend.Core.Shared.Interfaces;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Core.MagazineStateSourceParser
{
    public class MagazineStateSourceParser : IFromSource<MagazineStateSource, ParserInput>, 
                                             ISourceParser
    {
        public IEnumerable<MagazineStateSource> GetDataFromSource(ParserInput input)
        {
            if (input?.UnparsedStates == null || !input.UnparsedStates.Any())
            {
                throw new ArgumentNullException("Passed parser input is null or empty");
            }

            var magazineStateSources = new List<MagazineStateSource>();

            foreach (var unparsedState in input.UnparsedStates.Where(us => !us.StartsWith("#")))
            {
                magazineStateSources.Add(Parse(unparsedState));
            }

            return magazineStateSources;
        }

        public MagazineStateSource Parse(string unparsedState)
        {
            if (string.IsNullOrEmpty(unparsedState))
            {
                throw new ArgumentNullException("Passed unparsed state is null or empty");
            }

            try
            {
                var parsedMaterial = ParseMaterial(unparsedState);
                var amoutsPerMagazines = parsedMaterial.AmountsPerMagazines.Split("|").Select(a => ParseAmountPerMagazine(a));
                parsedMaterial.source.AmoutsPerMagazine.AddRange(amoutsPerMagazines);

                return parsedMaterial.source;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public (MagazineStateSource source, string AmountsPerMagazines) ParseMaterial(string unparsedState)
        {
            string[] splitedState = unparsedState.Split(";");
            return (new MagazineStateSource()
            {
                MaterialId = splitedState[1],
                MaterialName = splitedState[0]
            }, splitedState[2]);
        }

        public MaterialAmoutPerMagazine ParseAmountPerMagazine(string unparsedAmoutPerMagazine)
        {
            string magazineName = unparsedAmoutPerMagazine.Split(",")[0];
            int amout = int.Parse(unparsedAmoutPerMagazine.Split(",")[1]);

            return new MaterialAmoutPerMagazine().InMagazine(magazineName).IsAmoutOf(amout);
        }

    }
}
