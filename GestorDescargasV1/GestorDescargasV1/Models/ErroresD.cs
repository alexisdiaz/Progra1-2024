namespace GestorDescargasV1.Models
{
    public class ErroresD
    {
        public int IdErrores { get; set; }
        public int idDescargas { get; set; }
        public string mensajeError { get; set; }
        public DateTime fechaError { get; set; }
    }
}
