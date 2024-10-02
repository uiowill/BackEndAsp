class Turma
{
    public int Codigo {get;set;}
    public string Curso {get;set;}
    public string Turno {get;set;}

    public Turma( int codigo,string curso,string turno){
       this.Codigo = codigo;
       this.Curso = curso;
       this.Turno = turno;
       
    }
}