# Livraria

Esse repositório foi feito com o objetivo de praticar conexão com mySql utilizando Entity Framework

Portanto nele foi criado a simulação de uma database de uma livraria, contendo: autor, categoria, cliente, editora, livro e pedido

# Criação de Objetos
Exemplo:
```CS
var MachadoDeAssis = new Autor() { Nome = "Machado de Assis" };

context.Autor.Add(MachadoDeAssis); context.SaveChanges();
```

Também podendo interagir com outros itens a ser criados
Exemplo:
```CS
var Livro = new Livro() { AutorId = MachadoDeAssis.Id, ... }
```

Ou utilizar um já presente no banco de dados
Exemplo
```CS
//Autor_ID é basicamente um SELECT * FROM [table] WHERE Nome = {nome}
var Livro = new Livro() { AutorId = Autor_ID(context, "Machado de Assis"), ... }
```
# How to use

Após clonar o repositório, será necessário a criação da database conforme está no repositório a database exportada.

Alterar conexão com mySql conforme necessário, exemplo:
```CS
optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=root;database=livraria");
```
