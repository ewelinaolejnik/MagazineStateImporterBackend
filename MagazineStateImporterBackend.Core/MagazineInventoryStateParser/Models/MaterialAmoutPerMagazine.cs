using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.Models
{
    public class MaterialAmoutPerMagazine
    {
        public string MagazineName { get; private set; }
        public int Amout { get; private set; }

        public MaterialAmoutPerMagazine IsAmoutOf(int amount)
        {
            Amout = amount;
            return this;
        }

        public MaterialAmoutPerMagazine InMagazine(string magazineName)
        {
            MagazineName = magazineName;
            return this;
        }
    }
}
