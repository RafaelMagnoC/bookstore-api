# BookStore - API

Você deve desenvolver uma API RESTful para uma aplicação chamada BookStore, que permite o gerenciamento de livros, autores e usuários. A aplicação deve ser desenvolvida em .NET 8 e deve seguir as boas práticas de desenvolvimento, incluindo o uso de padrões de projeto, testes unitários e tratamento de erros.

BookStore é uma aplicação de venda de livros. A aplicaçào permite o controle e gerenciamento de usuarios, autores e livros, além de realizar vendas e verificar disponibilidade no estoque. Alguns endpoints são restritos

---

## 🛠️ Tecnologias Utilizadas

- **.NET 8**: Framework utilizado para criar a API.
- **ASP.NET Core**: Framework para construção de APIs Web.
- **Entity Framework Core**: ORM para interagir com o banco de dados.
- **Swagger**: Documentação automática da API (se configurado).
- **JWT**: Para autenticação e autorização dos usuários.
- **Banco de Dados**: SqlServer
- **Containerizaçào**: Docker

---

## 📋 Requisitos

Antes de rodar o projeto, você precisa de:
- Docker e Docker Compose instalados

🚀 Como Rodar o Projeto

1. No arquivo `docker-compose.yml`, atualize a senha em `MSSQL_SA_PASSWORD` para uma senha segura.
2. No código da API, configure o `ConnectionString` usando as variáveis de ambiente.

## Rodando o Projeto

1. Clonar o repositório:
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd BookStore
   ```

2. Construir e rodar os containers:
 docker-compose up --build

A API estará acessível em http://localhost:8000, com o Swagger disponível em http://localhost:8000/swagger.

5. Testar a API
   Você pode acessar a documentação da API em:
   http://localhost:8000/swagger

📑 Endpoints
Principais endpoints da API e uma breve descrição.

1. user
   responsável pelo gerenciamento de usuários

2. admin
   responsável pelo gerencimaneto de usuários administradores

3. author
   responsável pelo gerencimaneto dos autores dos livros

4. book
   responsável pelo gerencimanento de livros

5. inventory
   responsável pelo gerenciamento de estoque

6. auth
   responsável pela autenticação dos usuários


🧪 Testes
Se necessário realizar testes, você pode rodá-los com:

docker build -f Dockerfile.test -t BookStore-test

docker run --rm BookStore-test

📬 Contato
Se você tiver dúvidas ou sugestões, pode me encontrar no GitHub ou enviar um e-mail para: rafaelmagno125@gmail.com

---

### Explicação das Seções

- **Tecnologias Utilizadas**: Descreve as tecnologias e ferramentas que o projeto usa (ex: .NET 8, Entity Framework Core, Swagger, etc.).
- **Requisitos**: Informa o que a pessoa precisa instalar antes de executar o projeto, como o SDK do .NET 8 e, se necessário, configurações de banco de dados.
- **Como Rodar o Projeto**: Passo a passo sobre como baixar, configurar e rodar o projeto localmente.
- **Endpoints**: Documenta os endpoints da API.
- **Testes**: Explica como rodar testes automatizados.
- **Contato**: Para comunicação com o mantenedor do projeto.


