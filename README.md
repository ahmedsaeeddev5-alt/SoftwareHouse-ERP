# 📌 Task Management API

A secure and scalable RESTful Task Management API built with ASP.NET Core Web API following Clean Architecture principles.

---

## 🚀 Features

- User Registration & Login
- JWT Authentication with Custom Claims
- Role-based Authorization
- Task CRUD Operations
- User-specific task ownership validation
- File Upload for task attachments
- CQRS Pattern using MediatR
- Global Exception Handling
- Input Validation & Logging
- Swagger API Documentation

---

## 🛠️ Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- MediatR (CQRS Pattern)
- Repository Pattern
- Swagger / Swashbuckle

---

## 🧱 Architecture

- Layered Architecture
- Separation of Concerns
- CQRS (Command Query Responsibility Segregation)
- DTOs for API Contracts
- Clean Code Principles

---

## 🔐 Authentication

The API uses JWT Authentication.

### Endpoints:
- Register: `POST /api/accounts/register`
- Login: `POST /api/accounts/login`

### Usage:
Add token in Authorization header:
