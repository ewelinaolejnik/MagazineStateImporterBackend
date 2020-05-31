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
            var materialInventoryStates = new List<MagazineStateSource>();

            foreach (var unparsedState in input?.UnparsedStates?.SkipWhile(us => us.StartsWith("#")))
            {
                materialInventoryStates.Add(Parse(unparsedState));
            }

            return materialInventoryStates;
        }

        public MagazineStateSource Parse(string unparsedState)
        {
            if (string.IsNullOrEmpty(unparsedState))
            {
                throw new ArgumentNullException("Passed unparsed state is null");
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
