# EscolaDeIdiomasApp

Sistema de gerenciamento para uma escola de idiomas, desenvolvido em .NET 9, com arquitetura em camadas, uso de Entity Framework Core e validações robustas. A aplicação expõe uma API RESTful para cadastro, consulta, atualização e remoção de alunos e turmas.

## Funcionalidades

- **Alunos**
  - Cadastro de alunos com validação de CPF, e-mail e vínculo obrigatório a pelo menos uma turma.
  - Atualização e remoção de alunos.
  - Consulta individual ou listagem de todos os alunos.
  - Matrícula e remoção de alunos em turmas.

- **Turmas**
  - Cadastro, atualização e remoção de turmas.
  - Consulta individual ou listagem de todas as turmas.
  - Cada turma possui número, ano e nível (BÁSICO, INTERMEDIÁRIO, AVANÇADO).

## Estrutura do Projeto

- **Domain**: Entidades, DTOs, enums, helpers e validações customizadas.
- **Infra**: Contexto do Entity Framework, mapeamentos e repositórios.
- **API**: Controllers, configuração de DI e inicialização da aplicação.

## Principais Tecnologias

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core (SQL Server LocalDB)
- Validações com DataAnnotations e atributos customizados
- Swagger para documentação da API

## Endpoints Principais

### Alunos

- `POST /api/alunos/cadastrar-aluno`  
  Cadastra um novo aluno.

- `PUT /api/alunos/atualizar-aluno/{id}`  
  Atualiza os dados de um aluno.

- `DELETE /api/alunos/remover-aluno/{id}`  
  Remove um aluno.

- `GET /api/alunos/obter-aluno/{id}`  
  Consulta um aluno por ID.

- `GET /api/alunos/listar-alunos`  
  Lista todos os alunos.

- `POST /api/alunos/matricular-aluno-turma/{id}`  
  Matricula um aluno em uma turma.

- `DELETE /api/alunos/remover-aluno-turma/{id}`  
  Remove um aluno de uma turma.

### Turmas

- `POST /api/turmas/cadastrar-turma`  
  Cadastra uma nova turma.

- `PUT /api/turmas/atualizar-turma/{id}`  
  Atualiza uma turma.

- `DELETE /api/turmas/remover-turma/{id}`  
  Remove uma turma.

- `GET /api/turmas/obter-turma/{id}`  
  Consulta uma turma por ID.

- `GET /api/turmas/listar-turmas`  
  Lista todas as turmas.

## Validações

- **CPF**: Validação customizada via atributo `[Cpf]` e helper.
- **E-mail**: Validação padrão DataAnnotation.
- **Turmas**: Aluno deve estar vinculado a pelo menos uma turma no cadastro.

## Como Executar

1. **Pré-requisitos**: .NET 9 SDK, SQL Server LocalDB.
2. **Restaurar dependências**: dotnet restore
3. **Aplicar migrations** (se necessário): dotnet ef database update
4. **Executar a aplicação**: dotnet run --project EscolaDeIdiomasApp
5. **Acessar a documentação Swagger**: http://localhost:{porta}/swagger

## Observações

- O projeto utiliza injeção de dependência para serviços e repositórios.
- As validações são centralizadas nos DTOs de request.
- O banco de dados padrão é LocalDB, configurado em `DataContext.cs`.

---