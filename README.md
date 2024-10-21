# WebApiJWT

A simple Web API implementation using JWT authentication for user registration and login functionalities.

## Table of Contents
- [About the Project](#about-the-project)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Endpoints](#endpoints)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## About the Project
This project is a basic implementation of a Web API that uses **JWT (JSON Web Token)** for user authentication. It allows users to register and log in securely. The application is built using **ASP.NET Core**.

### Features:
- User Registration
- User Login
- JWT-based authentication and authorization
- Token-based response for valid login credentials

## Technologies Used
- **ASP.NET Core 6.0**
- **JWT Authentication**
- **Entity Framework Core** (for data access)
- **Swagger UI** (for API documentation)

## Getting Started

To get a local copy up and running, follow these steps:

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/WebApiJWT.git
```
Navigate to the project directory:

```bash

cd WebApiJWT
```
Restore NuGet packages:

```bash

dotnet restore
```
Update the appsettings.json file with your database and JWT settings:

```json

"Jwt": {
  "SecretKey": "YourSecretKey",
  "Issuer": "YourIssuer",
  "Audience": "YourAudience",
  "ExpireMinutes": 45
}
```
Apply migrations and update the database:

```bash

dotnet ef database update
```
Run the project:

```bash

dotnet run
```
## Endpoints
Register a New User
URL: /api/Auth/register
Method: POST
Body:
```json

{
  "email": "user@example.com",
  "password": "Password123!"
}
```
Response: 200 OK on success, 400 Bad Request on failure

Login User
URL: /api/Auth/login
Method: POST
Body:
```json

{
  "email": "user@example.com",
  "password": "Password123!"
}
```
Response: 200 OK with JWT token on success, 400 Bad Request on failure
[Ekran görüntüsü 2024-10-21 225939.png]
## Usage
Once the API is running, you can use tools like Postman or Swagger UI to test the endpoints.

Swagger UI is available at /swagger/index.html.
After logging in, include the JWT token in the Authorization header for subsequent requests:

```makefile
Authorization: Bearer <your-token>
```
## Contributing
Contributions are what make the open-source community such a great place to learn, inspire, and create. Any contributions you make are greatly appreciated.

Fork the project
Create your feature branch (git checkout -b feature/AmazingFeature)
Commit your changes (git commit -m 'Add some AmazingFeature')
Push to the branch (git push origin feature/AmazingFeature)
Open a Pull Request
## License
Distributed under the MIT License. See LICENSE for more information.












