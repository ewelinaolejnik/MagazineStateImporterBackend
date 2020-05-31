using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MagazineStateImporterBackend.Core.MagazineStateImporter.Extensions
{
    public static class MagazineStateExtensions
    {
        public static IEnumerable<MagazineState> OrderMaterialsBy<T>(this IEnumerable<MagazineState> magazineStates, Func<MaterialState, T> selector)
        {
            foreach (var magazineState in magazineStates)
            {
                magazineState.MaterialsStates = magazineState.MaterialsStates.OrderBy(selector).ToList();
            }

            return magazineStates;
        }
    }
}
