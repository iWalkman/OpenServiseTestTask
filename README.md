# OpenServiseTestTask
1. GET
  You can get information about all database, and for each element
  for all: ```http://localhost:5000/api/users``` 
  for each: ```http://localhost:5000/api/users/{id}```
2. POST
  You can post information by link:
    ```http://localhost:5000/api/users```
    in format:
   ``` {"id":{id},"firstName":"Vaider","lastName":"Darth","posts":{"id":{id},"userId":{id},"content":"What a piece of ...!"}}```
3. PUT
    Put information to link:
    ```http://localhost:5000/api/users/{id}```
    in format:
    {"id":   {id},"firstName":"Vaider","lastName":"Darth","posts":{"id":{id},"userId":{id},"content":"What a piece of ...!"}}
4. DELETE
   By link:
   ```http://localhost:5000/api/users/{id}```
   