# CostCraft
ProdCost is a tool to help entrepreneus and small businesses calculate production costs.

## Core Domain

The core domain is **Cost Calculation**. Everything revolves around providing an efficient, 
accurate and user-friendly way to calculate product costs.

## Bounded Contexts

**CostCraft** can be divided into these bounded contexts:
1. User management context
	- Handles user registration, authentication and profile management.
	- Distinction between guests and registered users.
2. Cost calculation context
	- Core logic for creating, managing and persisting cost calculations.
3. Export context
	- Handles exporting the calculation to PDF of spreadsheet formats.

## Aggregates and Entitites
**User Management Context**
- User (Aggregate Root)

    Attributes:
    - id (unique)
    - username (unique)
    - password
    - preferredCurrency
    - products (list of Product entities)

    Behaviors:
    - Register user.
    - Authenticate user.
    - Update user profile.

**Cost Calculation Context**

- Product (Aggregate Root)

    Attributes:
    - id (unique)
    - name
    - unitsProduced
    - createdAt
    - updatedAt
    - profitMarginPercentage
    - userId
    - materials (list of Material entities)
    - labors (list of Labor entities)

    Behaviors:
    - Add material.
    - Add labor.
    - Calculate unit cost.
    - Calculate total cost.
    - Calculate sale price.

- Material (Entity)

    Attributes:
    - id (unique)
    - name
    - purchasedAmount
    - purchasedUnit
    - purchasedPrice
    - usedAmount
    - usedUnit
    - productId

    Behaviors:
    - Calculate usedPrice based on usedAmount and purchasedPrice.

- Labor (Entity)

    Attributes:
    - timeUnit (e.g., hour, minute)
    - timePayRate
    - timeWorked
    - productId

    Behaviors:
    - Calculate calculatedCost based on timeWorked and timeRate.

## Services

1. UserService
	- Manages user registration, login and profile updates.
2. CostCalculationService
	- Orchestrates product cost calculation.
	- Handles persistence for registered users.
3. ExportService
	- Converts calculations to PDF or spreadsheet formats.

## Repositories
- UserRepository
	Handles persistence of user information.
- ProductRepository
	Handles persistence of product and cost calculation data.

## Value Objects
- Currency
	A value object encapsulating currency logic.
- ProfitPercentage
	Encapsulates the profit margin logic for calculating sale prices.

## Application Flow
**Guest Workflow:**
1. Guest opens the app and starts a new cost calculation.
2. Adds product, materials, labor and profit details.
3. Views calculated costs and sale price.
4. Prints or download the calculation as PDF or spreadsheet. 

**Registered User Workflow:**
1. Logs in or registers.
2. Starts a new cost calculation or selects an existing one.
3. Adds product, materials, labor and profit details.
4. Views calculated costs and sale price.
5. Prints or download the calculation as PDF or spreadsheet. 
7. Saves product cost calculation.

## User Interface Considerations
- Dashboard
	- Start a new cost calculation.
	- View saved products (registered users).

- Cost Calculation Screen
	- Input fields for product, materials, labor and profit margin.
	- Automatic calculations for costs and sale price.

- Profile Screen (for registered users)
    - View or edit username, password, and currency preference.