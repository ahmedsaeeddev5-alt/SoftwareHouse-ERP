<h1 align="center">📌 Task Management API</h1>

<p align="center">
A secure, scalable, and production-style <b>RESTful API</b> built with ASP.NET Core Web API following Clean Architecture and CQRS principles.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/Web%20API-ASP.NET-5C2D91?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/JWT-Security-black?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/CQRS-MediatR-green?style=for-the-badge"/>
</p>

---

## 🚀 Overview

The **Task Management API** is a backend-focused RESTful service designed to simulate real-world task management systems with secure authentication, role-based authorization, and scalable architecture.

It is built with a strong emphasis on:
- Clean Architecture
- Security best practices
- Maintainability
- Real-world backend design patterns

---

## ✨ Key Features

### 🔐 Authentication & Authorization
- User Registration & Login system
- JWT Authentication with custom claims
- Role-Based Authorization (Admin / User)
- Secure access control per endpoint

### 📌 Task Management
- Full CRUD operations for tasks
- User-specific task ownership validation
- Task status tracking
- Secure data access per user

### 📎 File Management
- Upload attachments for tasks
- Server-side validation
- Secure file handling and storage

### 🧠 Backend Engineering Features
- CQRS pattern using MediatR
- Global exception handling middleware
- Fluent validation & request validation
- Logging system for debugging & monitoring

---

## 🛠 Tech Stack

**Backend**
- ASP.NET Core Web API
- C#

**Database**
- SQL Server
- Entity Framework Core
- LINQ

**Security**
- ASP.NET Core Identity
- JWT Authentication

**Architecture & Patterns**
- CQRS (MediatR)
- Repository Pattern
- Clean Architecture
- DTO-based API design

**Tools**
- Swagger / Swashbuckle
- Postman

---

## 🧱 Architecture Overview

The system is structured into clean layers:

- 🏛 Presentation Layer (API Controllers)
- 🧠 Application Layer (CQRS - Commands & Queries)
- 🗄 Domain Layer (Entities & Core Logic)
- 💾 Infrastructure Layer (Database & External Services)

Key principles:
- Separation of Concerns
- Dependency Injection
- SOLID Principles
- Maintainable & testable structure

---

## 🔐 Authentication Flow

The API uses JWT-based authentication:

### Endpoints
- `POST /api/accounts/register`
- `POST /api/accounts/login`

### Usage Example
After login, include token in request header:

---

## 📌 API Endpoints

### 👤 Accounts
- POST `/api/accounts/register`
- POST `/api/accounts/login`

### 📋 Tasks
- GET `/api/tasks`
- GET `/api/tasks/{id}`
- POST `/api/tasks`
- PUT `/api/tasks/{id}`
- DELETE `/api/tasks/{id}`

---

## 📎 File Upload Feature

- Upload attachments per task
- Validation for file type & size
- Secure storage handling
- Linked to task entity

---

## 📸 API Documentation

Interactive API documentation available via Swagger:

- Swagger UI for testing endpoints
- Request/Response models documentation
- Easy Postman integration

---

## 🧪 Testing Tools

- Swagger UI (built-in)
- Postman collection support
- Manual API testing for validation

---
---

## 📸 Screenshots

### 🔹 Swagger UI
<p align="center">
  <img src="Screenshots/swagger-home.png" width="900" alt="Swagger UI"/>
</p>

---

### 🔹 User Registration
<p align="center">
  <img src="Screenshots/register.png" width="900" alt="User Registration"/>
</p>

---

### 🔹 User Login (JWT Token)
<p align="center">
  <img src="Screenshots/login.png" width="900" alt="User Login"/>
</p>

---

### 🔹 Get All Tasks
<p align="center">
  <img src="Screenshots/get-all-tasks.png" width="900" alt="Get All Tasks"/>
</p>

---

### 🔹 Create Task
<p align="center">
  <img src="Screenshots/create-task.png" width="900" alt="Create Task"/>
</p>

---

### 🔹 Update Task
<p align="center">
  <img src="Screenshots/update-task.png" width="900" alt="Update Task"/>
</p>

---

### 🔹 Delete Task
<p align="center">
  <img src="Screenshots/delete-task.png" width="900" alt="Delete Task"/>
</p>

---

### 🔹 JWT Token
<p align="center">
  <img src="Screenshots/JWT Token.png" width="900" alt="File Upload"/>
</p>

---

### 🔹 get by id task
<p align="center">
  <img src="Screenshots/get by id.png" width="900" alt="Database"/>
</p>

---

## 🎯 What This Project Demonstrates

- Building production-style RESTful APIs
- Implementing secure authentication systems (JWT + Identity)
- Applying CQRS pattern in real-world scenarios
- Designing scalable backend architecture
- Enforcing clean code and separation of concerns
- Handling user-based authorization logic

---

## 🚀 Future Improvements

- Refresh Token implementation
- Unit & Integration testing (xUnit)
- Caching layer (Redis)
- Rate limiting & throttling
- Background jobs (Hangfire)
- Advanced logging (Serilog + ElasticSearch)

---

## 💡 Key Takeaway

> “A strong backend system is not just functional — it is secure, scalable, and built with clear architectural boundaries.”

---

<p align="center">
🚀 Built with focus on enterprise-grade backend development and real-world system design
</p>
