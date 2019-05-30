## About the project

The API uses the presented json (I do not use the original url because there was an error in json's structure) and it takes its data and maintains it in a NoSql (Redis) structure.
And through your query, the data is queried from that database and presented to the client as requested.

## Some main structures / standards used

.NET Core, REST, OData, NoSQL, DOCKER, O.O., Dependency injection.

## What is necessary to run the application?

Have Docker running , set docker-compose project as a StartUp Project and press play in VS Debugger. 

## Some urls examples

http://10.5.0.5/api/catalog?$select=Price,Name

http://10.5.0.5/api/catalog?$orderby=Price

http://10.5.0.5/api/catalog?$top=2&$orderby=Name