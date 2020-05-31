using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Core.Shared.Models.MagazineState
{
    public class MagazineState
    {
        public string MagazineName { get; set; }
        public int MaterialsAmount => MaterialsStates.Sum(s => s.MaterialAmount);
        public List<MaterialState> MaterialsStates { get; set; }

        public MagazineState()
        {
            MaterialsStates = new List<MaterialState>();
        }
    }
}
