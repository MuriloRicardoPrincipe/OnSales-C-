🛒 OnSales

Sistema MVC para gestão de vendas, clientes e estoque, utilizando Repository Pattern, Entity Framework, Entity Security e autenticação via JWT.

📌 Sobre o Projeto

O OnSales é uma aplicação desenvolvida em ASP.NET MVC com foco em organização em camadas, separação de responsabilidades e boas práticas de arquitetura.

A aplicação contempla:

Cadastro de clientes

Controle de vendas

Gestão de produtos

Controle de estoque

Segurança com autenticação JWT

Controle de acesso (Entity Security)

🏗️ Arquitetura

O projeto segue o padrão:

MVC (Model-View-Controller)

Repository Pattern

Interfaces para abstração

Injeção de Dependência

ORM com Entity Framework

Autenticação baseada em JSON Web Token

📂 Estrutura Base
OnSales
│
├── Controllers
├── Services
├── Repositories
│   ├── Interfaces
│   └── Implementations
├── Models
├── Data (DbContext)
├── Security
└── DTOs
🔐 Segurança

O sistema implementa:

Autenticação via JWT

Controle de acesso por perfil

Proteção de endpoints

Boas práticas de segurança com Entity Security

Fluxo básico:

Usuário realiza login

Sistema gera token JWT

Token é enviado no header:

Authorization: Bearer {token}

Endpoints protegidos validam o token

🧩 Módulos do Sistema
👤 Cliente

Cadastro

Atualização

Exclusão

Consulta

📞 Contato

Cadastro de contatos vinculados ao cliente

📍 Endereço

Cadastro de endereço por cliente

🛍️ Produto

Cadastro de produtos

Atualização de dados

Controle de preço

📦 Estoque

Entrada de produtos

Baixa automática por venda

Consulta de saldo disponível

💰 Venda

Criação de venda

Associação de cliente

Inclusão de múltiplos itens

🧾 VendaItem

Associação de produtos à venda

Cálculo de valor total

Integração com estoque

🔄 Serviços de Controle

O sistema possui regras de negócio para:

Validação de estoque antes da venda

Baixa automática de estoque

Cálculo de total da venda

Controle de integridade entre Venda e VendaItem

🚀 Tecnologias Utilizadas

ASP.NET MVC

C#

Repository Pattern

Injeção de Dependência

Entity Framework

JWT

SQL Server

▶️ Como Executar

Clonar o repositório:

git clone https://github.com/seu-usuario/onsales.git

Configurar a connection string no appsettings.json

Executar as migrations:

dotnet ef database update

Rodar a aplicação:

dotnet run
📈 Próximas Atualizações

🔄 Integração com RabbitMQ

☸️ Orquestração com Kubernetes

Separação em microsserviços

Implementação de mensageria para eventos de venda

Escalabilidade horizontal

🎯 Objetivo do Projeto

O OnSales foi desenvolvido com foco em:

Aplicar boas práticas de arquitetura

Separação clara de responsabilidades

Base sólida para evolução para microsserviços

Segurança moderna com JWT

Facilidade de manutenção e escalabilidade

📄 Licença

Projeto para fins de estudo e evolução profissional.
