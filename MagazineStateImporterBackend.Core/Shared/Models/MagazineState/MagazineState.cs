using System.Collections.Generic;
using System.Linq;

namespace MagazineStateImporterBackend.Core.Shared.Models.MagazineState
{
    public class MagazineState
    {
        public string MagazineName { get; set; }
        public int MaterialsAmout => MaterialsStates.Sum(s => s.MaterialAmout);

        public MagazineState()
        {
            _materialsStates = new List<MaterialState>();
        }

        private List<MaterialState> _materialsStates;
        public List<MaterialState> MaterialsStates => _materialsStates.OrderBy(s => s.MaterialId).ToList();
    }
}
