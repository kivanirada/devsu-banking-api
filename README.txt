# Examen Técnico Full-Stack - Devsu

## Tecnologías utilizadas
- Backend: ASP.NET Core 6
- ORM: Entity Framework Core
- Base de datos: SQL Server
- Documentación API: Swagger
- Contenedores: Docker (opcional)
- Cliente de prueba: Postman

## Cómo ejecutar el proyecto

### Opción 1: desde Visual Studio / CLI
1. Restaurar dependencias:
   dotnet restore
2. Ejecutar:
   dotnet run

Accede a Swagger: http://localhost:7242

### Opción 2: Docker (si tienes instalado)
```bash
docker build -t devsu-api .
docker run -p 7242:80 devsu-api
