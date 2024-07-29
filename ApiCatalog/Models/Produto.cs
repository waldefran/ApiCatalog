using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalog.Models;

public class Produto
{
    public int ProdutoId { get; set; }
    [Required]
    [StringLength(150)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(1024)]
    public string? Descricao { get; set; }
    [Required]
    [Column(TypeName= "decimal(18,2)")]
    public decimal? Preco { get; set; }
    [StringLength(500)]
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}
