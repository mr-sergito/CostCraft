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
	"id": "00000000-0000-0000-0000-000000000000",
	"name": "Cake",
	"unitsProduced": 1,
	"createdAt": "2025-01-01T12:00:00Z",
	"updatedAt": "2025-01-02T12:00:00Z",
	"profitMarginPercentage": 200,
	"userId": "00000000-0000-0000-0000-000000000000",
	"materials": [
		{
			"id": "11111111-1111-1111-1111-111111111111",
			"name": "Flour",
			"purchasedQuantity": 1,
			"purchasedUnit": "kg",
			"purchasedPrice": 2.00,
			"usedQuantity": 0.25,
			"usedUnit": "kg",
			"usedCost": 0.50
		}
	],
	"labors": [
		{
			"id": "22222222-2222-2222-2222-222222222222",
			"timeUnit": "hour",
			"timeRate": 10.00,
			"timeWorked": 2,
			"timeCost": 20.00
		}
	],
	"totalCost": 20.50,
	"salePrice": 61.50
}
```