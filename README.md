# 🏢 Software House ERP

> A modern full-stack Enterprise Resource Planning (ERP) system designed to manage employees, clients, projects, tasks, finance, attendance, leave requests, contracts, invoices, payments, and expenses.

**Software House ERP** is a portfolio-grade business management application built with **ASP.NET Core Web API** and **Angular**, following a clean and maintainable architecture with authentication, role-based authorization, CQRS, Entity Framework Core, and SQL Server.

---

## ✨ Key Features

### 🔐 Authentication & Authorization

* User registration and login
* ASP.NET Core Identity
* JWT Authentication
* Role-Based Authorization
* Protected API endpoints
* User-specific access control
* Secure password management

### 👥 Employee Management

* Create, update, view and delete employees
* Employee profiles
* Department assignment
* Employee status management
* Search and filtering

### 🏢 Client Management

* Client CRUD operations
* Client contact information
* Client status management
* Client-project relationship

### 📁 Project Management

* Project creation and management
* Assign projects to clients
* Project status tracking
* Start and end dates
* Project details
* Project-related tasks and milestones

### ✅ Task Management

* Create and manage tasks
* Assign tasks to employees
* Task status tracking
* Priority management
* Due dates
* Project-based task organization

### 🎯 Milestone Management

* Project milestones
* Start and due dates
* Milestone status
* Project progress tracking

### 🏬 Department Management

* Department CRUD
* Employee department assignment
* Department-based organization

### 💰 Finance Management

The ERP includes several financial modules:

* Contracts
* Invoices
* Payments
* Expenses
* Currency management
* Payment status tracking
* Expense categorization
* Invoice-payment relationships

### 🕒 Attendance Management

* Employee attendance records
* Check-in / Check-out
* Attendance status
* Attendance notes
* Attendance history

### 🌴 Leave Management

* Leave request creation
* Employee leave requests
* Leave types
* Start and end dates
* Approval status
* Request reasons and notes

### 📊 Reports & Dashboard

* Business overview
* Project statistics
* Employee statistics
* Financial information
* Visual data representation using charts

---

# 🛠️ Tech Stack

## Backend

| Technology            | Purpose               |
| --------------------- | --------------------- |
| ASP.NET Core Web API  | RESTful API           |
| C#                    | Backend development   |
| Entity Framework Core | ORM / Database access |
| SQL Server            | Relational database   |
| ASP.NET Core Identity | User management       |
| JWT                   | Authentication        |
| MediatR               | CQRS implementation   |
| AutoMapper            | Object mapping        |
| LINQ                  | Data querying         |
| Swagger / OpenAPI     | API documentation     |

## Frontend

| Technology        | Purpose                 |
| ----------------- | ----------------------- |
| Angular           | Frontend framework      |
| TypeScript        | Frontend development    |
| HTML5             | UI structure            |
| CSS3              | Styling                 |
| Bootstrap         | Responsive UI           |
| Bootstrap Icons   | UI icons                |
| Chart.js          | Data visualization      |
| Reactive Forms    | Form management         |
| HttpClient        | API communication       |
| Route Guards      | Route protection        |
| HTTP Interceptors | Authentication handling |

## Database

* Microsoft SQL Server
* Entity Framework Core
* Code First
* EF Core Migrations
* Relational database design

---

# 🏗️ Architecture

The project follows a layered architecture designed to keep business logic separated from infrastructure and presentation concerns.

```text
SoftwareHouseERP
│
├── Backend
│   │
│   ├── API
│   │   ├── Controllers
│   │   ├── Middleware
│   │   └── Configuration
│   │
│   ├── Application
│   │   ├── Features
│   │   ├── DTOs
│   │   ├── Commands
│   │   ├── Queries
│   │   └── Handlers
│   │
│   ├── Domain
│   │   ├── Entities
│   │   ├── Enums
│   │   └── Interfaces
│   │
│   └── Infrastructure
│       ├── Data
│       ├── Repositories
│       ├── Identity
│       └── Services
│
└── Frontend
    │
    ├── src
    │   ├── app
    │   │   ├── core
    │   │   ├── services
    │   │   ├── guards
    │   │   ├── interceptors
    │   │   ├── features
    │   │   └── shared
    │   │
    │   └── assets
    │
    └── angular.json
```

> The actual folder structure may vary depending on the current project implementation.

---

# 🔄 Application Flow

```text
Angular Frontend
       │
       │ HTTP / REST API
       ▼
ASP.NET Core Web API
       │
       ├── Authentication / Authorization
       │
       ├── Controllers
       │
       ├── MediatR / CQRS
       │
       ├── Application Services
       │
       └── Entity Framework Core
                    │
                    ▼
              SQL Server
```

---

# 🔐 Security

The application implements authentication and authorization using:

* ASP.NET Core Identity
* JWT Bearer Authentication
* Role-Based Authorization
* Secure API endpoints
* Protected Angular routes
* HTTP Authentication Interceptor
* Route Guards

Example roles:

```text
Admin
User
```

Additional roles can be introduced depending on business requirements.

---

# 📦 Main ERP Modules

```text
Dashboard
│
├── Employees
│
├── Departments
│
├── Clients
│
├── Projects
│   ├── Project Details
│   ├── Tasks
│   └── Milestones
│
├── HR
│   ├── Attendance
│   └── Leave Requests
│
├── Finance
│   ├── Contracts
│   ├── Invoices
│   ├── Payments
│   └── Expenses
│
└── Reports
```

---

# 🚀 Getting Started

## Prerequisites

Before running the project, make sure you have:

* .NET SDK
* SQL Server
* Visual Studio 2022 or later
* Node.js
* Angular CLI
* Git

Check your installed versions:

```bash
dotnet --version
node --version
npm --version
ng version
```

---

# ⚙️ Backend Setup

### 1. Clone the repository

```bash
git clone https://github.com/ahmedsaeeddev5-alt/SoftwareHouse-ERP.git
```

### 2. Navigate to the backend project

```bash
cd SoftwareHouse-ERP
```

Navigate to the ASP.NET Core API project directory according to the project structure.

### 3. Configure SQL Server

Update the connection string in your local configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SoftwareHouseERPDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> Do not commit production credentials, passwords, API keys, or other sensitive configuration values to GitHub.

### 4. Apply EF Core migrations

```bash
dotnet ef database update
```

### 5. Run the API

```bash
dotnet run
```

The API will be available through the configured local HTTP/HTTPS ports.

---

# 🌐 Frontend Setup

Navigate to the Angular application:

```bash
cd frontend
```

Install dependencies:

```bash
npm install
```

Run the development server:

```bash
ng serve
```

Open:

```text
http://localhost:4200
```

---

# 📖 API Documentation

The backend provides interactive API documentation through **Swagger / OpenAPI**.

After starting the ASP.NET Core API, open:

```text
/swagger/index.html
```

Swagger can be used to:

* Explore available endpoints
* Test API requests
* Review request/response models
* Test authentication-protected endpoints

---

# 🧪 API Testing

The API can be tested using:

* Swagger
* Postman

Typical authentication flow:

```text
Register
   ↓
Login
   ↓
Receive JWT
   ↓
Send JWT with API requests
   ↓
Access protected endpoints
```

Example:

```http
Authorization: Bearer <JWT_TOKEN>
```

---

# 📁 Project Structure

A simplified representation of the application:

```text
SoftwareHouseERP/
│
├── Backend/
│   ├── Controllers/
│   ├── Data/
│   ├── Models/
│   ├── DTOs/
│   ├── Services/
│   ├── Features/
│   ├── Repositories/
│   ├── Migrations/
│   └── Program.cs
│
├── Frontend/
│   ├── src/
│   │   └── app/
│   │       ├── core/
│   │       ├── services/
│   │       ├── guards/
│   │       ├── interceptors/
│   │       ├── features/
│   │       └── shared/
│   │
│   ├── angular.json
│   ├── package.json
│   └── tsconfig.json
│
├── .gitignore
└── README.md
```

---

# 🎨 UI & UX

The application follows a modern ERP dashboard design approach:

* Responsive layout
* Clean navigation
* Consistent color and spacing system
* Bootstrap Icons
* Responsive tables
* Modern forms
* Status badges
* Loading states
* Error handling
* Empty states
* Mobile-friendly layouts
* Reusable UI patterns

The interface is designed to provide a professional business-management experience rather than a basic CRUD application.

---

# 📈 Future Improvements

Planned improvements may include:

* Advanced reporting
* Export reports to PDF / Excel
* Advanced dashboard analytics
* Notification system
* Email notifications
* Audit logging
* Advanced search and filtering
* Pagination improvements
* File/document management
* Role and permission management
* Deployment using Docker
* CI/CD pipeline
* Cloud deployment

---

# 🎯 Project Goals

This project was built to demonstrate practical experience with:

* Full-Stack .NET development
* RESTful API development
* Angular application development
* SQL Server database design
* Entity Framework Core
* Authentication and authorization
* CQRS and MediatR
* Clean and maintainable architecture
* Dependency Injection
* Repository Pattern
* SOLID principles
* Responsive UI development
* Real-world ERP business workflows

---

# 👨‍💻 Author

## Ahmed Saeed Reiyd

**Full-Stack .NET Developer**

Specialized in:

```text
ASP.NET Core
C#
Web API
Angular
Entity Framework Core
SQL Server
TypeScript
REST APIs
JWT Authentication
CQRS / MediatR
```

### GitHub

https://github.com/ahmedsaeeddev5-alt

### LinkedIn

https://www.linkedin.com/in/ahmed-saeed-928884199/

---

# ⭐ Support

If you find this project useful or interesting, consider giving the repository a ⭐ on GitHub.

---

## 📄 License

This project is intended for educational and portfolio purposes.
