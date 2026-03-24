using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace entregadia30_pi
{
    public class Banco
    {
        public static string Conexao = "Data Source=marketplace.db";

        public static void Inicializar()
        {
            if (!File.Exists("marketplace.db"))
            {
                using (File.Create("marketplace.db")) { }
            }

            using (var conn = new SqliteConnection(Conexao))
            {
                conn.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS produtos (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    titulo TEXT NOT NULL,
                    descricao TEXT NOT NULL,
                    categoria TEXT NOT NULL,
                    marca TEXT NOT NULL,
                    moq INTEGER NOT NULL,
                    regiao TEXT NOT NULL,
                    preco REAL NOT NULL
                );";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InserirProdutosComida()
        {
            using (var conn = new SqliteConnection(Conexao))
            {
                conn.Open();

                string verificarSql = "SELECT COUNT(*) FROM produtos;";
                using (var verificarCmd = new SqliteCommand(verificarSql, conn))
                {
                    long quantidade = (long)verificarCmd.ExecuteScalar();

                    if (quantidade > 0)
                    {
                        Console.WriteLine("Produtos já existem no banco. Seed ignorado.");
                        return;
                    }
                }

                string sql = @"
                INSERT INTO produtos (titulo, descricao, categoria, marca, moq, regiao, preco) VALUES
                ('Arroz Integral 1kg', 'Arroz integral orgânico', 'Alimentos', 'VitaGrain', 5, 'SP', 12.90),
                ('Feijão Carioca 1kg', 'Feijão selecionado', 'Alimentos', 'SaborNatural', 5, 'RJ', 10.50),
                ('Macarrão Integral 500g', 'Macarrão saudável', 'Alimentos', 'MassaBoa', 10, 'MG', 8.90),
                ('Azeite Extra Virgem 500ml', 'Azeite de oliva premium', 'Alimentos', 'OlivaDourada', 3, 'SP', 29.90),
                ('Molho de Tomate 340g', 'Molho artesanal', 'Alimentos', 'Tomateiro', 8, 'PR', 6.50),
                ('Queijo Mussarela 1kg', 'Queijo fresco', 'Laticínios', 'QueijosBrasil', 2, 'RS', 35.90),
                ('Leite Integral 1L', 'Leite puro fresco', 'Laticínios', 'LeiteNobre', 6, 'SP', 4.90),
                ('Iogurte Natural 500g', 'Iogurte saudável', 'Laticínios', 'BioYog', 4, 'RJ', 7.90),
                ('Manteiga 200g', 'Manteiga sem sal', 'Laticínios', 'VilaManteiga', 5, 'MG', 9.50),
                ('Pão Integral 500g', 'Pão saudável', 'Padaria', 'PadocaFit', 10, 'SP', 6.90),
                ('Biscoito Integral 200g', 'Biscoito de aveia', 'Alimentos', 'AveiaDoce', 12, 'PR', 5.90),
                ('Chocolate 70% Cacau 100g', 'Chocolate amargo', 'Confeitaria', 'CacauPremium', 8, 'SP', 9.90),
                ('Café Torrado 500g', 'Café gourmet', 'Bebidas', 'CafeBom', 6, 'MG', 19.90),
                ('Chá Verde 20 saquinhos', 'Chá natural', 'Bebidas', 'VerdeSaudavel', 10, 'RJ', 14.90),
                ('Suco de Laranja 1L', 'Suco natural', 'Bebidas', 'CitrusBrasil', 8, 'SP', 7.50),
                ('Açúcar Mascavo 1kg', 'Açúcar orgânico', 'Alimentos', 'DoceNatureza', 10, 'BA', 11.90),
                ('Farinha de Trigo 1kg', 'Farinha branca selecionada', 'Alimentos', 'TrigoBom', 15, 'SP', 4.90),
                ('Aveia em Flocos 500g', 'Aveia natural', 'Alimentos', 'AveiaDoce', 10, 'PR', 6.50),
                ('Granola 500g', 'Granola saudável', 'Alimentos', 'VitaGrain', 5, 'SP', 18.90),
                ('Leite de Amêndoas 1L', 'Bebida vegetal', 'Bebidas', 'AlmondLife', 6, 'RJ', 12.90);";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Produtos iniciais inseridos com sucesso.");
            }
        }
    }
}
