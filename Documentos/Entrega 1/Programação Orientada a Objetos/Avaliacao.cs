using System;

namespace entregadia30_pi
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; } = "";
        public DateTime Data { get; set; } = DateTime.Now;
        public string Autor { get; set; } = "";
    }
}