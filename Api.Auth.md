## Register

### Register Request

```js
POST /auth/register
```

```js
{
	"username": "mr-sergito",
	"password": "mr-sergito123"
}
```

### Register Response

```js
201 Created
```

```js
{
	"id": { "value": "00000000-0000-0000-0000-000000000000" },
	"username": "mr-sergito",
	"password": "mr-sergito123", // TODO: Hash this
}
```

## Login

### Login Request

```js
POST /auth/login
```

```js
{
	"username": "mr-sergito",
	"password": "mr-sergito123"
}
```

### Login Response

```js
200 Ok
```

```yml
Location: /users/{{id}}
```

```js
{
	"id": { "value": "00000000-0000-0000-0000-000000000000" },
	"username": "mr-sergito",
	"password": "mr-sergito123", // TODO: Hash this
}
```
