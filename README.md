
# Projeto Loja Api - back-end 

O projeto é uma API desenvolvida em .NET 8. Ele possui funcionalidades para cadastrar produtos, caixas e gerar pedido, além de conseguir ler vários pedidos e informar a quantidade de caixas e quais produtos foram armazenados nas caixas.

## 🚀 Como Executar
🔧 Requisitos

- Docker
- Docker Compose
## Como executar o projeto no Docker

### Passo 1: Clonar o repositório

Clone o repositório do projeto para sua máquina local:
```bash
git clone https://github.com/GladsonNunes/LojaApi.git cd LojaApi
```


### Passo 2: Construir e executar o contêiner

Execute os seguintes comandos para construir e iniciar o contêiner Docker:
```bash
docker-compose build 
```
```bash
docker-compose up
```

### Passo 3: Acessar a API

A API estará disponível em `http://localhost:8080`. Você pode testar os endpoints usando ferramentas como Postman ou cURL.

A API estará disponível em `http://localhost:8080/swagger/index.html`. Você pode testar os endpoints utilizando o swagger.



## 📜 Tecnologias Utilizadas

🔹 Back-End
- Linguagem: C#
- Framework: .NET 8

🔹 Banco de Dados
- Banco de Dados Relacional: SQL SERVER
- ORM: Entity Framework Core


🔹 Infraestrutura e DevOps
- Containerização: Docker
- Gerenciamento de Containers: Docker Compose

🔹 Testes Automatizados
- Testes Unitários e de Integração: xUnit
- Mock de Dependências: Moq


## 🌐 Endpoints Principais

Os controllers responsáveis pelos classes PRODUTO, CAIXA e PEDIDO possuem endpoints semelhantes, seguindo o padrão CRUD (Create, Read, Update, Delete)

Os controllers abaixo possuem os mesmo endpoint de cadastro
- CaixaController
- PedidoController
- ProdutoController

| Método | Endpoint             | Descrição                       |
|--------|----------------------|---------------------------------|
| POST   | /Create              | Cria um novo cadastro (PRODUTO, CAIXA ou PEDIDO).          |
| GET    | /GetByAll            | Retorna todos os recursos cadastrados (PRODUTO, CAIXA ou PEDIDO).     |
| GET    | /GetById             | Retorna um cadastro específico pelo Id.        |
| PUT    | /Update              | Atualiza os dados de um cadastro existente.          |
| DELETE | /Delete              | Exclui um cadastro específico pelo Id.          |

🔹 Pedido

- O `Pedido/Empacotar` é responsável por gerenciar as operações relacionadas a empacotamente de pedidos. A funcionalidade é receber uma lista de pedidos e retornar uma lista de caixa com os produtos, respeitando a regra se o produto cabe na caixa. 


| Método | Endpoint             | Descrição                       |
|--------|----------------------|---------------------------------|
| POST   | /Empacotar          | Empacota uma Lista de pedido.   |
