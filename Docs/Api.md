## Login

```json
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email": "yesirkepov03@gmail.com",
    "password": "Qwerty1"
}
```

```js
200 ok
```

#### Login Response

```json
{
    "id": "0dba1fdc-5175-478d-8231-71e9557d6960",
    "firstName": "Daulet",
    "lastName": "Yesirkepov",
    "email": "yesirkepov03@gmail.com",
    "token": "eyJhbGciOiJ"
}
```