using ApiCatalog.Context;
using ApiCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalog.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.ToList();
        if(produtos is null)
            return NotFound("Produtos não encontrados");
        return produtos;
    }
    [HttpGet("{id:int}",Name ="GetById")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId ==id);
        if (produto is null)
            return NotFound("Produto não encontrado");
        return produto;
    }
    [HttpPost]
    public ActionResult<Produto> Post(Produto produto)
    {
        if (produto is null)
            return BadRequest("Produto não pode ser nulo");
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return new CreatedAtRouteResult("GetById", new { id = produto.ProdutoId }, produto);
    }
    [HttpPut("{id:int}")]
    public ActionResult<Produto> Put(int id, Produto produto)
    {
        if (id != produto.ProdutoId)
            return BadRequest("Id do produto não confere");
        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(produto);
    }
    [HttpDelete("{id:int}")]
    public ActionResult<Produto> Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        if (produto is null)
            return NotFound("Produto não encontrado");
        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return produto;
    }
}
