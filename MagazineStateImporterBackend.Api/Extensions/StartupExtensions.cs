using MagazineStateImporterBackend.Core.MagazineStateImporter;
using MagazineStateImporterBackend.Core.MagazineStateSourceParser;
using MagazineStateImporterBackend.Core.MagazineStateSourceParser.Models;
using MagazineStateImporterBackend.Core.MapperToMagazineState;
using MagazineStateImporterBackend.Core.Shared.Interfaces;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineState;
using MagazineStateImporterBackend.Core.Shared.Models.MagazineStateSource;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazineStateImporterBackend.Api.Extensions
{
    public static class StartupExtensions
    {

        public static void AddMagazineStateImporterDependencies(this IServiceCollection services)
        {
            services.AddTransient<IMagazineStateImporter, MagazineStateImporter>();
            services.AddTransient<IMapperToDestinationState<MagazineState, MagazineStateSource>, MapperToMagazineState>();
            services.AddTransient<IFromSource<MagazineStateSource, ParserInput>, MagazineStateSourceParser>();
        }
    }
}
