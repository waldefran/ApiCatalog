﻿using ApiCatalog.Context;
using ApiCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalog.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _context.Categorias.ToList();
        if (categorias is null)
            return NotFound("Categorias não encontradas");
        return categorias;
    }
    [HttpGet("{id:int}", Name = "GetCategoriaById")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        if (categoria is null)
            return NotFound("Categoria não encontrada");
        return categoria;
    }
    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        var categorias = _context.Categorias.Include(c => c.Produtos).ToList();
        if (categorias is null)
            return NotFound("Categorias não encontradas");
        return categorias;
    }

    [HttpPost]
    public ActionResult<Categoria> Post(Categoria categoria)
    {
        if (categoria is null)
            return BadRequest("Categoria não pode ser nula");
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
        return new CreatedAtRouteResult("GetCategoriaById", new { id = categoria.CategoriaId }, categoria);
    }
    [HttpPut("{id:int}")]
    public ActionResult<Categoria> Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
            return BadRequest("Id da categoria não confere");
        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(categoria);
    }
    [HttpDelete("{id:int}")]
    public ActionResult<Categoria> Delete(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        if (categoria is null)
            return NotFound("Categoria não encontrada");
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        return categoria;
    }
}
