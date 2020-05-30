using MagazineStateImporterBackend.Core.MaterialInventoryStateParser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.Models
{
    public class MaterialInventoryState : MagazineInventoryState
    {
        public string MaterialName { get; set; }
        public string MaterialId { get; set; }
        public List<MaterialAmoutPerMagazine> AmoutsPerMagazine { get; set; }
    }
}
