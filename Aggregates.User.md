# Domain Models

## User

```csharp
class User
{
	User Create(string username, string password, string preferredCurrency);
	void AddProduct(Product product);
	void RemoveProduct(Guid productId);
	void UpdateUsername(string username);
	void UpdatePassword(string password);
	void UpdatePreferredCurrency(string currency);
	Product GetProduct(Guid productId);
	IEnumerable<Product> GetAllProducts();
}
```

```json
{
	"id": { "value": "00000000-0000-0000-0000-000000000000" },
	"username": "mr-sergito",
	"password": "mr-sergito123", // TODO: Hash this
	"preferredCurrency": "EUR",
	"createdAt": "2025-01-01T12:00:00Z",
	"updatedAt": "2025-01-02T12:00:00Z",
	"productIds": [
		{ "value": "00000000-0000-0000-0000-000000000000" },
		{ "value": "00000000-0000-0000-0000-000000000000" },
	],
}
```