using APISeries.DTO;
using APISeries.Models;
using APISeries.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoryInterface _categoryInterface;
        public CategoriaController(ICategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface; 
        }
        [HttpPost("CriarCategoria")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> postCategoria(CategoriaCriacaoDto categoriaCriacaoDto)
        {
            var categoria = await _categoryInterface.postCategoria(categoriaCriacaoDto);
            if(categoria.Dados is null)
            {
                return NotFound(categoria.Mensagem);
            }
            return Ok(categoria);
        }
    }
}
