## Create User

## Get User

### Get User Request

```js
GET /users/{{id}}
```

### Get User Response

```js
200 Ok
```

```js
{
 "id": { "value": "00000000-0000-0000-0000-000000000000" },
 "userName": "mr-sergito",
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

## Update User

### Update User Request

```js
PUT /users/{{id}}
```

```js
{
 "userName": "mr-sergito",
 "password": "mr-sergito123", // TODO: Hash this
 "preferredCurrency": "EUR",
 "productIds": [
  { "value": "00000000-0000-0000-0000-000000000000" },
  { "value": "00000000-0000-0000-0000-000000000000" },
 ],
}
```

### Update User Response

```js
204 No Content
```

```yml
Location: /users/{{id}}
```

## Delete User

### Delete User Request

```js
DELETE /users/{{id}}
```

### Delete User Response

```js
204 No Content
```
