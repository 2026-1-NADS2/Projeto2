using System;
using System.Collections.Generic;

namespace entregadia30_pi
{
    public class Comprador : Usuario
    {
        public string Empresa { get; set; } = "";
        public string CNPJ { get; set; } = "";
        public string Regiao { get; set; } = "";
        public string Segmento { get; set; } = "";

        public List<Anuncio> Favoritos { get; set; } = new List<Anuncio>();

        public void FavoritarAnuncio(Anuncio anuncio)
        {
            if (!Favoritos.Contains(anuncio))
            {
                Favoritos.Add(anuncio);
                Console.WriteLine($"Anúncio '{anuncio.Titulo}' favoritado.");
            }
            else
            {
                Console.WriteLine($"O anúncio '{anuncio.Titulo}' já está nos favoritos.");
            }
        }

        public void AvaliarAnuncio(Anuncio anuncio, int nota, string comentario)
        {
            if (nota < 1 || nota > 5)
            {
                Console.WriteLine("A nota deve estar entre 1 e 5.");
                return;
            }

            Avaliacao avaliacao = new Avaliacao
            {
                Nota = nota,
                Comentario = comentario,
                Data = DateTime.Now,
                Autor = Nome
            };

            anuncio.Avaliacoes.Add(avaliacao);
            Console.WriteLine($"Anúncio '{anuncio.Titulo}' avaliado com nota {nota}.");
        }
    }
}
