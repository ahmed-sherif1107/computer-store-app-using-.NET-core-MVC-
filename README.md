# Computer Store Web Application

A web-based computer store application built using ASP.NET Core MVC, Entity Framework Core, and SQL Server.

## Overview

This application provides a platform for managing a computer store's inventory with features for adding, editing, and removing computer products and categories. The system includes user authentication with role-based access control.

## Features

- **Product Management**: Add, edit, delete, and view computer products
- **Category Management**: Organize products by categories
- **User Authentication**: Secure access with Identity framework
- **Role-Based Access**: Different permissions for customers and administrators
- **Responsive Design**: Mobile-friendly user interface

## Technologies Used

- ASP.NET Core 8.0 MVC
- Entity Framework Core 8.0
- SQL Server
- ASP.NET Core Identity
- Bootstrap (for responsive UI)
- C# programming language

## Project Structure

- **Models**: Contains data models for Items, Category, Employee
- **Controllers**: Implements application logic (CategoryController, ItemController, HomeController)
- **Views**: UI templates for rendering data
- **Areas**: Organized feature sections (e.g., EmployeesArea)
- **ContextDB**: Database context and configuration
- **Repo**: Repository pattern implementation for data access

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/computer-store-app-using-.NET-core-MVC-.git
   ```

2. Navigate to the project directory:
   ```
   cd computer-store-app-using-.NET-core-MVC-
   ```

3. Update the connection string in `appsettings.json` to point to your SQL Server instance

4. Apply database migrations:
   ```
   dotnet ef database update
   ```

5. Run the application:
   ```
   dotnet run
   ```

6. Access the application at `https://localhost:5001` or `http://localhost:5000`

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- ASP.NET Core documentation
- Entity Framework Core documentation
- Bootstrap for UI components
