class Prato{
    public int id {get;set;}

    public string Nome {get ; set;}
    
    public int porcao {get;set;}

    public int peso {get ; set;}

    public List<string> Igredientes {get; set;}

    public Prato(int id, string Nome, int porcao, int peso, List<string> Igredientes){
        this.id = id;
        this.Nome = Nome;
        this.porcao =  porcao;
        this.peso = peso;
        this.Igredientes = Igredientes;
    }

}