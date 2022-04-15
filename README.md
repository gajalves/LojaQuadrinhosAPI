# Rodar o projeto
- Alterar a string de conexão dentro do **appsettings.json**.
- Executar as migrations: 
	- **dotnet ef migrations add initialmigration** 
	- **dotnet ef database update**
- Executar: **dotnet run**

# Utilizar
- Criar o usuário: **/api/v1/users/create** 
	- Roles: **user** ou **admin**
- Relizar o login: **/api/v1/auth/login**
	- O token será retornado no body, utilizar ele no campo do **Authorize**: Bearer **token**

![]()
