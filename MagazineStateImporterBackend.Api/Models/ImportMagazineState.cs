using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazineStateImporterBackend.Api.Models
{
    public class ImportMagazineState
    {
        public IFormFile File { get; set; }
    }
}
