# TodoBackend
Overview

This project is a Task Management System with user authentication and task management features. It is built using either Elixir (Phoenix Framework) or C# (.NET Core), with PostgreSQL as the preferred database.

Features

User authentication (Signup & Login)

Task management (Add, Fetch, and Delete tasks)

REST API with Swagger documentation

Relational database (PostgreSQL)

ORM: Ecto (for Elixir) or Entity Framework (for C#)

Technologies Used

Backend: Elixir (Phoenix Framework) / C# (.NET Core)

Database: PostgreSQL

ORM: Ecto (for Elixir) / Entity Framework (for C#)

API Documentation: Swagger (or equivalent)

Installation & Setup

Prerequisites

Ensure you have the following installed on your system:

PostgreSQL

Elixir & Phoenix (if using Elixir)

.NET SDK (if using C#)

Clone the Repository

git clone https://github.com/your-username/your-repo.git
cd your-repo

Setting Up the Database

Create a PostgreSQL database:

psql -U postgres
CREATE DATABASE task_management;

Running the Backend

If using Elixir (Phoenix Framework)

mix deps.get
mix ecto.setup
mix phx.server

If using C# (.NET Core)

dotnet restore
dotnet ef database update
dotnet run

API Endpoints

Method

Endpoint

Description

POST

/api/auth/signup

User Signup

POST

/api/auth/login

User Login

POST

/api/tasks

Add Task

GET

/api/tasks

Fetch All Tasks

DELETE

/api/tasks/:id

Delete Task

API Documentation

Swagger documentation is available at:

http://localhost:4000/swagger  (for Elixir)
http://localhost:5000/swagger  (for .NET Core)

Contributing

Fork the repository.

Create a new branch (git checkout -b feature-branch).

Commit your changes (git commit -m 'Add new feature').

Push to the branch (git push origin feature-branch).

Open a pull request.

License

This project is licensed under the MIT License.

Contact

For any inquiries or support, contact [your-email@example.com].
