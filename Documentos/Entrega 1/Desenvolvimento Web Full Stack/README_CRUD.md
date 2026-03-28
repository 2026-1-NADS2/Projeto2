# README — API CRUD de Fornecedores (Node.js + MySQL)

## 1. Objetivo

Este projeto tem como objetivo implementar uma **API REST utilizando Node.js com Express**, conectada a um **banco de dados MySQL**, permitindo realizar as operações básicas de um CRUD.

O sistema permite gerenciar **fornecedores**, realizando:

* criação de fornecedores
* listagem de fornecedores
* busca de fornecedor por ID
* atualização de dados
* exclusão de registros

Todas as rotas podem ser testadas utilizando o **Postman**.

---

# 2. Tecnologias utilizadas

O projeto foi desenvolvido utilizando as seguintes tecnologias:

* **Node.js**
* **Express**
* **MySQL**
* **MySQL Workbench**
* **Postman**
* **dotenv**

---

# 3. Estrutura do projeto

A estrutura de arquivos do projeto é a seguinte:

```
SERVIDOR_BD_KIOSK
├── src
│   ├── app.js
│   ├── db.js
│   ├── db.test.js
│   ├── routes.js
│   └── server.js
│
├── .env
├── package.json
└── package-lock.json
└── KIOSKBD_MYSQL.sql
```

Cada arquivo possui uma função específica dentro da aplicação.

### app.js

Responsável por configurar o Express e registrar as rotas da API.

### server.js

Arquivo responsável por iniciar o servidor Node.js.

### db.js

Realiza a conexão com o banco de dados MySQL.

### routes.js

Define todas as rotas da API relacionadas ao CRUD de fornecedores.

### db.test.js

Arquivo utilizado para testes da conexão com o banco.

### KIOSKBD_MYSQL.sql

Script SQL responsável pela criação da base de dados e da tabela utilizada.

---

# 4. Configuração do Banco de Dados

O banco de dados foi desenvolvido utilizando **MySQL Workbench**.

## 4.1 Criar a base de dados

Abra o **MySQL Workbench** e execute o seguinte comando SQL:

```sql
CREATE DATABASE KIOSKBD;
```

Depois selecione o banco criado:

```sql
USE KIOSKBD;
```

---

## 4.2 Criar a tabela fornecedores

Execute o seguinte script SQL:

```sql
CREATE TABLE fornecedores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    razao_social VARCHAR(255),
    nome_fantasia VARCHAR(255),
    cnpj VARCHAR(20),
    email VARCHAR(255),
    telefone VARCHAR(20),
    senha VARCHAR(255),
    descricao TEXT,
    cidade VARCHAR(100),
    estado VARCHAR(50),
    cep VARCHAR(20)
);
```

---

## 4.3 Inserir dados na tabela

Para inserir registros manualmente no banco de dados:

```sql
INSERT INTO fornecedores
(razao_social, nome_fantasia, cnpj, email, telefone, senha, descricao, cidade, estado, cep)
VALUES
(
'Empresa Exemplo LTDA',
'Exemplo Alimentos',
'12.345.678/0001-90',
'contato@exemplo.com',
'11999999999',
'123456',
'Fornecedor de alimentos naturais',
'São Paulo',
'SP',
'01000-000'
);
```

---

## 4.4 Verificar se os dados foram salvos

Para visualizar os registros cadastrados:

```sql
SELECT * FROM fornecedores;
```

---

# 5. Configuração do arquivo .env

O projeto utiliza um arquivo `.env` para armazenar as configurações do banco de dados.

Exemplo:

```
PORT=3000
MYSQL_HOST=localhost
MYSQL_USER=root
MYSQL_PASSWORD=
MYSQL_DB=KIOSKBD
```

---

# 6. Instalação do Node.js e dependências

Antes de executar o projeto, é necessário ter instalado:

* **Node.js**
* **npm**

Para verificar se estão instalados:

```
node -v
```

```
npm -v
```

Caso as dependências ainda não estejam instaladas, execute:

```
npm install
```

---

# 7. Possível ajuste de permissão no Windows

Em algumas máquinas pode ocorrer erro ao executar scripts.

Nesse caso execute o seguinte comando no **PowerShell**:

```
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

---

# 8. Executando o projeto

Para iniciar o servidor da API utilize o comando:

```
npm.cmd run dev
```

Após executar, o servidor iniciará na porta definida no `.env`.

Exemplo:

```
http://localhost:3000
```

---

# 9. Rotas da API

Todas as rotas possuem o prefixo:

```
/api/fornecedores
```

---

## 9.1 Listar todos os fornecedores

Método:

```
GET
```

URL:

```
http://localhost:3000/api/fornecedores
```

---

## 9.2 Buscar fornecedor por ID

Método:

```
GET
```

URL:

```
http://localhost:3000/api/fornecedores/:id
```

Exemplo:

```
http://localhost:3000/api/fornecedores/1
```

---

## 9.3 Criar um fornecedor

Método:

```
POST
```

URL:

```
http://localhost:3000/api/fornecedores
```

### Body (JSON)

```json
{
  "razao_social": "Empresa Exemplo LTDA",
  "nome_fantasia": "Exemplo Foods",
  "cnpj": "12345678000190",
  "email": "contato@empresa.com",
  "telefone": "11999999999",
  "senha": "123456",
  "descricao": "Fornecedor de alimentos naturais",
  "cidade": "São Paulo",
  "estado": "SP",
  "cep": "01000000"
}
```

---

## 9.4 Atualizar fornecedor

Método:

```
PUT
```

URL:

```
http://localhost:3000/api/fornecedores/:id
```

Exemplo:

```
http://localhost:3000/api/fornecedores/1
```

### Body (JSON)

```json
{
  "razao_social": "Empresa Atualizada LTDA",
  "nome_fantasia": "Novo Nome",
  "cnpj": "12345678000190",
  "email": "novo@email.com",
  "telefone": "11888888888",
  "senha": "novaSenha",
  "descricao": "Fornecedor atualizado",
  "cidade": "Campinas",
  "estado": "SP",
  "cep": "13000000"
}
```

---

## 9.5 Deletar fornecedor

Método:

```
DELETE
```

URL:

```
http://localhost:3000/api/fornecedores/:id
```

Exemplo:

```
http://localhost:3000/api/fornecedores/1
```

---

# 10. Utilizando o Postman

Para testar as rotas da API no Postman:

1. Abrir o **Postman**
2. Criar uma nova requisição
3. Selecionar o método da rota (GET, POST, PUT ou DELETE)
4. Inserir a URL da rota

Antes de enviar requisições **POST ou PUT**, configurar:

### Headers

```
Key: Content-Type
Value: application/json
```

### Body

Selecionar:

```
Body → raw → JSON
```

Depois inserir o JSON correspondente ao fornecedor.

---

# 11. Operações CRUD implementadas

O projeto implementa as quatro operações fundamentais de banco de dados:

### Create

Inserção de novos fornecedores no banco.

### Read

Listagem de todos os fornecedores ou busca por ID.

### Update

Atualização de dados de fornecedores já cadastrados.

### Delete

Remoção de fornecedores do banco de dados.

---

# 12. Conclusão

Este projeto demonstra a implementação de uma **API CRUD utilizando Node.js, Express e MySQL**, permitindo a manipulação de dados de fornecedores através de rotas REST.

A estrutura modular com rotas e conexão com banco de dados facilita manutenção, testes e evolução futura do sistema.
