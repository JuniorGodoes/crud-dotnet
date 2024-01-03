using Microsoft.EntityFrameworkCore;
using todoapi.models;

namespace todoapi.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {

        }

        public DbSet<Livros> allBooks { get; set; }

        public DbSet<Categorias> allCategorias { get; set; }
    }
}