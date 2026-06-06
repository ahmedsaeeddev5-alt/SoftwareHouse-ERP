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

---

## 📁 File Upload Feature

- Upload attachments for tasks
- Server-side validation
- Secure file handling

---

## 📌 API Endpoints

### Auth
- POST `/api/accounts/register`
- POST `/api/accounts/login`

### Tasks
- GET `/api/tasks`
- GET `/api/tasks/{id}`
- POST `/api/tasks`
- PUT `/api/tasks/{id}`
- DELETE `/api/tasks/{id}`

---

## 🧪 Testing Tools

- Swagger UI
- Postman Collection

---

## 📷 Screenshots (Optional)

Add screenshots like:
- Swagger UI
- Login request
- Create task response

---

## 👨‍💻 Author

**Ahmed Saeed Reiyd**  
Full-Stack .NET Developer  
GitHub: https://github.com/ahmedsaeeddev5-alt  

---

## ⭐ Notes

This project demonstrates:
- Real-world backend API development
- Secure authentication & authorization
- Scalable architecture using CQRS
- Clean and maintainable code structure
