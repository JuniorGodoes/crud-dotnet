using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapi.Data;
using todoapi.models;

namespace TodoApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class livroscontroller : ControllerBase
{
    private readonly Datacontext _context;

    public livroscontroller(Datacontext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<List<Livros>>> GetAll()
    {
        var Livros = await _context.allBooks.ToListAsync();
        return Ok(Livros);
    }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<Livros>> Getlivro(int Id)
    {
        var livro = await _context.allBooks.FindAsync(Id);

        if(livro is null)
        return NotFound("Livro nao encontrado");

        return Ok(livro);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Livros>>> Addlivro(Livros livro)
    {
        _context.allBooks.Add(livro);
        await _context.SaveChangesAsync();

        return Ok(await GetAll());
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Livros>>> Updatelivro(Livros livro)
    {
        var dblivro = await _context.allBooks.FindAsync(livro.Id);

        if(dblivro == null)
        return NotFound("Livro nao encontrado");

        dblivro.Titulo = livro.Titulo;
        dblivro.Categorias = livro.Categorias;
        dblivro.Ano = livro.Ano;

        await _context.SaveChangesAsync();

        return Ok(await _context.allBooks.ToListAsync());
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult<List<Livros>>> Deletelivro(int Id)
    {
        var dblivro = await _context.allBooks.FindAsync(Id);

        if(dblivro == null)
        return NotFound("Livro nao encontrado");

        _context.allBooks.Remove(dblivro);
        await _context.SaveChangesAsync();

        return Ok(await _context.allBooks.ToListAsync());
    }


}