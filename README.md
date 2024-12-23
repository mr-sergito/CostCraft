# CostCraft
ProdCost is a tool to help entrepreneus and small businesses calculate production costs.

## Features
1. Product cost calculation:
  - Add a new product and calculate the cost of producing one unit.
  - Allow users to input:
    - Product name and units produced.
    - Direct costs involved in production:
      - Materials: Name, purchased quantity, its measurement unit and price; and used quantity and its measurement unit.
      - Labor: Time rate, time unit and time worked. 
  - Automatically calculate:
    - Real price for one unit of the product and the total production.
    - Sale prices based on the desired profit percentage.
3. User account management:
  - Allow registered users to:
    - Save calculations.
    - View, edit, delete or create new calculations.
    - Change their password, update personal information or delete their account.

## Tech Stack

### Frontend
- Angular
- HTML
- SCSS

### Backend
- .NET 8
- Entity Framework Core

### Database
- SQL Server

### Authentication
- OAuth 2.0

### Testing
- xUnit

### Architecture
- Domain-Driven Design
- Even-Driven Design
- Clean Architecture
- Microservices Architecture
- Repository Pattern

### DevOps
- Git
- Github
- CI/CD with GitHub Actions
