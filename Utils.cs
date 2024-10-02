using System.Security.Cryptography;
using System.Text;
class Utils
{
    public static string GerarHash(string text){
    //
    SHA256 algoritmoHash = SHA256.Create(); //PEGANDO UM OBJETO DESSE ALGORITMO
    Byte[] bytes = Encoding.UTF8.GetBytes(text);
    Byte[] hash = algoritmoHash.ComputeHash(bytes);
    string hashSenha = "";
    foreach (Byte caracter in hash)
    {
        hashSenha += caracter.ToString("x2");
    }
    return hashSenha;
}
}