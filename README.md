# Evokehub

# My Book Store Application

This is a sample full-stack application built as part of a technical assessment. The project consists of a .NET 8 Web API backend and an Angular 19 frontend, designed with scalability and maintainability in mind.

---

## 📁 Project Structure

### Backend (`MyBookStore.API`)
- **Framework**: ASP.NET Core 8
- **Architecture**: Layered Architecture
  - `Core` – Contains domain models and interfaces
  - `Infrastructure` – Data access layer (Repository pattern with SQLite)
  - `Application` – Business logic and service layer
  - `API` – Controllers and API endpoints (with Swagger)
- **Design Patterns Used**:
  - Repository Pattern
  - Dependency Injection
  - DTO Mapping (AutoMapper, if used)
- **API Documentation**: Swagger UI available at `/swagger`

### Frontend (`my-book-store-client`)
- **Framework**: Angular 19+
- **Design**: Simple, clean layout to display book and order data
- **Features**:
  - Integration with backend API
  - Displays book list and order history
- **Signal-based Implementation**: Considered and partially integrated with zoneless architecture in mind (if applicable)

---

## ✅ Features

- Browse and view books
- Place/view orders (mocked)
- Clean API endpoints
- Structured code ready to scale

---

## 🧪 Unit Tests

- Unit tests written using **xUnit** and **Moq**
- Example test case provided for one representative endpoint (`BooksController.GetAll`)
- Tests reside under `MyBookStore.Tests` project

---

## 🗃️ Database

- **SQLite** database used for persistence
- Pre-seeded data
- No setup or migrations required
- The `*.db` file is included in the repo, ready to run

---

## 🚀 How to Run the Application

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js (v20+)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

---

### Backend

```bash
cd MyBookStore.API
dotnet restore
dotnet build
dotnet run
