namespace APISeries.Models
{
    public class SeriesModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public CategoriaModel Categoria { get; set; }
    }
}
