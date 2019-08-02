# ASP .NET Core REST API

API test 

## Endpoints

* `GET /api/users`: Quoation all users
* `GET /api/users/{id}`: a specific user
* `DELETE /api/users/{id}`: Delete a specific user
* `POST /api/users`: Create a new user, body example :
  
   {
        "userName": "AnaM",
        "name": "Ana",
        "lastName": "Mendoza",
        "age": 21,
    }
* `PUT /api/users/{id}`: Edit a specific user, body example
   {
        "Id": 1,
        "userName": "AnaM",
        "name": "Ana",
        "lastName": "Mendoza",
        "age": 21,
    }



```
Note: Api runs by default in port 44362 with SSL, in Postman disabled SSL verification 