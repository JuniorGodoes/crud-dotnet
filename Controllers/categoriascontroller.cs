using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapi.Data;
using todoapi.models;

namespace TodoApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class categoriascontroller : ControllerBase
{
    private readonly Datacontext _context;

    public categoriascontroller(Datacontext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Categorias>>> GetAll()
    {
        var Categoria = await _context.allCategorias.ToListAsync();
        return Ok(Categoria);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Categorias>> Getcategoria(int Id)
    {
        var categoria = await _context.allCategorias.FindAsync(Id);

        if(categoria is null)
        return NotFound("Categoria nao encontrada");

        return Ok(categoria);
    }
    

    [HttpPost]
    public async Task<ActionResult<List<Categorias>>> AddCategoria(Categorias Categoria)
    {
        _context.allCategorias.Add(Categoria);
        await _context.SaveChangesAsync();

        return Ok(await GetAll());
    }

    [HttpPut]
    public async Task<ActionResult<List<Categorias>>> Update(Categorias Categoria)
    {
        var velhacategoria = await _context.allCategorias.FindAsync(Categoria.Id);

        if(velhacategoria == null)
        return NotFound("Nao encontado");

        velhacategoria.Name = Categoria.Name;

        await _context.SaveChangesAsync();

        return Ok(await GetAll());
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<List<Categorias>>> Delete(int Id)
    {
        var categoriaproc = await _context.allCategorias.FindAsync(Id);

        if(categoriaproc == null)
        return NotFound("Nao encontrado.");

        _context.allCategorias.Remove(categoriaproc);
        await _context.SaveChangesAsync();

        return Ok(await GetAll());
    }

}