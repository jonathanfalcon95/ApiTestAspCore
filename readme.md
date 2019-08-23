# ASP .NET Core REST API
Demo http://jfalcon.azurewebsites.net/api/users
API test 

## Endpoints

* `GET /api/users`: All users
* `GET /api/users/{id}`: A specific user
* `DELETE /api/users/{id}`: Delete a specific user
* `POST /api/users`: Create a new user, body example :
  ```bash
   {
        "userName": "AnaM",
        "name": "Ana",
        "lastName": "Mendoza",
        "age": 21,
    }
  ```
    
* `PUT /api/users/{id}`: Edit a specific user, body example
```bash
   {
        "Id": 1,
        "userName": "AnaM",
        "name": "Ana",
        "lastName": "Mendoza",
        "age": 21,
    }
```
* `GET /api/hardware`: All hardware
* `GET /api/hardware/{id}`: A specific hardware
* `DELETE /api/hardware/{id}`: Delete a specific hardware
* `POST /api/hardware`: Create a new hardware, body example :
 ```bash
   {
        "hardwareName": "Windows"
    }
  ```
    
* `PUT /api/hardware/{id}`: Edit a specific hardware, body example
```bash
   {
        "Id": 1,
        "hardwareName": "Mouse"
    }
```

* `GET /api/software`: All software
* `GET /api/software/{id}`: A specific software
* `DELETE /api/software/{id}`: Delete a specific software
* `POST /api/software`: Create a new software, body example :
 ```bash
   {
        "softwareName": "Windows"
    }
  ```
    
* `PUT /api/software/{id}`: Edit a specific software, body example
```bash
   {
        "Id": 1,
        "softwareName": "Windows"
    }
```
* `GET /api/assignment`: All assignments
* `GET /api/assignment/user/{id}`: A specifics assignments by user ID
* `POST /api/assignment`: Create a new assignment, body example :
 ```bash
   {
        "userID": 1,
        "softwareID": 1,
        "hardwareID": 1
    }
  ```
    


```
Note: Api runs by default in port 44362 with SSL, in Postman disabled SSL verification 
