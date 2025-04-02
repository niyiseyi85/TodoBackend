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
  - Mark a todo item as complete.

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
  - SQL Server

---

## **Project Structure**


---

## **Setup**

### **Prerequisites**
- .NET 9 SDK
- SQL Server
- Node.js (for frontend, if applicable)

### **Steps**
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/todo-app.git
   cd todo-app

### **Backend**
cd backend
dotnet restore
dotnet ef database update --context IdentityDbContext
dotnet ef database update --context TodoDbContext
dotnet run

### **Frontend**
cd frontend
npm install
npm start


