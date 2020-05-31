using System.Collections.Generic;

namespace MagazineStateImporterBackend.Core.Shared.Interfaces
{
    public interface IMapperToDestinationState<TOutput, TInput>
    {
        IEnumerable<TOutput> Map(IEnumerable<TInput> source);
    }
}
