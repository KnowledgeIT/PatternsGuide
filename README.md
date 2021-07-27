# Patterns Guide and Coding Standards

![image](https://user-images.githubusercontent.com/42974994/127151809-7862c7cb-0bb8-42ee-8df4-a31e314de73c.png)

The objective of this project is to provide a guide to the development pattern of projects based on C# .Net Core, illustrating how to easily and simply implement concepts such as: REST, SOLID, E of APP, DDD, Anemic Domain Model, Dependency Injection, Unit of Work, Database-First, Entity Framework, Linq, Lambda, Async Processing, Exception Filters, Resource Files, Auto Mapper, Swagger, MongoDB, NLog, Unit Tests, Cross Cutting concerns, Coding Standards, etc.

This is a small version of a small project to record sales of various products that records purchase orders via a REST WEB API in a SQL database.

The first step is to change the connections with the database that are in the files: ContextBase.cs and ScaffoldContext.ps1, located in the Sales.Infrastructure project. The SQL database is in the SQL folder of this project.

If you want to log exceptions, create the environment variable: mongoConnection for your MongoDB instance, creating a "Logger" catalog and a "general" collection.

After tuning the SQL database connections, you can start the API and start testing. There are already data in the tables and main ones and it is possible to create the Purchase Orders of the products through the endpoints: "/api/orders" and "/api/orders/bulkcreate".

There are example files in the TDD project in the folder: TestData, such as the file "order.json" which is already configured to include three purchase orders with some products already saved in the database, calculating the values ​​of the products and the pegged basic taxes.

The endpoint: ​"/api​/orders​/{id}​/receipt" allows you to query the purchase order receipt by passing the Id generated in the previous endpoint. All inclusion endpoints return records saved in the database with their respective IDs for validation.

Note: This is a start of a project to illustrate a real project structure that is widely used in large companies. More examples will be added in this project such as, Web interface, Microservices architecture, Docker, Dapper, Authentication Patterns, among others. So at the moment I'm not accepting third party commits. Please don't create branches and don't change the sources of this project in my repository. They can be used as a great example for studies and applied to their personal and work projects. I hope they put it to good use ;)
