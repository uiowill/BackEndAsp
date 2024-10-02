
using System.Data;
using MySql.Data.MySqlClient;

class BancoDados
{
    string stringConexao = "server=localhost;uid=root;pwd=1234;database=Mysql";
    
    public string? Login(string email, string senha){
        string selectUsuario = $"SELECT * FROM sakila.usuarios WHERE email =  \"{email}\""; // ou \"everton@se.senac.com.br\"
        MySqlConnection conexao;
        try
        {
            conexao = new MySqlConnection(stringConexao);
            conexao.Open();
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = selectUsuario;
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read()){
                string emailDB = reader.GetString("email");
                string senhaDB = reader.GetString("senha");

                //Console.WriteLine($"{emailDB} : {senhaDB}");
                if (senha == senhaDB)
                {
                    Random random = new Random();
                    int numero = random.Next(1000, 9999);
                    string token = Utils.GerarHash(numero.ToString());
                
                    return token;
                   
                } 
            }
        }
        catch(MySqlException ex){  //O try e o catch trata algum possivel erro 
            Console.WriteLine(ex);
        }
        return null;
    }

    public void SalvarToken(string email, string token){
        string updateUsuario = $"SELECT * FROM sakila.usuarios SET token =  \"{token}\" WHERE email = \"{email}\""; // ou \"everton@se.senac.com.br\"
        MySqlConnection conexao;
        try
        {
            conexao = new MySqlConnection(stringConexao);
            conexao.Open();
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = updateUsuario;
            comando.ExecuteReader();
        }    
        catch(MySqlException ex){  //O try e o catch trata algum possivel erro 
            Console.WriteLine(ex);
        }
    }
    public List<Turma> GetTodasTurmas()
    {
        string select = "select * from sakila.turmas";
        MySqlConnection conexao;
        List<Turma> turmas = new List<Turma>();

        try
        {
            conexao = new MySqlConnection(stringConexao);
            conexao.Open();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = select;
            MySqlDataReader reader = comando.ExecuteReader();
           // comando.ExecuteReader(); //executa no banco 
            while (reader.Read()) //ENQUANTO TEMA LGO PARA LER
            {
                int codigo = reader.GetInt32("codigo");
                string curso = reader.GetString("curso");
                string turno = reader.GetString("turno");

                //Console.WriteLine($"{codigo}: {curso} - {turno}");

                Turma turma = new Turma(codigo,curso,turno);
                turmas.Add(turma);
            }
        }
        catch(MySqlException ex){  //O try e o catch trata algum possivel erro 
            Console.WriteLine(ex);
        }
        return turmas;

    }
}