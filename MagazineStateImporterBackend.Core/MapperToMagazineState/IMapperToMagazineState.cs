using MagazineStateImporterBackend.Core.MagazineStateBuilder.Models;
using MagazineStateImporterBackend.Core.MaterialInventoryStateParser.Models;
using System.Collections.Generic;

namespace MagazineStateImporterBackend.Core.MapperToMagazineState
{
    public interface IMapperToMagazineState<TOutput, TInput> where TOutput : MagazineState
                                                             where TInput : MagazineInventoryState
    {
        IEnumerable<TOutput> Map(IEnumerable<TInput> materialInventoryStates);
    }
}
