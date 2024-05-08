using APISeries.DTO;
using APISeries.Models;

namespace APISeries.Services.Interfaces
{
    public interface ICategoryInterface
    {
        public Task<ResponseModel<List<CategoriaModel>>> getCategoria();
        public Task<ResponseModel<CategoriaModel>> getCategoriaById(int id);
        public Task<ResponseModel<CategoriaModel>> getCategoriaByIdSerie(int id);
        public Task<ResponseModel<List<CategoriaModel>>> postCategoria(CategoriaCriacaoDto categoriaCriacaoDto);
        public Task<ResponseModel<List<CategoriaModel>>> putCategoria(CategoriaCriacaoDto categoriaEdicaoDto);
        public Task<ResponseModel<List<CategoriaModel>>> deleteCategorias(int id);

    }
}
