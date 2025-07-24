
# My Book Store Application
---

##  Project Structure

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
    
- **API Documentation**: Swagger UI available at `/swagger`

### Frontend (`my-book-store-client`)
- **Framework**: Angular 19+
- **Design**: Simple, clean layout to display book and order data
- **Features**:
  - Integration with backend API
  - Displays book list and order history

---
## 🧪 Unit Tests

- Unit tests written using **xUnit** and **Moq**
---

## 🗃️ Database

- **SQLite** database included — no script execution required

## 🚀 How to Run the Application
## Frontend 

- **npm install # Install Angular dependencies**

- **ng serve**

## Backend 
If you change the backend API port number, update the API URL in the Angular environment file:
- **Path: book-web/src/environments/environment.ts**
