using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace entregadia30_pi
{
    public class ProdutoRepository
    {
        private static string conexao = Banco.Conexao;

        public static List<Produto> BuscarProdutos(int pagina, int tamanho)
        {
            List<Produto> lista = new List<Produto>();
            int offset = (pagina - 1) * tamanho;

            using (var conn = new SqliteConnection(conexao))
            {
                conn.Open();

                string sql = @"
                SELECT id, titulo, descricao, categoria, marca, moq, regiao, preco
                FROM produtos
                ORDER BY id
                LIMIT @limite OFFSET @offset;";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@limite", tamanho);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Titulo = reader["titulo"].ToString() ?? "",
                                Descricao = reader["descricao"].ToString() ?? "",
                                Categoria = reader["categoria"].ToString() ?? "",
                                Marca = reader["marca"].ToString() ?? "",
                                MOQ = Convert.ToInt32(reader["moq"]),
                                Regiao = reader["regiao"].ToString() ?? "",
                                Preco = Convert.ToDecimal(reader["preco"])
                            };

                            lista.Add(produto);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
