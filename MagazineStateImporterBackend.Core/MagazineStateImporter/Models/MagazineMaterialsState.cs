using MagazineStateImporterBackend.Core.MagazineStateBuilder.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MagazineStateImporterBackend.Core.Models
{
    public class MagazineMaterialsState: MagazineState
    {
        public string MagazineName { get; set; }
        public int MaterialsAmout => MaterialsStates.Sum(s => s.MaterialAmout);

        public MagazineMaterialsState()
        {
            _materialsStates = new List<MaterialState>();
        }

        private List<MaterialState> _materialsStates;
        public List<MaterialState> MaterialsStates => _materialsStates.OrderBy(s => s.MaterialId).ToList();
    }
}
