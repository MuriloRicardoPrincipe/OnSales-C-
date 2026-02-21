# OnSales

Sistema de vendas desenvolvido para estudo e prática de **arquitetura moderna em .NET**, com foco em boas práticas de backend, segurança, separação de responsabilidades e futura evolução para arquitetura orientada a eventos.

---

## 🚀 Visão Geral

O **OnSales** é um projeto criado para simular um sistema de vendas real, inicialmente estruturado como um **monólito modular em ASP.NET MVC**, utilizando:

- Repository Pattern  
- Interfaces para abstração  
- Entity Framework  
- Autenticação com JWT  
- Controle de acesso (Entity Security)  

O objetivo principal é consolidar fundamentos sólidos de arquitetura antes da evolução para microsserviços com mensageria.

---

## 🎯 Objetivos Técnicos

Este projeto busca aprofundar conceitos como:

- Separação de camadas (Controller → Service → Repository)
- Princípios SOLID
- Injeção de Dependência
- ORM com Entity Framework
- Autenticação stateless com JWT
- Controle de concorrência e integridade de estoque
- Preparação para arquitetura orientada a eventos

---

## 🧱 Arquitetura

- MVC (Model-View-Controller)
- Repository Pattern
- Interfaces para desacoplamento
- Injeção de Dependência nativa do .NET
- Segurança com JWT
- Separação de domínio por módulos

O projeto foi estruturado para facilitar futura migração para:

- Microsserviços
- Comunicação assíncrona
- Event-Driven Architecture

---

## 🧩 Domínio do Sistema

### 👤 Cliente
- Cadastro
- Atualização
- Consulta
- Exclusão

### 📞 Contato
- Cadastro de contatos vinculados ao cliente

### 📍 Endereço
- Cadastro e vínculo com cliente

---

### 📦 Produto
- Cadastro de produtos
- Atualização de dados
- Controle de preço

### 📊 Estoque
- Entrada de produtos
- Baixa automática por venda
- Validação de saldo disponível

---

### 💰 Venda
- Criação de venda
- Associação com cliente
- Inclusão de múltiplos itens
- Cálculo automático do total

### 🧾 VendaItem
- Associação entre venda e produto
- Controle de quantidade
- Integração com estoque

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET MVC  
- C#  
- SQL Server  
- Entity Framework  
- JWT  
- Injeção de Dependência  
- Repository Pattern  

---

## 📦 Estrutura do Projeto

```text
onsales/
├── Controllers
├── Services
├── Repositories
│   ├── Interfaces
│   └── Implementations
├── Models
├── DTOs
├── Data (DbContext)
├── Security
└── README.md
