using Livraria.Classes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Livraria
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Autor>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Livro>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Categorias>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Editora>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Cliente>().Property(a => a.Id).ValueGeneratedOnAdd();

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
            static int Autor_ID(ApplicationDbContext context, string name)
            {
                try
                {
                    var query = context.Autor.FromSqlRaw($"SELECT * FROM autor WHERE Nome = '{name}'").ToList();

                    return query.FirstOrDefault(a => a.Nome == $"{name}")?.Id ?? 0;
                } catch
                {
                    return 0;
                }
            }
            static int Categorias_ID(ApplicationDbContext context, string categoria)
            {
                try
                {
                    var query = context.Autor.FromSqlRaw($"SELECT * FROM categorias WHERE Nome = '{categoria}'").ToList();

                    return query.FirstOrDefault(a => a.Nome == $"{categoria}")?.Id ?? 0;
                }
                catch
                {
                    return 0;
                }
            }
            static int Cliente_ID(ApplicationDbContext context, string name)
            {
                try
                {
                    var query = context.Autor.FromSqlRaw($"SELECT * FROM cliente WHERE Nome = '{name}'").ToList();

                    return query.FirstOrDefault(a => a.Nome == $"{name}")?.Id ?? 0;
                }
                catch
                {
                    return 0;
                }
            }
            static int Editora_ID(ApplicationDbContext context, string editora)
            {
                try
                {
                    var query = context.Autor.FromSqlRaw($"SELECT * FROM editora WHERE Nome = '{editora}'").ToList();

                    return query.FirstOrDefault(a => a.Nome == $"{editora}")?.Id ?? 0;
                }
                catch
                {
                    return 0;
                }
            }
            static int Livro(ApplicationDbContext context, string name)
            {
                try
                {
                    var query = context.Autor.FromSqlRaw($"SELECT * FROM livro WHERE Nome = '{name}'").ToList();

                    return query.FirstOrDefault(a => a.Nome == $"{name}")?.Id ?? 0;
                }
                catch
                {
                    return 0;
                }
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=root;database=livraria");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                ApplicationDbInitializer.Initialize(context);
            }
        }
    }
}