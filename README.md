# 🏦 Multiple-Layered Banking Credit System with CursorAI

A modular, multi-layered Web API project designed for managing banking credit operations, developed using AI-assisted programming via Cursor. This system supports both individual and corporate customers, providing endpoints for customer registration, credit applications, and more.

---

## 📌 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## 📖 Overview

This project is a comprehensive banking credit system developed as a multi-layered Web API. Utilizing AI assistance through the Cursor IDE, the development process involved iterative prompt engineering and refinement to ensure robust functionality. The system caters to both individual and corporate clients, handling customer records, credit applications, and more.

---

## 🚀 Features

- **Multi-layered Architecture**: Separation of concerns through distinct layers: Application, Core, Domain, Persistence, and Web API.
- **Customer Management**: Endpoints for registering and managing both individual and corporate customers.
- **Credit Applications**: Functionality to handle credit application processes.
- **Authentication**: JWT-based authentication for secure access.
- **Middleware Integration**: Custom middleware for logging, error handling, and request processing.
- **Entity Framework Core**: ORM for database interactions.
- **CursorAI Integration**: Leveraged AI for code generation and optimization.

---

## 🧱 Architecture

The project follows a clean, modular architecture:

```
BankCreditApp/
├── Application/           # Business logic and service interfaces
├── Core/                  # Core entities and enums
├── Domain/                # Domain models and interfaces
├── Persistence/           # Data access layer using EF Core
├── WebApi/                # API controllers and middleware
├── BankCreditApp.sln      # Solution file
```

---

## 🛠️ Technologies Used

- **.NET 9**
- **Entity Framework Core**
- **JWT (JSON Web Tokens)**
- **CursorAI**
- **Swagger**
- **AutoMapper**
- **MediatR**

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/MushafAkkaya/Multiple-Layered-Banking-Credit-System-With-CursorAI.git
   ```

2. **Navigate to the project directory**:
   ```bash
   cd Multiple-Layered-Banking-Credit-System-With-CursorAI
   ```

3. **Set up the database**:
   - Update the connection string in `appsettings.json`.
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```

4. **Run the application**:
   ```bash
   dotnet run --project BankCreditApp.WebApi
   ```

5. **Access Swagger**:
   ```
   https://localhost:{port}/swagger
   ```

---

## 📡 API Endpoints

### 🧍 Individual Customers

| Method | Endpoint                         | Description                      |
|--------|----------------------------------|----------------------------------|
| POST   | `/api/IndividualCustomers`       | Create an individual customer    |
| GET    | `/api/IndividualCustomers`       | Get all individual customers     |
| GET    | `/api/IndividualCustomers/{id}`  | Get individual customer by ID    |
| PUT    | `/api/IndividualCustomers`       | Update individual customer       |
| DELETE | `/api/IndividualCustomers/{id}`  | Delete individual customer       |

### 🏢 Corporate Customers

| Method | Endpoint                          | Description                      |
|--------|-----------------------------------|----------------------------------|
| POST   | `/api/CorporateCustomers`         | Create a corporate customer      |
| GET    | `/api/CorporateCustomers`         | Get all corporate customers      |
| GET    | `/api/CorporateCustomers/{id}`    | Get corporate customer by ID     |
| PUT    | `/api/CorporateCustomers`         | Update corporate customer        |
| DELETE | `/api/CorporateCustomers/{id}`    | Delete corporate customer        |

### 💳 Credit Applications

| Method | Endpoint                                             | Description                           |
|--------|------------------------------------------------------|---------------------------------------|
| POST   | `/api/CreditApplications/individual`                | Apply for credit (individual)         |
| GET    | `/api/CreditApplications/customer/{customerId}`     | Get applications by customer ID       |

### 🏦 Credit Types

| Method | Endpoint                                               | Description                              |
|--------|--------------------------------------------------------|------------------------------------------|
| POST   | `/api/CreditTypes/individual`                          | Create individual credit type            |
| POST   | `/api/CreditTypes/corporate`                           | Create corporate credit type             |
| GET    | `/api/CreditTypes/individual/eligible`                 | Get eligible credit types (individual)   |
| GET    | `/api/CreditTypes/corporate/eligible`                  | Get eligible credit types (corporate)    |
| PUT    | `/api/CreditTypes/individual/{id}/status`              | Update status of individual credit type  |
| PUT    | `/api/CreditTypes/corporate/{id}/status`               | Update status of corporate credit type   |

---

## 📸 Screenshots

### Swagger UI

![Swagger UI Screenshot](./assets/swagger-ui.png)

> To display this image, add your screenshot under `assets/swagger-ui.png` in the repo.

---

## 🤝 Contributing

Contributions are welcome!

1. Fork the repository  
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)  
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)  
4. Push to the branch (`git push origin feature/AmazingFeature`)  
5. Open a Pull Request  

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.txt) file for details.

---

## 📬 Contact

- **Author**: Mushaf Akkaya  
- **GitHub**: [@MushafAkkaya](https://github.com/MushafAkkaya)  
- **Email**: mushafakkaya@hotmail.com  

> Developed with AI assistance using Cursor IDE.
