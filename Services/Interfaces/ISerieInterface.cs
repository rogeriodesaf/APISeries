using APISeries.DTO;
using APISeries.Models;

namespace APISeries.Services.Interfaces
{
    public interface ISerieInterface
    {

        public Task<ResponseModel<List<SeriesModel>>> getSeries();
        public Task<ResponseModel<SeriesModel>> getSeriesById(int id);
        public Task<ResponseModel<List<SeriesModel>>> getSeriesByIdCategory(int id);
        public Task<ResponseModel<List<SeriesModel>>> postSeries(SerieCriacaoDto serieCriacaoDto);
        public Task<ResponseModel<List<SeriesModel>>> putSeries(SerieEdicaoDto serieEdicaoDto);
        public Task<ResponseModel<List<SeriesModel>>> deleteSeries(int id);


    }
}
