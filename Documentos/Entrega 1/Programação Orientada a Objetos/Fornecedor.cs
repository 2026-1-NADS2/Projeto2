using System;
using System.Collections.Generic;

namespace entregadia30_pi { 
    public class Fornecedor : Usuario
    {
        public string NomeEmpresa { get; set; } = "";
        public string CNPJ { get; set; } = "";
        public string Endereco { get; set; } = "";
        public string RegiaoAtendida { get; set; } = "";

        public List<Anuncio> Anuncios { get; set; } = new List<Anuncio>();

        public void CriarAnuncio(Anuncio anuncio)
        {
            anuncio.Status = "Pendente";
            anuncio.DataCriacao = DateTime.Now;
            Anuncios.Add(anuncio);

            Console.WriteLine($"Anúncio '{anuncio.Titulo}' criado com status Pendente.");
        }

        public void EditarAnuncio(Anuncio anuncio, string novoTitulo, string novaDescricao, decimal novoPreco, int novoMOQ)
        {
            anuncio.Titulo = novoTitulo;
            anuncio.Descricao = novaDescricao;
            anuncio.PrecoUnitario = novoPreco;
            anuncio.MOQ = novoMOQ;
            anuncio.Status = "Pendente"; // ao editar, volta para revisão

            Console.WriteLine($"Anúncio '{anuncio.Titulo}' editado e retornou para revisão.");
        }

        public void RemoverAnuncio(Anuncio anuncio)
        {
            Anuncios.Remove(anuncio);
            Console.WriteLine($"Anúncio '{anuncio.Titulo}' removido.");
        }
    }
}