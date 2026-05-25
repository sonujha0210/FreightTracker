# FreightTrack API

A logistics shipment tracking REST API built with ASP.NET Core 7, Onion Architecture, Entity Framework Core, MySQL, and JWT Authentication with Role-Based Access Control.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Backend Framework | ASP.NET Core 10 |
| Architecture | Onion Architecture (4 layers) |
| ORM | Entity Framework Core |
| Database | MySQL |
| Authentication | JWT Bearer Tokens |
| Authorization | Role-Based Access Control (RBAC) |
| Password Hashing | BCrypt |

---

## Project Structure

```
FreightTrack/
├── FreightTrack.Domain/          # Entities only — no dependencies
├── FreightTrack.Application/     # Interfaces, DTOs, service contracts
├── FreightTrack.Infrastructure/  # EF Core, repositories, DB context
└── FreightTrack.API/             # Controllers, middleware, JWT config
```

**Dependency direction:**
```
API → Infrastructure → Application → Domain
```
Domain has zero external dependencies.

---

## Features

- **Shipment Management** — Create, read, update shipments with unique tracking numbers
- **Tracking History** — Log and retrieve tracking events per shipment
- **JWT Authentication** — Register and login to receive a signed JWT token
- **Role-Based Access Control** — Admin and Customer roles with protected endpoints
- **Query Filters** — Filter shipments by status, date range, and customer ID
- **CSV Export** — Download shipment data as a CSV file
- **Global Exception Handling** — All errors return structured JSON responses

---

## API Endpoints

### Auth
| Method | Endpoint | Access | Description |
|---|---|---|---|
| POST | `/auth/register` | Public | Register a new user |
| POST | `/auth/login` | Public | Login and receive JWT token |

### Shipments
| Method | Endpoint | Access | Description |
|---|---|---|---|
| POST | `/shipments` | Admin | Create a new shipment |
| GET | `/shipments/{id}` | Auth | Get shipment by ID |
| PUT | `/shipments/{id}` | Admin | Update shipment details |
| GET | `/shipments` | Auth | Get all shipments (with filters) |
| GET | `/shipments/export` | Admin | Download shipments as CSV |

### Tracking
| Method | Endpoint | Access | Description |
|---|---|---|---|
| POST | `/shipments/{id}/events` | Admin | Add a tracking event |
| GET | `/shipments/{id}/history` | Auth | Get full tracking history |

---

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [MySQL](https://www.mysql.com/downloads/) (MySQL Workbench recommended)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
- [Postman](https://www.postman.com/) for API testing

### 1. Clone the repository

```bash
git clone https://github.com/sonujha0210/FreightTrack.git
cd FreightTrack
```

### 2. Configure the database connection

Open `FreightTrack.API/appsettings.json` and update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=FreightTrackDb;User=root;Password=YOUR_PASSWORD;"
}
```

### 3. Configure JWT settings

In `appsettings.json`, update the JWT section:

```json
"JwtSettings": {
  "Secret": "your-secret-key-minimum-32-characters",
  "Issuer": "FreightTrackAPI",
  "Audience": "FreightTrackClient",
  "ExpiryMinutes": 60
}
```

### 4. Apply database migrations

```bash
cd FreightTrack.API
dotnet ef database update
```

### 5. Run the API

```bash
dotnet run --project FreightTrack.API
```

The API will be available at `https://localhost:7000` (or the port shown in your terminal).

---

## Testing with Postman

1. Register a user via `POST /auth/register`
2. Login via `POST /auth/login` — copy the JWT token from the response
3. For protected endpoints, add the token to the Authorization header:
   ```
   Authorization: Bearer <your_token_here>
   ```

---

## Database Schema

### Customer
| Field | Type | Notes |
|---|---|---|
| Id | int | Primary key |
| Name | string | Full name |
| Email | string | Unique, used for login |
| PasswordHash | string | BCrypt hashed |
| Role | string | Admin or Customer |
| CreatedAt | DateTime | Auto set on creation |

### Shipment
| Field | Type | Notes |
|---|---|---|
| Id | int | Primary key |
| TrackingNumber | string | Unique, auto-generated |
| Status | string | Pending, InTransit, Delivered, Failed |
| Origin | string | Source location |
| Destination | string | Target location |
| CustomerId | int | Foreign key to Customer |
| CreatedAt | DateTime | Auto set on creation |
| UpdatedAt | DateTime | Auto updated on change |

### TrackingEvent
| Field | Type | Notes |
|---|---|---|
| Id | int | Primary key |
| ShipmentId | int | Foreign key to Shipment |
| Status | string | Status at this point in transit |
| Location | string | Where the event occurred |
| Timestamp | DateTime | When the event occurred |
| Notes | string | Optional notes |

---

## NuGet Packages

| Package | Project | Purpose |
|---|---|---|
| Pomelo.EntityFrameworkCore.MySql | Infrastructure | MySQL provider for EF Core |
| Microsoft.EntityFrameworkCore.Tools | Infrastructure | Migrations |
| Microsoft.EntityFrameworkCore.Design | API | Migration CLI support |
| Microsoft.AspNetCore.Authentication.JwtBearer | API | JWT token validation |
| BCrypt.Net-Next | Infrastructure | Password hashing |

---

## Author

**Sonukumar Jha**  
GitHub: [@sonujha0210](https://github.com/sonujha0210).
