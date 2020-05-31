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
                MagazineStateSource source = new MagazineStateSource();
                string[] splitedState = unparsedState.Split(";");
                source.MaterialName = splitedState[0];
                source.MaterialId = splitedState[1];
                foreach (string amoutPerMagazine in splitedState[2].Split("|"))
                {
                    string magazineName = amoutPerMagazine.Split(",")[0];
                    int amout = int.Parse(amoutPerMagazine.Split(",")[1]);
                    source.AmoutsPerMagazine
                        .Add(new MaterialAmoutPerMagazine().InMagazine(magazineName).IsAmoutOf(amout));
                }

                return source;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
