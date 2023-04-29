public class Profesor{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido {get;set;}
    public int EstatusId{get;set;}
    public virtual Estatus Estatus{get;set;}
    public virtual List<Curso> Cursos{get;set;}

}