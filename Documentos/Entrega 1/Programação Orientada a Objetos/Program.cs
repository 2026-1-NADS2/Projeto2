using System;

namespace entregadia30_pi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inicialização do banco
            Banco.Inicializar();
            Banco.InserirProdutosComida();

            // Instancia o sistema principal
            MarketplaceService sistema = new MarketplaceService();

            // Criação dos usuários
            Fornecedor fornecedor = new Fornecedor
            {
                Nome = "Carlos Almeida",
                NomeEmpresa = "Mr Nut Distribuidora",
                Email = "contato@mrnut.com",
                CNPJ = "12.345.678/0001-99",
                Endereco = "São Paulo - SP",
                RegiaoAtendida = "SP"
            };

            Comprador comprador = new Comprador
            {
                Nome = "Mariana Costa",
                Empresa = "Mercado Central",
                Email = "compras@mercadocentral.com",
                CNPJ = "98.765.432/0001-11",
                Regiao = "SP",
                Segmento = "Mercado"
            };

            Administrador admin = new Administrador
            {
                Nome = "Admin Sistema",
                Email = "admin@marketplace.com"
            };

            // Cadastro dos usuários
            sistema.CadastrarFornecedor(fornecedor);
            sistema.CadastrarComprador(comprador);
            sistema.CadastrarAdministrador(admin);

            // Criação de anúncios
            Anuncio anuncio1 = new Anuncio
            {
                Titulo = "Castanha de Caju 1kg",
                Descricao = "Castanha de caju premium, ideal para revenda",
                Categoria = "Oleaginosas",
                Marca = "Mr Nut",
                MOQ = 10,
                RegiaoAtendida = "SP",
                PrecoUnitario = 38.90m,
                UnidadeMedida = "kg"
            };

            Anuncio anuncio2 = new Anuncio
            {
                Titulo = "Amêndoas Torradas 500g",
                Descricao = "Amêndoas selecionadas de alta qualidade",
                Categoria = "Oleaginosas",
                Marca = "Mr Nut",
                MOQ = 8,
                RegiaoAtendida = "RJ",
                PrecoUnitario = 27.50m,
                UnidadeMedida = "pacote"
            };

            sistema.AdicionarAnuncio(fornecedor, anuncio1);
            sistema.AdicionarAnuncio(fornecedor, anuncio2);

            // Admin aprova e reprova anúncios
            admin.AprovarAnuncio(anuncio1);
            admin.ReprovarAnuncio(anuncio2, "Descrição incompleta e falta de informações fiscais.");

            // Comprador interage
            comprador.FavoritarAnuncio(anuncio1);
            comprador.AvaliarAnuncio(anuncio1, 5, "Excelente produto e ótimo custo-benefício!");
            comprador.AvaliarAnuncio(anuncio1, 4, "Boa qualidade para compras em volume.");

            // Listagens e buscas
            sistema.ListarTodosAnuncios();
            sistema.ListarAnunciosAtivos();
            sistema.BuscarPorCategoria("Oleaginosas");
            sistema.BuscarPorRegiao("SP");
            sistema.BuscarPorStatus("Reprovado");

            // Exibir detalhes completos
            sistema.ExibirDetalhesAnuncio(anuncio1);
            sistema.ExibirDetalhesAnuncio(anuncio2);

            // Paginação do banco
            PaginarProdutosBanco(5);

            Console.WriteLine("\nSistema encerrado.");
        }

        static void PaginarProdutosBanco(int itensPorPagina)
        {
            int paginaAtual = 1;

            while (true)
            {
                Console.Clear();

                var produtos = ProdutoRepository.BuscarProdutos(paginaAtual, itensPorPagina);

                if (produtos.Count == 0)
                {
                    Console.WriteLine("Fim dos produtos!");
                    Console.WriteLine("Pressione qualquer tecla para sair...");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine($"=== PRODUTOS DO BANCO | Página {paginaAtual} ===\n");

                foreach (var produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.Id}");
                    Console.WriteLine($"Produto: {produto.Titulo}");
                    Console.WriteLine($"Descrição: {produto.Descricao}");
                    Console.WriteLine($"Categoria: {produto.Categoria}");
                    Console.WriteLine($"Marca: {produto.Marca}");
                    Console.WriteLine($"MOQ: {produto.MOQ}");
                    Console.WriteLine($"Região: {produto.Regiao}");
                    Console.WriteLine($"Preço: R$ {produto.Preco:F2}");
                    Console.WriteLine("------------------------------------");
                }

                Console.WriteLine("\n[D] Próxima página | [A] Página anterior | [S] Sair");

                var tecla = Console.ReadKey().Key;

                if (tecla == ConsoleKey.D)
                    paginaAtual++;

                if (tecla == ConsoleKey.A && paginaAtual > 1)
                    paginaAtual--;

                if (tecla == ConsoleKey.S)
                    break;
            }
        }
    }
}
