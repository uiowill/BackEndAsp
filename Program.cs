using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

List<Cliente> clientes = new List<Cliente>();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Senac aula backend ***2525");
app.MapGet("/", HelloWorld);
app.MapGet("/produtos",  ListarProdutos);
app.MapGet("/pratos", GetPratos);
app.MapGet("/clientes", GetClientes);
app.MapPost("/cliente", PostCliente);
app.MapGet("/cliente/{id}", GetCliente);
app.MapDelete("/cliente/{id}", DeleteCliente);
app.MapPut("/cliente", UpdateCliente);

app.MapGet("/turmas", GetTodasTurmas);
app.MapGet("/login", Login);

app.Run();

void Login(){
    BancoDados bancoDados = new BancoDados();
    string email = "everton@se.senac.com.br";
    string senha = "1234";
    string hashSenha = Utils.GerarHash(senha);
    Console.WriteLine(hashSenha);
    string? token = bancoDados.Login(email, hashSenha);
  
    if (token != null)
    {
       bancoDados.SalvarToken(email,token);
    }
    else{
         Console.WriteLine("Usuario INCORRETO");
    }
}
void GetTodasTurmas(){
    // List<Turma> turmas = bancoDados.GetTodasTurmas();
    //Console.WriteLine($"Quantidade de Turmas: {turmas.Count}");
}    
//endpoint
//Api - application program interface
//Minimal API
//estamos desenvolvendo uma web api - (api rest ,soap api, graphpl)
//GerarJson();
app.Run();

//escrever um arquivo primeiro parametro é oq eu quero salvar e osegundo o arquivo (path : caminho do arquivo ),, CurrentDirectory(pasta atual)
//serializar para salvar,ler o arquivo no maui vamos deserializar
IResult DeleteCliente(int id){
    for (int i = 0; i < clientes.Count; i++)
    {
        if (id == clientes[i].Id)
        {
            clientes.RemoveAt(i);
            return TypedResults.NoContent();    
        }
    }
    return TypedResults.NotFound();
}
IResult UpdateCliente(Cliente clienteAtualizado){
    for (int i = 0; i < clientes.Count; i++)
    {
        if (clienteAtualizado.Id == clientes[i].Id)
        {
            clientes[i] = clienteAtualizado;
            return TypedResults.NoContent();
        }
    }
    return TypedResults.NotFound();
}

IResult PostCliente(Cliente cliente){
    clientes.Add(cliente);
    
    return TypedResults.Created(cliente.ToString());
}
IResult GetCliente(int id){
    Cliente? cliente = null;
    foreach (Cliente c in clientes)
    {
        if (c.Id == id)
        {
            cliente = c;
            break;
        }
    }
    if (cliente != null)
    {
        return TypedResults.Ok(cliente);
    }

    return TypedResults.NotFound();
}
IResult GetClientes(){
    return TypedResults.Ok(clientes);
}
string GetPratos(){
    string json = GerarJson();
    return json;
}

string GerarJson()
{
    List<Prato> pratos = new List<Prato>{
        new Prato(0,"Prato 01", 2,400, new List<string>{"Ingredientes01", "Ingredientes02"}),
        new Prato(1,"Prato 02", 4,800, new List<string>{"Ingredientes01", "Ingredientes02"}),
    };
    string caminho = $"{Environment.CurrentDirectory}\\json\\pratos_auto.json";
    string json = JsonSerializer.Serialize(pratos, new JsonSerializerOptions(){WriteIndented=true});
    File.WriteAllText(caminho,json); //comando que faz salvar em disco

    return json;
}

List<string>ListarProdutos(){
    return [];
}

string HelloWorld(){
    return "Hello World";
}
