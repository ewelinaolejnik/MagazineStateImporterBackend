using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MagazineStateImporterBackend.Api.Models;
using MagazineStateImporterBackend.Core.MagazineStateImporter;
using MagazineStateImporterBackend.Core.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult ImportMagazineState([FromBody] ImportMagazineState importMagazineState)
        {
            try
            {
                MagazineStateImporterInput magazineStateImporterInput = _mapper.Map<MagazineStateImporterInput>(importMagazineState);
                var magazinesStates = _magazineStateImporter.GetImportedMagazinesStates(magazineStateImporterInput);
                return Ok(magazinesStates);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.ToString()});
            }
            
        }
    }
}