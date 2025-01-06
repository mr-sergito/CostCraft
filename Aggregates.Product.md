# Domain Models

## User

```csharp
class Product 
{
	Product Create(string name, int unitsProduced, decimal profitMarginPercentage);
	void AddMaterial(Material material);
	void AddLabor(Labor labor);
	void UpdateName(string name);
	void UpdateUnitsProduced(int unitsProduced);
	void UpdateProfitMarginPercentage(decimal profitMarginPercentage);
	void RemoveMaterial(Guid materialId);
	void RemoveLabor(Guid laborId);
	decimal CalculateUnitCost();
	decimal CalculateTotalCost();
	decimal CalculateSalePrice();
}
```

```json
{
	"id": { "value": "00000000-0000-0000-0000-000000000000" },
	"name": "Cake",
	"unitsProduced": 1,
	"userId": { "value": "00000000-0000-0000-0000-000000000000" },
	"createdAt": "2025-01-01T12:00:00Z",
	"updatedAt": "2025-01-02T12:00:00Z",
	"profitMarginPercentage": 200,
	"materials": [
		{
			"id": { "value": "00000000-0000-0000-0000-000000000000" },
			"name": "Flour",
			"purchasedAmount": 1,
			"purchasedUnit": "kg",
			"purchasedPrice": 2.00,
			"usedAmount": 0.25,
			"usedUnit": "kg",
			"usedCost": 0.50
		}
	],
	"labors": [
		{
			"id": { "value": "00000000-0000-0000-0000-000000000000" },
			"timeUnit": "hour",
			"timePayRate": 10.00,
			"timeWorked": 2,
			"timeCost": 20.00
		}
	],
	"totalCost": 20.50,
	"salePrice": 61.50
}
```