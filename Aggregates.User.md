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
	"id": "00000000-0000-0000-0000-000000000000",
	"username": "mr-sergito",
	"password": "mr-sergito123",
	"preferredCurrency": "EUR",
	"productIds": [
		"00000000-0000-0000-0000-000000000000",
		"00000000-0000-0000-0000-000000000000",
	],
}
```