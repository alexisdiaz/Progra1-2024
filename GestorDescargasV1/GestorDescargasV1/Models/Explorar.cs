namespace GestorDescargasV1.Models
{
    public class Explorar
    {
        public int idPrograma { get; set; }
        public string nombre { get; set; }
        public string version { get; set; }
        public  string url { get; set; }
        public  string peso { get; set; }
        public byte[]? foto { get; set; }

    }
}
