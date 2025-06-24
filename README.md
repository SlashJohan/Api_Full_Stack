# Prueba Técnica FullStack (.NET 6 + Angular 17)

Este proyecto es una aplicación web desarrollada como parte de una prueba técnica para el cargo de desarrollador FullStack.

## 🛠️ Tecnologías utilizadas

### Backend (.NET 6)
- ASP.NET Core Web API
- Dapper con procedimientos almacenados
- Autenticación con JWT
- SQL Server

### Frontend (Angular 17)
- Angular CLI 17
- Ng Zorro Ant Design
- Interceptor para token JWT
- Control de acceso con AuthGuard

---

## 🚀 Funcionalidad

1. Inicio de sesión con autenticación JWT
2. Redirección automática al módulo de sucursales al iniciar sesión
3. Carga y visualización de la lista de sucursales desde el backend
4. Tabla con paginación y scroll horizontal (Ng Zorro)

---

## 🧪 Cómo ejecutar el proyecto

### Requisitos

- Node.js 18+
- Angular CLI 17
- .NET 6 SDK
- SQL Server
- Visual Studio 2022 o VS Code

### Backend
1. Configura la cadena de conexión en `appsettings.json`.
2. Restaura paquetes y ejecuta el proyecto (`dotnet run`).
3. Asegúrate de que los endpoints estén en `https://localhost:7007`.

### Frontend
```bash
npm install
ng serve
