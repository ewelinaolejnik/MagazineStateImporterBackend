using System;
using AutoMapper;
using MagazineStateImporterBackend.Api.Models;
using MagazineStateImporterBackend.Core.MagazineStateImporter;
using MagazineStateImporterBackend.Core.MagazineStateImporter.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagazineStateImporterBackend.Api.Controllers
{
    [Route("api/import-magazine-state")]
    [ApiController]
    public class ImportMagazineStateController : ControllerBase
    {
        private readonly IMagazineStateImporter _magazineStateImporter;
        private readonly IMapper _mapper;

        public ImportMagazineStateController(IMapper mapper, IMagazineStateImporter magazineStateImporter)
        {
            _mapper = mapper;
            _magazineStateImporter = magazineStateImporter;
        }

        [HttpPost]
        public IActionResult ImportMagazineState([FromForm] ImportMagazineState importMagazineState)
        {
            try
            {
                ImporterInput importerInput = _mapper.Map<ImporterInput>(importMagazineState);
                var magazinesStates = _magazineStateImporter.GetImportedMagazinesStates(importerInput);
                return Ok(magazinesStates);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Error = ex.ToString() });
            }
            
        }
    }
}