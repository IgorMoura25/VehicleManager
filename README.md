# VehicleManager
Gerenciamento de veículos

############ RESUMO ################

ASP.NET Core 2.1
Versão do SDK: 2.1
IDE: Visual Studio 2017
Linguagens: C#, HTML, CSS, JavaScript
ORM: Entity Framework v2.1.4
Banco: SQL Server / Os scripts rodados no banco encontram-se na pasta SQL-Server-Scripts
Servidores Web: IIS Express (Frontend _UI e Backend _API usando "multiple startup projects" do Visual Studio 2017)

Observações:
VehicleManager_UI.Models.ApiClient._apiAbsoluteUri: Armazena o caminho root da API.
VehicleManager_DAL.DAL.VehicleManagerContext.ConnectionString: Armazena a Connection String do banco.

########### ARQUITETURA #############

Arquitetura do projeto em camadas, com suas respectivas dependências de projeto. Que seguem:

User Interface Layer (_UI): Front da aplicação com MVC. Não há dependências dos outros projetos, somente consome a API.      
API (_API): API da aplicação para consumo do front. Dependente da BLL
Business Logic Layer (_BLL): Camada para a lógica de negócio. Dependente da DAL.               
Data Access Layer (_DAL): Camada para acesso e manipulação dos dados. Não há dependência dos outros projetos.              

Design Pattern: MVC

############# PACOTES ###############
Pacotes utilizados:

--- UI ---
Bootstrap
jQuery
Input Mask: https://igorescobar.github.io/jQuery-Mask-Plugin/
data-tables: https://datatables.net/
sweet-alert: https://sweetalert2.github.io/

--- DAL ---
Entity Framework SQL Server Provider v2.1.4

############# SQL SERVER #############
Os scripts rodados no banco encontram-se na pasta "SQL-Server-Scripts".
Criado banco localhost
Criado usuário "localdb" em Security e definido a senha "123@mudar"

ConnectionString: Server=localhost;Database=VehicleManager;UID=localdb;PWD=123@mudar
Autenticação: SQL Server Authentication

############# GITHUB #################

https://github.com/IgorMoura25/VehicleManager




