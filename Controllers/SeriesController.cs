using APISeries.DTO;
using APISeries.Models;
using APISeries.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISerieInterface _serieInterface;
        public SeriesController(ISerieInterface serieInterface)
        {
            _serieInterface = serieInterface;   
        }
        [HttpPost("CriarSerie")] 
        public async Task<ActionResult<List<SeriesModel>>> postSeries(SerieCriacaoDto serieCriacaoDto)
        {
            var serie = await _serieInterface.postSeries(serieCriacaoDto);
            if(serie.Dados == null)
            {
                return NotFound(serie.Mensagem);
            }
            return Ok(serie);
        }
        [HttpGet("ListarSerie")]
        public async Task<ActionResult<List<SeriesModel>>> getSeries()
        {
            var serie = await _serieInterface.getSeries();
            if (serie.Dados == null)
            {
                return NotFound(serie.Mensagem);
            }
            return Ok(serie);
        }

        [HttpDelete("DeletarSerie/{id}")]
        public async Task<ActionResult<List<SeriesModel>>> deleteSeries(int id)
        {
            var serie = await _serieInterface.deleteSeries(id);
            if (serie.Dados == null)
            {
                return NotFound(serie.Mensagem);
            }
            return Ok(serie);
        }

        [HttpGet("ListarSeriePorId/{id}")]
        public async Task<ActionResult<SeriesModel>> getSeriesById(int id)
        {
            var serie = await _serieInterface.getSeriesById(id);
            if(serie.Dados is null)
            {
               return NotFound( serie.Mensagem ); 
            }
            return Ok(serie);
        }

    }
}
