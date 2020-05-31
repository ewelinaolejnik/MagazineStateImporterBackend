using System.Collections.Generic;

namespace MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource
{
    public class MagazineStateSource
    {
        public string MaterialName { get; set; }
        public string MaterialId { get; set; }
        public List<MaterialAmoutPerMagazine> AmoutsPerMagazine { get; set; }

        public MagazineStateSource()
        {
            AmoutsPerMagazine = new List<MaterialAmoutPerMagazine>();
        }
    }
}
