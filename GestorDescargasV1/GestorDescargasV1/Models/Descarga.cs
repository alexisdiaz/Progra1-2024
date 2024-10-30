namespace GestorDescargasV1.Models
{
    public class Descarga
    {
        public int idDescargas { get; set; }
        public int idPrograma { get; set; }
        public DateTime fechaDescarga { get; set; }
        public string estado { get; set; }
    }
}
