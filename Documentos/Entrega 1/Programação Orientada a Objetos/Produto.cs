namespace entregadia30_pi
{
    public class Produto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string Marca { get; set; } = "";
        public int MOQ { get; set; }
        public string Regiao { get; set; } = "";
        public decimal Preco { get; set; }
    }
}