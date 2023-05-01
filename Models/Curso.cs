public class Curso{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string  Descripcion { get; set; }
    public DateTime FechaDeAlta { get; set; }

    public int EstatusId { get; set; }
    public virtual Estatus Estatus { get; set; }
    public int ProfesorId { get; set; }
    public virtual Profesor? Profesor {get;set;}

    public virtual List<CursosEstudiantes> CursosEstudiantes { get; set; }
}