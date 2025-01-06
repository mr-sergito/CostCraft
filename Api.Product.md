## Create Product

### Create Product Request

```js
POST /users/{{id}}/products
```

```js
{
	"name": "Cake",
	"unitsProduced": 1,
	"profitMarginPercentage": 200,
	"materials": [
		{
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
			"timeUnit": "hour",
			"timePayRate": 10.00,
			"timeWorked": 2,
			"timeCost": 20.00
		}
	],
}
```

### Create Product Response

```js
201 Created
```

```yml
Location: users/{{id}}/products/{{id}}
```

```js
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

## Get Product

### Get Product Request

```js
GET /users/{{id}}/products/{{id}}
```

### Get Product Response

```js
200 Ok
```

```js
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

## Update Product

### Update Product Request

```js
PUT /users/{{id}}/products/{{id}}
```

```js
{
	"name": "Cake",
	"unitsProduced": 1,
	"profitMarginPercentage": 200,
	"materials": [
		{
			"id": { "value": "00000000-0000-0000-0000-000000000000" },
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
			"id": { "value": "00000000-0000-0000-0000-000000000000" },
			"timeUnit": "hour",
			"timePayRate": 10.00,
			"timeWorked": 2,
			"timeCost": 20.00
		}
	],
}
```

### Update Product Response

```js
204 No Content
```

```yml
Location: /users/{{id}}/products/{{id}}
```

## Delete Product

### Delete Product Request

```js
DELETE /users/{{id}}/products/{{id}}
```

### Delete Product Response

```js
204 No Content
```
