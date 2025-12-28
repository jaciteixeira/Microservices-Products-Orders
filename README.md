# 🍔 Tech Challenge - Sistema de Pedidos (Lanchonete)

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?logo=docker)](https://www.docker.com/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Tests](https://img.shields.io/badge/Tests-80%25%20Coverage-success)](https://xunit.net/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

> Sistema de gerenciamento de pedidos para lanchonete, desenvolvido com arquitetura de microserviços, Clean Architecture e práticas de desenvolvimento modernas.

## 📋 Índice

- [Sobre o Projeto](#-sobre-o-projeto)
- [Arquitetura](#-arquitetura)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Microserviços](#-microserviços)
- [Pré-requisitos](#-pré-requisitos)
- [Instalação e Execução](#-instalação-e-execução)
- [Testes](#-testes)
- [Estrutura do Projeto](#-estrutura-do-projeto)
- [API Endpoints](#-api-endpoints)
- [Migrations](#-migrations)
- [Docker](#-docker)
- [Contribuindo](#-contribuindo)

---

## 🎯 Sobre o Projeto

Sistema desenvolvido como parte do **Tech Challenge da FIAP - Fase 4** - Pós-Graduação em Arquitetura de Software. O projeto implementa um sistema completo de autoatendimento para lanchonetes, permitindo que clientes façam pedidos, acompanhem o status e realizem pagamentos de forma automatizada.

### Objetivos do Projeto

- ✅ Implementar arquitetura de microserviços
- ✅ Aplicar conceitos de Clean Architecture
- ✅ Separação de bancos de dados por serviço
- ✅ Comunicação entre microserviços
- ✅ Testes unitários com cobertura mínima de 80%
- ✅ Testes BDD com SpecFlow
- ✅ Containerização com Docker
- ✅ CI/CD Ready

---

## 🏗️ Arquitetura

O projeto segue os princípios de **Clean Architecture** e **Microserviços**, garantindo:

- **Separação de Responsabilidades**: Cada camada tem uma função específica
- **Independência de Frameworks**: Lógica de negócio isolada de detalhes técnicos
- **Testabilidade**: Facilidade para criar testes unitários e de integração
- **Independência de UI e Database**: Flexibilidade para mudanças

### Diagrama de Arquitetura

```
┌─────────────────────────────────────────────────────────────────┐
│                         Cliente (Frontend)                       │
└────────────────────┬────────────────────┬───────────────────────┘
                     │                    │
                     ▼                    ▼
         ┌─────────────────────┐  ┌─────────────────────┐
         │   Products API      │  │    Orders API       │
         │   Port: 5001        │  │   Port: 5002        │
         └──────────┬──────────┘  └──────────┬──────────┘
                    │                        │
                    │                        │ HTTP
                    ▼                        ▼
         ┌─────────────────────┐  ┌─────────────────────┐
         │   products_db       │  │    orders_db        │
         │   (MySQL)           │  │   (MySQL)           │
         └─────────────────────┘  └─────────────────────┘
```

### Camadas da Clean Architecture

```
┌─────────────────────────────────────────────────────────┐
│                     API Layer                           │
│  Controllers, Endpoints, Middleware                     │
└────────────────────────┬────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────┐
│                  Application Layer                      │
│  Services, DTOs, Use Cases, Validators                 │
└────────────────────────┬────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────┐
│                   Domain Layer                          │
│  Entities, Enums, Business Rules, Interfaces           │
└────────────────────────┬────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────┐
│                Infrastructure Layer                     │
│  DbContext, Repositories, External Services            │
└─────────────────────────────────────────────────────────┘
```

---

## 🛠️ Tecnologias Utilizadas

### Backend
- **ASP.NET Core 8.0** - Framework web
- **Entity Framework Core 8.0** - ORM
- **MySQL 8.0** - Banco de dados
- **Pomelo.EntityFrameworkCore.MySql** - Provider MySQL para EF Core

### Testes
- **xUnit** - Framework de testes
- **FluentAssertions** - Assertions mais expressivas
- **Moq** - Mocking de dependências
- **AutoFixture** - Geração de dados de teste
- **SpecFlow** - BDD (Behavior-Driven Development)
- **Coverlet** - Cobertura de código

### DevOps
- **Docker** - Containerização
- **Docker Compose** - Orquestração de containers
- **GitHub Actions** - CI/CD (Ready)

### Ferramentas
- **Swagger/OpenAPI** - Documentação de API
- **Serilog** - Logging estruturado

---

## 🚀 Microserviços

### 1️⃣ Products Microservice

Responsável pelo gerenciamento do catálogo de produtos da lanchonete.

**Funcionalidades:**
- ✅ CRUD completo de produtos
- ✅ Categorização (Lanche, Acompanhamento, Bebida, Sobremesa)
- ✅ Controle de produtos ativos/inativos
- ✅ Busca por categoria
- ✅ Seed automático de dados iniciais

**Porta:** `5001`  
**Banco de Dados:** `products_db`  
**Swagger:** http://localhost:5001/swagger

### 2️⃣ Orders Microservice

Gerencia todo o ciclo de vida dos pedidos.

**Funcionalidades:**
- ✅ Criação de pedidos com múltiplos itens
- ✅ Cálculo automático do valor total
- ✅ Controle de status (Recebido → Em Preparação → Pronto → Finalizado)
- ✅ Integração com serviço de produtos via HTTP
- ✅ Webhook para receber notificações de pagamento
- ✅ Validação de produtos antes de criar pedido

**Porta:** `5002`  
**Banco de Dados:** `orders_db`  
**Swagger:** http://localhost:5002/swagger

---

## 📦 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (versão 8.0 ou superior)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (para execução com containers)
- [MySQL 8.0](https://dev.mysql.com/downloads/) (opcional, se não usar Docker)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### Verificar Instalações

```bash
# Verificar .NET
dotnet --version

# Verificar Docker
docker --version

# Verificar Docker Compose
docker-compose --version
```

---

## 🚀 Instalação e Execução

### Opção 1: Executar com Docker (Recomendado)

A forma mais simples de executar todo o sistema:

```bash
# 1. Clone o repositório
git clone https://github.com/wesleygyn/Microservices-Products-Orders.git
cd tech-challenge

# 2. Suba os containers
docker-compose up -d

# 3. Aguarde ~30 segundos para as migrations serem aplicadas

# 4. Acesse as APIs
# Products: http://localhost:5001/swagger
# Orders: http://localhost:5002/swagger
```

#### Verificar Status dos Containers

```bash
# Ver containers rodando
docker-compose ps

# Ver logs em tempo real
docker-compose logs -f

# Ver logs de um serviço específico
docker-compose logs -f products_api
```

#### Parar e Remover Containers

```bash
# Parar containers (mantém volumes)
docker-compose stop

# Parar e remover (mantém volumes)
docker-compose down

# Parar, remover containers E volumes (apaga banco de dados)
docker-compose down -v
```

---

### Opção 2: Executar Localmente (Desenvolvimento)

Para desenvolvimento local sem Docker:

#### 1. Configurar Banco de Dados

```bash
# Conectar ao MySQL
mysql -u root -p

# Criar bancos de dados
CREATE DATABASE products_db;
CREATE DATABASE orders_db;
EXIT;
```

#### 2. Configurar Connection Strings

Edite os arquivos `appsettings.json`:

**Products.API/appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=products_db;Uid=root;Pwd=SUA_SENHA;"
  }
}
```

**Orders.API/appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=orders_db;Uid=root;Pwd=SUA_SENHA;"
  },
  "ProductsApi": {
    "BaseUrl": "http://localhost:5001"
  }
}
```

#### 3. Executar Migrations

```bash
# Products API
cd Products.Microservice/Products.API
dotnet ef database update

# Orders API
cd ../../Orders.Microservice/Orders.API
dotnet ef database update
```

#### 4. Executar as APIs

**Terminal 1 - Products API:**
```bash
cd Products.Microservice/Products.API
dotnet run --urls "http://localhost:5001"
```

**Terminal 2 - Orders API:**
```bash
cd Orders.Microservice/Orders.API
dotnet run --urls "http://localhost:5002"
```

---

## 🧪 Testes

O projeto possui **cobertura de testes superior a 80%**, incluindo testes unitários e BDD.

### Executar Todos os Testes

```bash
# Executar todos os testes
dotnet test

# Com output detalhado
dotnet test --logger "console;verbosity=detailed"

# Apenas um projeto
dotnet test Products.Tests/Products.Tests.csproj
dotnet test Orders.Tests/Orders.Tests.csproj
```

### Gerar Relatório de Cobertura

```bash
# Executar testes com cobertura
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Instalar ferramenta de relatório (uma vez)
dotnet tool install -g dotnet-reportgenerator-globaltool

# Gerar relatório HTML
reportgenerator "-reports:**/coverage.opencover.xml" "-targetdir:coverage-report" "-reporttypes:Html"

# Abrir relatório
start coverage-report/index.html  # Windows
open coverage-report/index.html   # Mac/Linux
```

### Estrutura de Testes

```
Products.Tests/
├── Domain/          # Testes de entidades e regras de negócio
├── Application/     # Testes de serviços e casos de uso
├── Infrastructure/  # Testes de repositórios
└── BDD/            # Testes comportamentais com SpecFlow

Orders.Tests/
├── Domain/
├── Application/
├── Infrastructure/
└── BDD/
    ├── Features/    # Cenários em Gherkin
    └── Steps/       # Implementação dos steps
```

---

## 📁 Estrutura do Projeto

```
TechChallenge/
│
├── Products.Microservice/
│   ├── Products.Domain/            # Entidades, Enums, Interfaces
│   ├── Products.Application/       # Services, DTOs, Validators
│   ├── Products.Infrastructure/    # DbContext, Repositories
│   ├── Products.API/               # Controllers, Program.cs
│   └── Products.Tests/             # Testes unitários e BDD
│
├── Orders.Microservice/
│   ├── Orders.Domain/
│   ├── Orders.Application/
│   ├── Orders.Infrastructure/
│   ├── Orders.API/
│   └── Orders.Tests/
│
├── docker-compose.yml              # Orquestração Docker
└── README.md                       # Este arquivo
```

---

## 📡 API Endpoints

### Products API (Port 5001)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/products` | Lista todos os produtos |
| GET | `/api/products/{id}` | Busca produto por ID |
| GET | `/api/products/active` | Lista produtos ativos |
| GET | `/api/products/category/{category}` | Lista produtos por categoria |
| POST | `/api/products` | Cria novo produto |
| PUT | `/api/products/{id}` | Atualiza produto |
| DELETE | `/api/products/{id}` | Remove produto |

**Categorias válidas:** `SANDWICH`, `SIDE`, `DRINK`, `DESSERT`

#### Exemplo de Requisição

```bash
# Criar produto
curl -X POST http://localhost:5001/api/products \
  -H "Content-Type: application/json" \
  -d '{
    "name": "X-Burger",
    "price": 25.90,
    "category": "SANDWICH",
    "description": "Hambúrguer delicioso",
    "imageUrl": "https://example.com/burger.jpg"
  }'
```

---

### Orders API (Port 5002)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/orders` | Lista todos os pedidos |
| GET | `/api/orders/{id}` | Busca pedido por ID |
| GET | `/api/orders/active` | Lista pedidos ativos |
| GET | `/api/orders/status/{status}` | Lista pedidos por status |
| POST | `/api/orders` | Cria novo pedido |
| PATCH | `/api/orders/{id}/status` | Atualiza status do pedido |
| PATCH | `/api/orders/{id}/payment` | Define PaymentId |
| DELETE | `/api/orders/{id}` | Remove pedido |
| POST | `/api/webhook` | Webhook de pagamento |

**Status válidos:** `RECEIVED`, `IN_PREPARATION`, `READY`, `FINALIZED`

#### Exemplo de Requisição

```bash
# Criar pedido
curl -X POST http://localhost:5002/api/orders \
  -H "Content-Type: application/json" \
  -d '{
    "customerId": 1,
    "observation": "Sem cebola",
    "items": [
      {
        "productId": 1,
        "quantity": 2
      },
      {
        "productId": 3,
        "quantity": 1
      }
    ]
  }'

# Simular webhook de pagamento
curl -X POST http://localhost:5002/api/webhook \
  -H "Content-Type: application/json" \
  -d '{
    "status": "PAID",
    "orderId": "1",
    "paymentId": "pay_123456"
  }'
```

---

## 🔄 Migrations

As migrations são aplicadas **automaticamente** ao iniciar a aplicação, tanto localmente quanto no Docker.

### Criar Nova Migration

```bash
# Products
cd Products.Microservice/Products.API
dotnet ef migrations add NomeDaMigration --project ../Products.Infrastructure

# Orders
cd Orders.Microservice/Orders.API
dotnet ef migrations add NomeDaMigration --project ../Orders.Infrastructure
```

### Aplicar Migrations Manualmente

```bash
# Products
dotnet ef database update --project Products.Infrastructure --startup-project Products.API

# Orders
dotnet ef database update --project Orders.Infrastructure --startup-project Orders.API
```

### Reverter Migration

```bash
# Reverter última migration
dotnet ef migrations remove --project Products.Infrastructure --startup-project Products.API
```

### Gerar Script SQL

```bash
# Gerar script de todas as migrations
dotnet ef migrations script --project Products.Infrastructure --startup-project Products.API -o migration.sql
```

---

## 🐳 Docker

### Estrutura Docker

O projeto usa `docker-compose.yml` para orquestrar:
- 1 container MySQL (compartilhado por ambos os bancos)
- 1 container Products API
- 1 container Orders API

### Comandos Úteis

```bash
# Build e start
docker-compose up --build -d

# Apenas start (sem rebuild)
docker-compose up -d

# Stop
docker-compose stop

# Stop e remove containers
docker-compose down

# Stop, remove containers E volumes (APAGA DADOS)
docker-compose down -v

# Ver logs
docker-compose logs -f

# Ver logs de um serviço
docker-compose logs -f products_api

# Rebuild apenas um serviço
docker-compose up -d --build products_api

# Entrar no container
docker-compose exec products_api sh

# Ver uso de recursos
docker stats
```

### Conectar no MySQL do Docker

```bash
# Via docker-compose
docker-compose exec mysql mysql -uroot -p123456

# Ver bancos
SHOW DATABASES;

# Usar banco
USE products_db;

# Ver tabelas
SHOW TABLES;

# Consultar produtos
SELECT * FROM products;
```

---

## 🔐 Variáveis de Ambiente

### Desenvolvimento Local

Configuradas em `appsettings.json`

### Docker

Configuradas em `docker-compose.yml`:

```yaml
environment:
  - ASPNETCORE_ENVIRONMENT=Development
  - ConnectionStrings__DefaultConnection=Server=mysql;Port=3306;Database=products_db;...
  - ProductsApi__BaseUrl=http://products_api:80
```

---

## 📊 Monitoramento

### Health Checks

Ambas as APIs possuem endpoints de health check:

```bash
# Products
curl http://localhost:5001/health

# Orders
curl http://localhost:5002/health
```

### Swagger

Documentação interativa disponível em:
- Products: http://localhost:5001/swagger
- Orders: http://localhost:5002/swagger

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Para contribuir:

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

### Padrões de Commit

Seguimos o padrão [Conventional Commits](https://www.conventionalcommits.org/):

```
feat: adiciona nova funcionalidade
fix: corrige bug
docs: atualiza documentação
test: adiciona ou corrige testes
refactor: refatora código
style: mudanças de formatação
chore: tarefas de manutenção
```

---

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👥 Autores

**Tech Challenge - FIAP**
- Pós-Graduação em Arquitetura de Software
- Fase 4 - Microserviços

---

## 📞 Suporte

Para reportar bugs ou sugerir melhorias:
- Abra uma [Issue](https://github.com/seu-usuario/tech-challenge/issues)
- Entre em contato via [Discussions](https://github.com/seu-usuario/tech-challenge/discussions)

---

## 🎯 Roadmap

- [x] Implementação de microserviços
- [x] Clean Architecture
- [x] Testes unitários (80%+ coverage)
- [x] Testes BDD
- [x] Docker e Docker Compose
- [x] Migrations automáticas
- [x] Webhook de pagamento
- [ ] CI/CD com GitHub Actions
- [ ] Integração com SonarQube
- [ ] API Gateway
- [ ] Service Discovery
- [ ] Mensageria (RabbitMQ/Kafka)
- [ ] Observabilidade (Prometheus/Grafana)

---

## 📚 Documentação Adicional

- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Microservices Patterns](https://microservices.io/patterns/index.html)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [xUnit Documentation](https://xunit.net/)
- [SpecFlow Documentation](https://docs.specflow.org/)

---

<div align="center">

**⭐ Se este projeto te ajudou, considere dar uma estrela! ⭐**

Desenvolvido com ❤️ para o Tech Challenge FIAP

</div>