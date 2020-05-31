using AutoMapper;
using MagazineStateImporterBackend.Api.Extensions;
using MagazineStateImporterBackend.Api.Models;
using MagazineStateImporterBackend.Core.MagazineStateImporter.Models;

namespace MagazineStateImporterBackend.Api.Mapper
{
    public class MagazineStateImporterProfile: Profile
    {
        public MagazineStateImporterProfile()
        {
            CreateMap<ImportMagazineState, ImporterInput>()
                .ForMember(destination => destination.UnparsedInput, 
                source => source.MapFrom(src => src.File.GetFileLines()));
        }
        
    }
}
