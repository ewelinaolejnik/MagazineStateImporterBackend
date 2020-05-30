using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.Models
{
    public class MagazineState
    {
        public string MagazineName { get; set; }
        public int MaterialsAmout { get; set; }

        public IEnumerable<MaterialState> MaterialsStates { get; set; }
    }
}
