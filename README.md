# GerenciadorClinica
API REST para Gerenciamento de Clínicas
Descrição
O GerenciadorClinica é uma API REST completa para gerenciamento de clínicas, desenvolvida com ASP.NET Core e utilizando boas práticas de desenvolvimento como Arquitetura Limpa, CQRS, Padrão Repository e Fluent Validation.

# Funcionalidades
CRUD de Pacientes: Crie, leia, atualize e delete registros de pacientes.
CRUD de Médicos: Crie, leia, atualize e delete registros de médicos.
CRUD de Atendimentos: Crie, leia, atualize e delete registros de atendimentos.
CRUD de Serviços: Crie, leia, atualize e delete registros de serviços.
Confirmação de Agendamento por Email: Envie emails para pacientes confirmando seus agendamentos.

# Integrações
Integração com Google Calendar: Sincronize agendamentos com o Google Calendar.
Múltiplas Agendas por Médico: Permitir que cada médico tenha múltiplas agendas.
Integração com WS dos Correios: Utilize a API dos Correios para consultar CEPs e endereços.
  
# Tecnologias
ASP.NET Core API: Framework para desenvolvimento de APIs RESTful.
Entity Framework Core: ORM para acesso ao banco de dados.
POO: Programação Orientada a Objetos.
Fluent Validation: Biblioteca para validação de dados.
Padrão Repository: Padrão de projeto para abstrair acesso a dados.
Middleware: Lidar com exceções e outras funcionalidades transversais.
InputModel, ViewModel, DTOs: Modelos de entrada e saída de dados.
SQL Server: Banco de dados relacional.
CQRS: Padrão de arquitetura para separar operações de leitura e escrita.
Arquitetura Limpa: Padrão de arquitetura para construir sistemas escaláveis e manuteníveis.

# Instalação
Clone o repositório.
Restaure o banco de dados.
Configure as configurações da aplicação.

# Como Usar
Inicie a aplicação.
Acesse a documentação da API no Swagger para visualizar as endpoints disponíveis.
