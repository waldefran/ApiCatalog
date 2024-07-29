using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalog.Models;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(150)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    [Required]
    [StringLength(1024)]
    public string? Descricao { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
