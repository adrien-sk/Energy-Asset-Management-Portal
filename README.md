# 🌞 Energy Asset Management Portal

A comprehensive energy asset management platform for monitoring and maintaining solar power plants and storage batteries. Built with a .NET 8 backend and React + Carbon Design frontend, this project helps track asset performance, detect issues, and optimize energy usage — simulating the kind of tooling used in renewable energy operations.

*This project is an end-to-end demonstration of modern clean architecture and cloud-ready tooling in the context of renewable energy optimization.
It is actively evolving, and this README will be updated as planning, implementation, and features progress.*

## 🚀 Project Goals

- Build a realistic, production-quality backend following **Domain-Driven Design (DDD)** and **Clean Architecture**
- Implement **full CRUD operations** for managing energy sites, measurements, and alerts
- Provide a modern frontend dashboard to:
  - View site status and performance
  - Log and visualize measurements
  - Receive and manage alerts

## 📅 Status

✅ Done
  - Setup a Starting solution including :
    - Clean architecture solution
    - SQL Server DB and Entity framework
    - Global error handling middleware + Result pattern error management
    - Structured logging to dockerized Elasticsearch with Kibana dashboard
  - Follow DDD to define start point for Domain layers and entities, API routes, Commands and Queries
  - Basic CRUD API for Sites and Assets
  - Prepared Factory pattern implementation for Entity management
  - Add Mediatr for CQRS with Query/Command interface + Implementation for CreateSite + GetSites

🔧 Next Steps

  - Add Behaviors and validations
  - Implement a Generic Repository for standard CRUD 
  - [ ... ]

## 🧩 Tech Stack Overview

### 🔧 Backend

- C# (.NET 8) with ASP.NET Core Web API
- Entity Framework Core with SQL Server
- Clean Architecture + CQRS using MediatR
- xUnit for unit and integration testing
- Swagger/OpenAPI for auto-generated API docs
- Structured logging to Elastic search with Kibana dashboard
- Prometheus metrics and Grafana monitoring dashboard

### 🖥️ Frontend

- React 18 with Vite
- Carbon Design System
- SCSS for styling
- Vitest and React Testing Library for component testing

### ☁️ Infrastructure & DevOps

- SQL Server
- Docker & Docker Compose for local orchestration
- GitHub Actions (planned) for CI/CD


### 🔧 Event Storming

As part of the Domain Driven Design approach, I wanted to do the exercise of going through an Event Storming session around the domain of Energy asset management. Even if I have pretty basics knowledge about this domain, here is a draft diagram of the outcome that leads to define some Aggregates for entities, Commands and Events.


![image](docs/event_storming.png)

