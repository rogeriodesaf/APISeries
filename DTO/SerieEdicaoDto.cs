using APISeries.Vinculo;

namespace APISeries.DTO
{
    public class SerieEdicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

       public  CategoriaVinculoDto Categoria { get; set; }
    }
}
