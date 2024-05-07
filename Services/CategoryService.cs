using APISeries.Data;
using APISeries.DTO;
using APISeries.Models;
using APISeries.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APISeries.Services
{
    public class CategoryService : ICategoryInterface
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
    
        public Task<ResponseModel<List<CategoriaModel>>> deleteCategorias(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<CategoriaModel>>> getCategoria()
        {
            ResponseModel<List<CategoriaModel>> response = new ResponseModel<List<CategoriaModel>>();
            try
            {
                var categoria = await _context.Categoria.ToListAsync();
                if(categoria is null)
                {
                    response.Mensagem = "Dados não encontrados";
                    response.Status = false;
                    return response;
                }

                response.Dados = await _context.Categoria.ToListAsync();
                response.Mensagem = "Dados retornados com sucesso!";
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public Task<ResponseModel<CategoriaModel>> getCategoriaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CategoriaModel>>> getCategoriaByIdCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<CategoriaModel>>> postCategoria(CategoriaCriacaoDto categoriaCriacaoDto)
        {
            ResponseModel<List<CategoriaModel>> response = new ResponseModel<List<CategoriaModel>>();
            try
            {
                var categoria = new CategoriaModel();
                {
                    categoria.Tipo = categoriaCriacaoDto.Tipo;
                }

                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();

                response.Dados =  _context.Categoria.ToList();
                response.Mensagem = "Categoria adicionada com sucesso";

            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public Task<ResponseModel<List<CategoriaModel>>> putCategoria(CategoriaCriacaoDto categoriaEdicaoDto)
        {
            throw new NotImplementedException();
        }
    }
}
