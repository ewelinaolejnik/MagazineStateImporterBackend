using System;
using System.Collections.Generic;
using System.Text;

namespace MagazineStateImporterBackend.Core.Shared.Interfaces
{
    public interface IFromSource<TOuput, TInput>
    {
        IEnumerable<TOuput> GetDataFromSource(TInput input);
    }
}
