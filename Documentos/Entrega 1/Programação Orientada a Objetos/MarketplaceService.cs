using System;
using System.Collections.Generic;
using System.Linq;

namespace entregadia30_pi
{
    public class MarketplaceService
    {
        public List<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();
        public List<Comprador> Compradores { get; set; } = new List<Comprador>();
        public List<Administrador> Administradores { get; set; } = new List<Administrador>();
        public List<Anuncio> Anuncios { get; set; } = new List<Anuncio>();

        public void CadastrarFornecedor(Fornecedor fornecedor)
        {
            Fornecedores.Add(fornecedor);
            Console.WriteLine($"Fornecedor '{fornecedor.Nome}' cadastrado com sucesso.");
        }

        public void CadastrarComprador(Comprador comprador)
        {
            Compradores.Add(comprador);
            Console.WriteLine($"Comprador '{comprador.Nome}' cadastrado com sucesso.");
        }

        public void CadastrarAdministrador(Administrador admin)
        {
            Administradores.Add(admin);
            Console.WriteLine($"Administrador '{admin.Nome}' cadastrado com sucesso.");
        }

        public void AdicionarAnuncio(Fornecedor fornecedor, Anuncio anuncio)
        {
            fornecedor.CriarAnuncio(anuncio);
            Anuncios.Add(anuncio);

            Console.WriteLine($"Anúncio '{anuncio.Titulo}' adicionado ao marketplace.");
        }

        public void ListarTodosAnuncios()
        {
            Console.WriteLine("\n=== TODOS OS ANÚNCIOS ===");

            if (Anuncios.Count == 0)
            {
                Console.WriteLine("Nenhum anúncio cadastrado.");
                return;
            }

            foreach (var anuncio in Anuncios)
            {
                ExibirResumoAnuncio(anuncio);
            }
        }

        public void ListarAnunciosAtivos()
        {
            Console.WriteLine("\n=== ANÚNCIOS ATIVOS ===");

            var ativos = Anuncios.Where(a => a.Status == "Ativo").ToList();

            if (ativos.Count == 0)
            {
                Console.WriteLine("Nenhum anúncio ativo.");
                return;
            }

            foreach (var anuncio in ativos)
            {
                ExibirResumoAnuncio(anuncio);
            }
        }

        public void BuscarPorCategoria(string categoria)
        {
            Console.WriteLine($"\n=== BUSCA POR CATEGORIA: {categoria} ===");

            var resultados = Anuncios
                .Where(a => a.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum anúncio encontrado para essa categoria.");
                return;
            }

            foreach (var anuncio in resultados)
            {
                ExibirResumoAnuncio(anuncio);
            }
        }

        public void BuscarPorRegiao(string regiao)
        {
            Console.WriteLine($"\n=== BUSCA POR REGIÃO: {regiao} ===");

            var resultados = Anuncios
                .Where(a => a.RegiaoAtendida.Equals(regiao, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum anúncio encontrado para essa região.");
                return;
            }

            foreach (var anuncio in resultados)
            {
                ExibirResumoAnuncio(anuncio);
            }
        }

        public void BuscarPorStatus(string status)
        {
            Console.WriteLine($"\n=== BUSCA POR STATUS: {status} ===");

            var resultados = Anuncios
                .Where(a => a.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum anúncio encontrado com esse status.");
                return;
            }

            foreach (var anuncio in resultados)
            {
                ExibirResumoAnuncio(anuncio);
            }
        }

        public void ExibirDetalhesAnuncio(Anuncio anuncio)
        {
            Console.WriteLine("\n=== DETALHES DO ANÚNCIO ===");
            Console.WriteLine($"Título: {anuncio.Titulo}");
            Console.WriteLine($"Descrição: {anuncio.Descricao}");
            Console.WriteLine($"Categoria: {anuncio.Categoria}");
            Console.WriteLine($"Marca: {anuncio.Marca}");
            Console.WriteLine($"MOQ: {anuncio.MOQ}");
            Console.WriteLine($"Região Atendida: {anuncio.RegiaoAtendida}");
            Console.WriteLine($"Preço Unitário: R$ {anuncio.PrecoUnitario:F2}");
            Console.WriteLine($"Unidade: {anuncio.UnidadeMedida}");
            Console.WriteLine($"Status: {anuncio.Status}");
            Console.WriteLine($"Data de Criação: {anuncio.DataCriacao:dd/MM/yyyy HH:mm}");

            if (anuncio.Status == "Reprovado" && !string.IsNullOrWhiteSpace(anuncio.MotivoReprovacao))
            {
                Console.WriteLine($"Motivo da Reprovação: {anuncio.MotivoReprovacao}");
            }

            Console.WriteLine($"Média de Avaliações: {anuncio.CalcularMediaAvaliacoes():F1}");
            Console.WriteLine($"Quantidade de Avaliações: {anuncio.Avaliacoes.Count}");
        }

        private void ExibirResumoAnuncio(Anuncio anuncio)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Título: {anuncio.Titulo}");
            Console.WriteLine($"Categoria: {anuncio.Categoria}");
            Console.WriteLine($"Região: {anuncio.RegiaoAtendida}");
            Console.WriteLine($"Preço: R$ {anuncio.PrecoUnitario:F2}/{anuncio.UnidadeMedida}");
            Console.WriteLine($"MOQ: {anuncio.MOQ}");
            Console.WriteLine($"Status: {anuncio.Status}");
            Console.WriteLine($"Média Avaliações: {anuncio.CalcularMediaAvaliacoes():F1}");
        }
    }
}