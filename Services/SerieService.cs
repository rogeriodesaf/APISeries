using APISeries.Data;
using APISeries.DTO;
using APISeries.Models;
using APISeries.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APISeries.Services
{
    public class SerieService : ISerieInterface
    {
        private readonly AppDbContext _context;
        public SerieService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<SeriesModel>>> deleteSeries(int id)
        {
            ResponseModel<List<SeriesModel>> response = new ResponseModel<List<SeriesModel>>();
            try
            {
                var series = await _context.Serie
                    .FirstOrDefaultAsync(a => a.Id == id);
                if(series == null)
                {
                    response.Mensagem = "Dados não encontrados!";
                    response.Status = false;
                    return response;
                }

                _context.Remove(series);
                await _context.SaveChangesAsync();  

                response.Dados = await _context.Serie.Include(a =>a.Categoria).ToListAsync();
                response.Mensagem = "Série deletada com sucesso.";
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<List<SeriesModel>>> getSeries()
        {
            ResponseModel<List<SeriesModel>> response = new ResponseModel<List<SeriesModel>>();
            try
            {
                var series = await _context.Serie.ToListAsync();
                if (series == null)
                {
                    response.Mensagem = "Serie não encontrada";
                    response.Status = false;
                    return response;
                }

                response.Dados = await _context.Serie.Include(a => a.Categoria).ToListAsync();
                response.Mensagem = "Consulta feita com sucesso!";
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<SeriesModel>> getSeriesById(int id)
        {
            ResponseModel<SeriesModel> response = new ResponseModel<SeriesModel>();
            try 
	{	        
                var serie = await _context.Serie.Include(a => a.Categoria)
                    .FirstOrDefaultAsync(a => a.Id == id);
              if(serie == null) 
                {
                    response.Mensagem = "Dados não encontrados";
                    response.Status=false;      
                    return response;
                }

                response.Dados = serie;
                  
                response.Mensagem = "Série retornada com sucesso!";

		
	}
	catch (Exception ex)
	{

		response.Mensagem = ex.Message;
        response.Status= false; 
        return  response;
	}
            return response;
        }

        public async Task<ResponseModel<List<SeriesModel>>> getSeriesByIdCategory(int id)
        {
            ResponseModel<List<SeriesModel>> response = new ResponseModel<List<SeriesModel>>();
            try
            {
                var series = await _context.Categoria.Include(a => a.Series)
                    .FirstOrDefaultAsync(a => a.Id == id);
                if(series is null)
                {
                    response.Mensagem = "Dados não encontrados";
                    response.Status = false;
                    return response;
                }
                response.Dados = series.Series.ToList();    
                response.Mensagem = "Dados retornados com sucesso";
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
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

        public async Task<ResponseModel<List<SeriesModel>>> putSeries(SerieEdicaoDto serieEdicaoDto)
        {
            ResponseModel<List<SeriesModel>> response = new ResponseModel<List<SeriesModel>>();
            try
            {
                var series = await _context.Serie
                    .Include(x => x.Categoria)
                    .FirstOrDefaultAsync(a => a.Id == serieEdicaoDto.Id);
                if(series is null)
                {
                    response.Mensagem = "deu erro";
                    response.Status = false;
                    return response;
                }
              // Atualize as propriedades da série com base no DTO
                    series.Nome = serieEdicaoDto.Nome;

                    
                        // Carregue a nova categoria do banco de dados
              var novaCategoria = await _context.Categoria.FindAsync(serieEdicaoDto.Categoria.Id);
                if(novaCategoria != null)
                {
                    // Atribua a nova categoria à série
                    series.Categoria = novaCategoria;

                }

                else
                {
                    // Marque a série como modificada e salve as alterações
                    _context.Serie.Update(series);
                    await _context.SaveChangesAsync();
                }


                

                    // Atualize a resposta com os dados mais recentes do banco de dados
                    response.Dados = await _context.Serie.Include(a => a.Categoria).ToListAsync();
                    response.Mensagem = "Dados atualizados com sucesso!";
                
            }
            catch (Exception ex)
            {
                response.Mensagem = "Erro ao atualizar a série: " + ex.Message;
                response.Status = false;
            }
            return response;
        }

    }
}
