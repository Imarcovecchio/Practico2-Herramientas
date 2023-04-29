public class CursosEstudiantes{
    public int EstudiantesId { get; set; }
    public virtual Estudiante Estudiante { get; set; }

    public int CursoId { get; set; }
    public virtual Curso Curso{get;set;}
}