namespace GestorDescargasV1.Models
{
    public class Descarga
    {
        public int idDescargas { get; set; }
        public int idPrograma { get; set; }
        public string nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string estado { get; set; }
    }
}
