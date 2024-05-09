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
        [HttpGet("ListarCategorias")]
        public async Task<ActionResult<List<CategoriaModel>>> getCategoria()
        {
            var categoria = await _categoryInterface.getCategoria();
            if(categoria.Dados == null)
            {
                return NotFound(categoria.Mensagem);
            }
            return Ok(categoria);
        }
        [HttpGet("ListarCategoriaPorId/{id}")]
        public async Task<ActionResult<CategoriaModel>> getCategoriaById(int id)
        {
            var categoria = await _categoryInterface.getCategoriaById(id);    
            if(categoria.Dados == null)
            {
                return NotFound(categoria.Mensagem);
            }
            return Ok(categoria);
        }
        [HttpGet("ListarCategoriaPorIdSerie/{id}")]
        public async Task<ActionResult<CategoriaModel>> getCategoriaByIdSerie(int id)
        {
            var categoria = await _categoryInterface.getCategoriaByIdSerie(id);
            if (categoria.Dados == null)
            {
                return NotFound(categoria.Mensagem);
            }
            return Ok(categoria);
        }

        [HttpPut("CategoriaEditada")]
        public async Task<ActionResult<List<CategoriaModel>>> putCategoria(CategoriaEdicaoDto categoriaEdicaoDto)
        {
            var categoria = await _categoryInterface.putCategoria(categoriaEdicaoDto);  
            if(categoria.Dados is null)
            {
                return NotFound(categoria.Mensagem);
            }
            return Ok(categoria);
        }
        [HttpDelete("CategoriaDeletar/{id}")]
        public async Task<ActionResult<List<CategoriaModel>>> deleteCategorias(int id)
        {
            var categoria = await _categoryInterface.deleteCategorias(id);  
            if (categoria.Dados is null)
            {
                return NotFound(categoria.Mensagem);
            }
            return Ok(categoria);
        }
    }
}
