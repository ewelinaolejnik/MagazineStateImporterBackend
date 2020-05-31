using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;

namespace MagazineStateImporterBackend.Core.MagazineStateSourceParser
{
    public interface ISourceParser
    {
        MagazineStateSource Parse(string unparsedState);
    }
}
