using APISeries.Data;
using APISeries.DTO;
using APISeries.Models;
using APISeries.Services.Interfaces;

namespace APISeries.Services
{
    public class SerieService : ISerieInterface
    {
        private readonly AppDbContext _context;
        public SerieService(AppDbContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<List<SeriesModel>>> deleteSeries(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<SeriesModel>>> getSeries()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<SeriesModel>> getSeriesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<SeriesModel>>> getSeriesByIdCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<SeriesModel>>> postSeries(SerieCriacaoDto serieCriacaoDto)
        {
            ResponseModel<List<SeriesModel>> response = new ResponseModel<List<SeriesModel>>();
            try
            {
                var categoria =  _context.Categoria
                    .FirstOrDefault(a => a.Id == serieCriacaoDto.Categoria.Id);
                if(categoria == null)
                {
                    response.Mensagem = "Nenhuma categoria encontrada!";
                    response.Status = false;
                    return response;
                }

                var serie = new SeriesModel();
                {
                    serie.Nome = serieCriacaoDto.Nome;
                    serie.Categoria = categoria;
                }

            _context.Serie.Add(serie); 
                await _context.SaveChangesAsync();

                response.Dados =  _context.Serie.ToList();
                response.Mensagem = "Serie incluida com sucesso";

             
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public Task<ResponseModel<List<SeriesModel>>> putSeries(SerieEdicaoDto serieEdicaoDto)
        {
            throw new NotImplementedException();
        }
    }
}
