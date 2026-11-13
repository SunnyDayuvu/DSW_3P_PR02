# DSW_3P_PR02

API REST para la gestión de eventos desarrollada con ASP.NET Core y Entity Framework Core. Este proyecto permite crear, consultar, actualizar y eliminar eventos, utilizando SQL Server como motor de persistencia.

## Descripción

La aplicación expone un conjunto de endpoints REST para administrar información de eventos, como nombre, categoría, fecha, lugar, cupo máximo y estado activo/inactivo. Está diseñada para funcionar como backend de una aplicación web o móvil que necesite manejar eventos y disponibilidad.

## Tecnologías utilizadas

- ASP.NET Core 10
- C#
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## Requisitos previos

Antes de ejecutar el proyecto asegúrate de tener instalado:

- .NET SDK 10
- SQL Server o SQL Server Express
- Una base de datos creada con el nombre configurado en la cadena de conexión

## Configuración de la base de datos

En el archivo `appsettings.json` debes configurar la cadena de conexión:

```json
"ConnectionStrings": {
  "SqlServerConnection": "Server=localhost\\SQLEXPRESS;Database=DSW_3P_PR02;User Id=tu_usuario;Password=tu_password;TrustServerCertificate=True"
}
