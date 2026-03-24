# README — Implementação de Programação Orientada a Objetos (POO)

## 1. Objetivo

Este módulo do projeto tem como objetivo demonstrar a aplicação dos conceitos de **Programação Orientada a Objetos (POO)** no desenvolvimento de um sistema de marketplace em C#.

A proposta é simular um ambiente onde diferentes tipos de usuários interagem com anúncios de produtos dentro de uma plataforma B2B, servindo como base conceitual para o projeto **Mr.Nut**.

---

## 2. Conceitos de POO aplicados

O sistema utiliza os principais pilares da Programação Orientada a Objetos:

### 2.1 Encapsulamento

Os dados de cada entidade são organizados em classes com propriedades específicas, como por exemplo:

* `Nome`
* `Email`
* `Senha`
* `Telefone`
* `DataCadastro`

Essas informações ficam centralizadas dentro de objetos, facilitando manutenção, reutilização e organização do código.

---

### 2.2 Herança

Foi criada uma classe base chamada:

* `users`

A partir dela, foram derivadas classes especializadas:

* `fornecedor`
* `comprador`
* `admin`

Essas classes herdam atributos e comportamentos comuns da classe base e adicionam características próprias de cada perfil.

#### Exemplo:

* `fornecedor` possui dados como:

  * `CNPJ`
  * `Regiao`
  * `RazaoSocial`

* `comprador` pode possuir:

  * lista de favoritos
  * possibilidade de avaliação

* `admin` possui:

  * permissão para aprovar anúncios

---

### 2.3 Polimorfismo

Embora a estrutura atual seja simples, o sistema já permite a evolução para polimorfismo por meio da especialização de comportamentos em subclasses.

Exemplo futuro:

* Cada tipo de usuário pode sobrescrever métodos como:

  * `ExibirPerfil()`
  * `RealizarAcao()`
  * `Permissoes()`

---

### 2.4 Abstração

Cada classe representa uma entidade real do marketplace, abstraindo seu comportamento e responsabilidade:

* `users` → representa um usuário genérico
* `fornecedor` → representa quem publica produtos
* `comprador` → representa quem busca e avalia produtos
* `admin` → representa quem modera o sistema
* `anuncio` → representa a oferta publicada
* `mktp` → representa o sistema central de marketplace

---

## 3. Estrutura das classes

### 3.1 Classe base `users`

Responsável por concentrar os dados comuns a todos os usuários.

#### Principais atributos:

* `Id`
* `Nome`
* `Email`
* `Senha`
* `Telefone`
* `DataCadastro`
* `Ativo`

#### Principais métodos:

* `Login()`
* `Logout()`
* `AtualizarPerfil()`

---

### 3.2 Classe `fornecedor`

Herda de `users` e representa o fornecedor dentro do marketplace.

#### Função:

* cadastrar produtos/anúncios
* manter dados comerciais
* representar a empresa anunciante

---

### 3.3 Classe `comprador`

Herda de `users` e representa o comprador.

#### Função:

* visualizar anúncios
* favoritar produtos
* avaliar anúncios

---

### 3.4 Classe `admin`

Herda de `users` e representa o administrador do sistema.

#### Função:

* aprovar anúncios
* moderar conteúdo
* controlar o fluxo de publicação

---

### 3.5 Classe `anuncio`

Representa uma oferta de produto dentro do marketplace.

#### Principais atributos:

* `Titulo`
* `Descricao`
* `Categoria`
* `Marca`
* `MOQ` (quantidade mínima de pedido)
* `Regiao`
* `Preco`
* `Status`

---

### 3.6 Classe `Avaliacao`

Representa o feedback de um comprador sobre um anúncio.

#### Principais atributos:

* `Id`
* `Nota`
* `Comentario`
* `Data`

---

### 3.7 Classe `mktp`

Classe principal do sistema.

#### Responsabilidades:

* armazenar listas de usuários e anúncios
* cadastrar fornecedores
* adicionar anúncios
* listar anúncios
* centralizar regras de negócio

---

## 4. Benefícios da POO no projeto

A utilização de POO neste projeto traz as seguintes vantagens:

* **Organização do código**
* **Separação de responsabilidades**
* **Facilidade de manutenção**
* **Maior escalabilidade**
* **Reaproveitamento de código**
* **Base sólida para evolução futura com banco de dados e API**

Esses pontos são essenciais para a construção do sistema **Mr.Nut**, pois o projeto exige múltiplos perfis de usuário e regras de negócio distintas.

---

## 5. Relação com o projeto Mr.Nut

A implementação em POO serve como uma base conceitual para o marketplace B2B do semestre, permitindo futura expansão para:

* autenticação por perfil
* CRUD de anúncios
* favoritos
* avaliações
* aprovação de anúncios por administrador
* persistência em banco de dados
* API Web em ASP.NET

---

## 6. Conclusão

A parte de Programação Orientada a Objetos deste projeto demonstra a estruturação lógica de um marketplace em C#, aplicando conceitos fundamentais como:

* herança
* encapsulamento
* abstração
* organização por entidades

Essa modelagem torna o sistema mais próximo de um ambiente real de software, preparando o projeto para futuras evoluções acadêmicas e técnicas.

---

## 7. Arquivos relacionados

Os principais arquivos relacionados à parte de POO são:

* `users.cs`
* `fornecedor.cs`
* `comprador.cs`
* `admin.cs`
* `anuncio.cs`
* `avaliacao.cs`
* `mktp.cs`

---

