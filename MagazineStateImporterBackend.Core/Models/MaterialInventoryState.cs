using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.Models
{
    internal class MaterialInventoryState
    {
        public string MaterialName { get; set; }
        public string MaterialId { get; set; }
        public string MagazineName { get; set; }
        public IEnumerable<MaterialAmoutPerMagazine> AmoutsPerMagazine { get; set; }
    }
}
