public class Estudiante{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateTime FechaDeNacimiento{get;set;}
    public DateTime FechaDeAlta{get;set;}

    public int EstatusId { get; set; }
    public virtual Estatus Estatus {get;set;}

    public virtual List<CursosEstudiantes> CursosEstudiantes { get; set; }
}