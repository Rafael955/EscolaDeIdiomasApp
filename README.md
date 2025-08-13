# EscolaDeIdiomasApp

Sistema de gerenciamento para uma escola de idiomas, desenvolvido em .NET 9, com arquitetura em camadas, uso de Entity Framework Core e valida��es robustas. A aplica��o exp�e uma API RESTful para cadastro, consulta, atualiza��o e remo��o de alunos e turmas.

## Funcionalidades

- **Alunos**
  - Cadastro de alunos com valida��o de CPF, e-mail e v�nculo obrigat�rio a pelo menos uma turma.
  - Atualiza��o e remo��o de alunos.
  - Consulta individual ou listagem de todos os alunos.
  - Matr�cula e remo��o de alunos em turmas.

- **Turmas**
  - Cadastro, atualiza��o e remo��o de turmas.
  - Consulta individual ou listagem de todas as turmas.
  - Cada turma possui n�mero, ano e n�vel (B�SICO, INTERMEDI�RIO, AVAN�ADO).

## Estrutura do Projeto

- **Domain**: Entidades, DTOs, enums, helpers e valida��es customizadas.
- **Infra**: Contexto do Entity Framework, mapeamentos e reposit�rios.
- **API**: Controllers, configura��o de DI e inicializa��o da aplica��o.

## Principais Tecnologias

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core (SQL Server LocalDB)
- Valida��es com DataAnnotations e atributos customizados
- Swagger para documenta��o da API

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

## Valida��es

- **CPF**: Valida��o customizada via atributo `[Cpf]` e helper.
- **E-mail**: Valida��o padr�o DataAnnotation.
- **Turmas**: Aluno deve estar vinculado a pelo menos uma turma no cadastro.

## Como Executar

1. **Pr�-requisitos**: .NET 9 SDK, SQL Server LocalDB.
2. **Restaurar depend�ncias**: dotnet restore
3. **Aplicar migrations** (se necess�rio): dotnet ef database update
4. **Executar a aplica��o**: dotnet run --project EscolaDeIdiomasApp
5. **Acessar a documenta��o Swagger**: http://localhost:{porta}/swagger

## Observa��es

- O projeto utiliza inje��o de depend�ncia para servi�os e reposit�rios.
- As valida��es s�o centralizadas nos DTOs de request.
- O banco de dados padr�o � LocalDB, configurado em `DataContext.cs`.

---