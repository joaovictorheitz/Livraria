using Livraria.Classes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;

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
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=root;database=livraria");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                ApplicationDbInitializer.Initialize(context);



                //Adiciona uma boa quantidade de categorias para teste
                /*List<string> categorias = new List<string>();
                categorias.Add("Ficcção científica");categorias.Add("Fantasia");categorias.Add("Romance");categorias.Add("Suspensa");categorias.Add("Mistério");categorias.Add("História");categorias.Add("Biografia");categorias.Add("Autoajuda");categorias.Add("Negócios");categorias.Add("Política");categorias.Add("Ciência");categorias.Add("Tecnologia");categorias.Add("Artes");categorias.Add("Esportes");categorias.Add("Culinária");categorias.Add("Viagens");categorias.Add("Filosofia");categorias.Add("Religião");categorias.Add("Educação");categorias.Add("Literatura Clássica");

                foreach (string categoria in categorias)
                {
                    var category = new Categorias()
                    {
                        Nome = categoria
                    };
                    
                    context.Categorias.Add(category); context.SaveChanges();

                    Console.WriteLine("Adicionado com sucesso a categoria: " +  category.Nome);
                }*/

                //Adiciona uma boa quantidade de autores para teste
                /*List<string> autores = new List<string>();
                autores.Add("Agatha Christie");autores.Add("Machado de Assis");autores.Add("Jorge Amado");autores.Add("Stephen King");autores.Add("Isaac Asimov");autores.Add("J.K. Rowling");autores.Add("Dan Brown");autores.Add("J.R.R. Tolkien");autores.Add("John Grisham");autores.Add("Gabriel García Márquez");autores.Add("George Orwell");autores.Add("Harper Lee");autores.Add("Mark Twain");autores.Add("Ernest Hemingway");autores.Add("Virginia Woolf");autores.Add("Emily Bronte");autores.Add("Jane Austen");autores.Add("Fiodor Dostoievski");autores.Add("Fiódor Dostoiévski");autores.Add("William Shakespeare");

                foreach (string autor in autores)
                {
                    var Autor = new Autor() { Nome = autor };

                    context.Autor.Add(Autor); context.SaveChanges();

                    Console.WriteLine("Adicionad com sucesso o autor: " + Autor.Nome);
                }*/

                //Adiciona uma boa quantidade de editoras para teste
                /*List<string> editoras = new List<string>();
                List<string> enderecos = new List<string>();editoras.Add("Companhia das Letras");enderecos.Add("Rua Bandeira Paulista, 702 - Itaim Bibi, São Paulo - SP");editoras.Add("Editora Intrínseca");enderecos.Add("Rua Marquês de São Vicente, 99 - 3º andar - Gávea, Rio de Janeiro - RJ");editoras.Add("Editora Record");enderecos.Add("Rua Argentina, 171 - São Cristóvão, Rio de Janeiro - RJ");editoras.Add("Editora Rocco");enderecos.Add("Rua Nova Jerusalém, 345 - Bonsucesso, Rio de Janeiro - RJ");editoras.Add("Editora Sextante");enderecos.Add("Av. Brigadeiro Faria Lima, 1993 - Pinheiros, São Paulo - SP");editoras.Add("Editora Globo");enderecos.Add("Rua do Russel, 300 - Glória, Rio de Janeiro - RJ");editoras.Add("Editora Abril");enderecos.Add("Av. das Nações Unidas, 7221 - Pinheiros, São Paulo - SP");editoras.Add("Leya");enderecos.Add("Av. das Américas, 500 - Bloco 14, Sala 108 - Barra da Tijuca, Rio de Janeiro - RJ");editoras.Add("Editora Moderna");enderecos.Add("Rua Haddock Lobo, 595 - Cerqueira César, São Paulo - SP");editoras.Add("Editora Saraiva");enderecos.Add("Rua Henrique Schaumann, 270 - Pinheiros, São Paulo - SP");

                for (int i = 0; i < editoras.Count; i++)
                {
                    var editora = new Editora() { Nome = editoras[i], Endereco = enderecos[i] };

                    context.Editora.Add(editora); context.SaveChanges();

                    Console.WriteLine("Adicionado com sucesso a editora: " + editora.Nome);
                }*/

                //Adiciona uma boa quantidade de livros para teste
                /*List<string> nome = new List<string>();
                List<int> categoria = new List<int>();
                List<int> autor = new List<int>();
                List<int> editora = new List<int>();
                nome.Add("A Hora da Estrela");categoria.Add(3);autor.Add(15);editora.Add(5);nome.Add("A Guerra dos Tronos");categoria.Add(2);autor.Add(21);editora.Add(2);nome.Add("O Senhor dos Anéis");categoria.Add(2);autor.Add(23);editora.Add(2);nome.Add("O Processo");categoria.Add(3);autor.Add(15);editora.Add(1);nome.Add("Dom Casmurro");categoria.Add(3);autor.Add(15);editora.Add(2);nome.Add("1984");categoria.Add(1);autor.Add(26);editora.Add(4);nome.Add("A Arte da Guerra");categoria.Add(9);autor.Add(35);editora.Add(7);nome.Add("O Conde de Monte Cristo");categoria.Add(3);autor.Add(32);editora.Add(3);nome.Add("O Nome da Rosa");categoria.Add(5);autor.Add(25);editora.Add(1);nome.Add("O Amor nos Tempos do Cólera");categoria.Add(3);autor.Add(25);editora.Add(4);nome.Add("A Divina Comédia");categoria.Add(20);autor.Add(15);editora.Add(6);nome.Add("O Iluminado");categoria.Add(4);autor.Add(19);editora.Add(4);nome.Add("Guerra e Paz");categoria.Add(6);autor.Add(33);editora.Add(8);nome.Add("Cem Anos de Solidão");categoria.Add(3);autor.Add(25);editora.Add(9);nome.Add("O Sol é para Todos");categoria.Add(5);autor.Add(27);editora.Add(10);nome.Add("O Pequeno Príncipe");categoria.Add(3);autor.Add(35);editora.Add(3);nome.Add("O Vermelho e o Negro");categoria.Add(3);autor.Add(35);editora.Add(1);nome.Add("A Revolução dos Bichos");categoria.Add(1);autor.Add(26);editora.Add(4);nome.Add("O Grande Gatsby");categoria.Add(3);autor.Add(35);editora.Add(6);nome.Add("Crime e Castigo");categoria.Add(4);autor.Add(33);editora.Add(2);

                for (int i = 0; i < nome.Count; i++)
                {
                    var livro = new Livro() { Nome = nome[i], CategoriaId = categoria[i], AutorId = autor[i], EditoraId = editora[i] };
                    
                    context.Livro.Add(livro); 
                    context.SaveChanges();

                    Console.WriteLine("Adicionado com sucesso o livro: " + livro.Nome);
                }*/
                
                //Adiciona uma boa quantidade de clientes para teste
                /*List<string> nomeCliente = new List<string>();
                List<string> emailCliente = new List<string>();
                List<string> enderecoCliente = new List<string>();
                nomeCliente.Add("João Silva"); emailCliente.Add("joao.silva@email.com"); enderecoCliente.Add("Rua A, 123 - Centro");nomeCliente.Add("Maria Santos"); emailCliente.Add("maria.santos@email.com"); enderecoCliente.Add("Av. B, 456 - Jardim");nomeCliente.Add("Pedro Oliveira"); emailCliente.Add("pedro.oliveira@email.com"); enderecoCliente.Add("Rua C, 789 - Vila");nomeCliente.Add("Ana Pereira"); emailCliente.Add("ana.pereira@email.com"); enderecoCliente.Add("Av. D, 321 - Praia");nomeCliente.Add("Lucas Souza"); emailCliente.Add("lucas.souza@email.com"); enderecoCliente.Add("Rua E, 654 - Centro");nomeCliente.Add("Luana Santos"); emailCliente.Add("luana.santos@email.com"); enderecoCliente.Add("Av. F, 987 - Vila");nomeCliente.Add("Eduardo Castro"); emailCliente.Add("eduardo.castro@email.com"); enderecoCliente.Add("Rua G, 246 - Praia");nomeCliente.Add("Fernanda Lima"); emailCliente.Add("fernanda.lima@email.com"); enderecoCliente.Add("Av. H, 135 - Jardim");nomeCliente.Add("Rafaela Costa"); emailCliente.Add("rafaela.costa@email.com"); enderecoCliente.Add("Rua I, 864 - Vila");nomeCliente.Add("Gustavo Almeida"); emailCliente.Add("gustavo.almeida@email.com"); enderecoCliente.Add("Av. J, 753 - Centro");

                for (int i = 0; i < nomeCliente.Count; i++)
                {
                    var cliente = new Cliente() { Nome = nomeCliente[i], Email = emailCliente[i], Endereco = enderecoCliente[i] };

                    context.Cliente.Add(cliente); context.SaveChanges();

                    Console.WriteLine("Cliente cadastrado: " + cliente.Nome);
                }*/
            }
        }
    }
}