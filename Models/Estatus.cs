public class Estatus{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaDeAlta { get; set; }
    public virtual List<Profesor> Profesores{get;set;}
    public virtual List<Estudiante> Estudiantes{get;set;}
    public virtual List<Curso> Cursos{get;set;}
}