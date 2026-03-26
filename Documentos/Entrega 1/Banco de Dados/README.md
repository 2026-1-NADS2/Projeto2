# Documentação de Índices no Banco de Dados — Projeto Kiosk

### Integrantes:  Danilo Almeida, Davi Bigotto, Katiely Silva, Laura Pelizzer, Matheus Quio.

![PHOTO-2026-03-12-23-22-06](https://github.com/user-attachments/assets/6286ae0d-9698-4af5-bb1e-5cbff3c1610d)














### Introdução

No banco de dados do projeto Kiosk, foram utilizados índices para melhorar a performance das consultas feitas no sistema.
Como a plataforma possui várias tabelas relacionadas, como fornecedores, lojistas, produtos, pedidos e itens do pedido, os índices ajudam a tornar as buscas mais rápidas, principalmente quando há relacionamento entre tabelas.

### Índices automáticos

Alguns índices já são criados automaticamente pelo PostgreSQL quando usamos PRIMARY KEY e UNIQUE.

### Primary Key
As chaves primárias de cada tabela já possuem índice automático, por exemplo:
id_fornecedor
id_lojista
id_produto
id_pedido
id_item_pedido

Isso ajuda porque cada registro pode ser encontrado rapidamente pelo seu identificador.

### Campos UNIQUE
Os campos cnpj e email, nas tabelas de fornecedores e lojistas, também geram índice automático.
Isso é importante porque esses dados não podem se repetir e também podem ser usados em login ou validação de cadastro.

### Índices criados manualmente

Além dos índices automáticos, também é importante criar índices em alguns campos que são chave estrangeira, porque o PostgreSQL não faz isso sozinho.

### Índice em produtos

* __CREATE INDEX idx_produtos_fornecedor
ON produtos(id_fornecedor);__

Esse índice melhora consultas onde precisamos buscar todos os produtos de um fornecedor.

Exemplo:
SELECT * FROM produtos WHERE id_fornecedor = 1;

### Índice em pedidos

* __CREATE INDEX idx_pedidos_lojista
ON pedidos(id_lojista);__

Esse índice ajuda quando precisamos buscar os pedidos feitos por um lojista.

### Índice em itens do pedido

* __CREATE INDEX idx_itens_pedido_pedido
ON itens_pedido(id_pedido);__

Esse índice facilita a busca dos itens que pertencem a um pedido.

### Índice em produto dentro de itens_pedido

* __CREATE INDEX idx_itens_pedido_produto
ON itens_pedido(id_produto);__

Esse índice melhora consultas que relacionam produtos com pedidos.

### Justificativa geral

Os índices foram criados nos campos que serão mais usados em consultas e relacionamentos.
Isso ajuda a evitar que o banco precise percorrer toda a tabela sempre que uma busca for feita.
Mesmo sendo um MVP, já é importante pensar em performance, principalmente porque a plataforma pode crescer e ter muitos registros no futuro.

### Conclusão

A criação dos índices ajuda o banco de dados do Kiosk a funcionar de forma mais eficiente, deixando as consultas mais rápidas e melhorando o desempenho geral do sistema.

