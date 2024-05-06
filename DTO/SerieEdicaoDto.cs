using APISeries.Vinculo;

namespace APISeries.DTO
{
    public class SerieEdicaoDto
    {
        public int id { get; set; }
        public string Nome { get; set; }

        CategoriaVinculoDto Categoria { get; set; }
    }
}
