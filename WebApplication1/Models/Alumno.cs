namespace GestionExpedientes.Models
{
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Grado { get; set; }

        public ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
    }
}