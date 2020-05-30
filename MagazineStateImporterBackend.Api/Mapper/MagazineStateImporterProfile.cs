using AutoMapper;
using MagazineStateImporterBackend.Api.Extensions;
using MagazineStateImporterBackend.Api.Models;
using MagazineStateImporterBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazineStateImporterBackend.Api.Mapper
{
    public class MagazineStateImporterProfile: Profile
    {
        public MagazineStateImporterProfile()
        {
            CreateMap<ImportMagazineState, MagazineStateImporterInput>()
                .ForMember(destination => destination.UnparsedInput, 
                source => source.MapFrom(src => src.File.GetFileLines()));
        }
        
    }
}
