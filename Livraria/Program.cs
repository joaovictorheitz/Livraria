using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Livraria
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Autor>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Livro>().Property(a => a.Id).ValueGeneratedOnAdd();
        }
        
        public class ApplicationDbInitializer
        {
            public static void Initialize(ApplicationDbContext context)
            {
                context.Database.EnsureCreated();
            }
        }

        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=root;database=livraria");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                ApplicationDbInitializer.Initialize(context);

                var MachadoDeAssis = new Autor()
                {
                    Nome = "Machado de Assis"
                };

                var DomCasmurro = new Livro()
                {
                    Nome = "Dom Casmurro",
                    AutorId = MachadoDeAssis.Id
                };

                context.Autor.Add(MachadoDeAssis);
                context.Livro.Add(DomCasmurro);

                context.SaveChanges();
            }
        }
    }
}