using System.Text.Json.Serialization;

namespace APISeries.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; } 
        [JsonIgnore]
        public ICollection<SeriesModel> Series { get; set; }    
    }
}
