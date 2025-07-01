# Mongo.GenericRepository

A reusable and extensible MongoDB generic repository for .NET applications. This library provides a clean, abstracted Data Access Layer (DAL) for working with MongoDB using repository patterns similar to Entity Framework Core, enabling consistent and testable data operations.

## 📦 Features

- Generic CRUD operations (`Get`, `Insert`, `Update`, `Delete`)
- LINQ-style filtering with expressions
- Pagination support
- Bulk insert and delete
- Pluggable via dependency injection
- Attribute-based configuration for database and collection mapping

## 🚀 Getting Started

### Installation

Install via NuGet:

```bash
dotnet add package Mongo.GenericRepository
