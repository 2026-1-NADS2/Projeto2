using System;
using System.Collections.Generic;

namespace entregadia30_pi
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string Marca { get; set; } = "";
        public int MOQ { get; set; }
        public string RegiaoAtendida { get; set; } = "";
        public string Status { get; set; } = "Pendente";
        public decimal PrecoUnitario { get; set; }
        public string UnidadeMedida { get; set; } = ""; // kg, caixa, pacote, litro
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string MotivoReprovacao { get; set; } = "";

        public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

        public double CalcularMediaAvaliacoes()
        {
            if (Avaliacoes.Count == 0)
                return 0;

            double soma = 0;
            foreach (var avaliacao in Avaliacoes)
            {
                soma += avaliacao.Nota;
            }

            return soma / Avaliacoes.Count;
        }
    }
}