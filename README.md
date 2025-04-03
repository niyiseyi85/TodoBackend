# Todo App

A simple web application for managing todo lists, built with **.NET 9**, **React**, and **Clean Architecture**. It includes user authentication, todo management, and password reset functionality.

---

## **Features**
- **User Authentication**:
  - Register a new account.
  - Login with an existing account.
  - Forgot password (reset password via email).
- **Todo Management**:
  - View todo list.
  - Add a new todo item.
  - Update an existing todo item.
  - Delete a todo item.
    
---

## **Tech Stack**
- **Backend**:
  - .NET 9
  - ASP.NET Core
  - Entity Framework Core
  - MediatR (CQRS)
  - FluentValidation
  - JWT Authentication
- **Frontend**:
  - React (to be implemented)
- **Database**:
  - Postgres

---

## **Project Structure**


---

## **Setup**

### **Prerequisites**
- .NET 9 SDK
- Postgres
- React (for frontend, if applicable)

### **Steps**
1. Clone the repository:
   ```bash
   git clone https://github.com/niyiseyi85/TodoBackend.git
   cd todo-app

### **Backend**
cd backend
dotnet restore
dotnet ef database update --context IdentityDbContext
dotnet ef database update --context TodoDbContext
dotnet run
