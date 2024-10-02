using Microsoft.AspNetCore.Http.Features;

class Cliente{
    public int Id{ get;set;}
    public string Nome {get; set;}
    public string Email {get; set;}
    public bool Ativo {get; set;}
    public List<Item> Itens {get;set;}

    public Cliente(int Id, string Nome, string Email, bool ativo, List<Item> Itens){
        this.Id = Id;
        this.Nome = Nome;
        this.Email = Email;
        this.Itens = Itens;
        this.Ativo = Ativo;
    }
}

class Item{   
    
     public int Id{ get;set;}
    public string Nome {get; set;}
    public double Valor { get; set;}

    public Item(int Id, string Nome, double Valor){
            this.Id= Id;
            this.Nome = Nome;
            this.Valor = Valor;
    }
}