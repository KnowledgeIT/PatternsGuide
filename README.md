# Patterns Guide and Coding Standards

![image](https://user-images.githubusercontent.com/42974994/127151809-7862c7cb-0bb8-42ee-8df4-a31e314de73c.png)

The objective of this project is to provide a guide to the development pattern of projects based on C# .Net Core, illustrating how to easily and simply implement concepts such as: REST, SOLID, E of APP, DDD, Anemic Domain Model, Dependency Injection, Unit of Work, Database-First, Entity Framework, Linq, Lambda, Async Processing, Exception Filters, Resource Files, Auto Mapper, Swagger, MongoDB, NLog, Unit Tests, Cross Cutting concerns, Coding Standards, etc.

This is a small version of a small project to record sales of various products that records purchase orders via a REST WEB API in a SQL database.

The first step is to change the connections with the database that are in the files: ContextBase.cs and ScaffoldContext.ps1, located in the Sales.Infrastructure project. The SQL database is in the SQL folder of this project:

![image](https://user-images.githubusercontent.com/42974994/127156996-c8dff15e-7ba1-4581-9279-eba98fe1339f.png)

If you want to log exceptions, create the environment variable: mongoConnection for your MongoDB instance, creating a "Logger" catalog and a "general" collection:

![image](https://user-images.githubusercontent.com/42974994/127156681-0b33a561-5a68-4f2a-95e7-aebb33e86e37.png)

After tuning the SQL database connections, you can start the API and start testing. There are already data in the tables and main ones and it is possible to create the Purchase Orders of the products through the endpoints: "/api/orders" and "/api/orders/bulkcreate".

![image](https://user-images.githubusercontent.com/42974994/127157898-11fed105-2155-4265-945e-5fee9924fdbc.png)

![image](https://user-images.githubusercontent.com/42974994/127157663-2e3a1e35-bce6-4f77-914b-0f87c811c6ce.png)

There are example files in the TDD project in the folder: TestData, such as the file "order.json" which is already configured to include three purchase orders with some products already saved in the database, calculating the values of the products and the pegged basic taxes:

![image](https://user-images.githubusercontent.com/42974994/127156580-82e3a27d-0de1-4158-83e7-3d5dc56ab790.png)

The endpoint: ​"/api​/orders​/{id}​/receipt" allows you to query the purchase order receipt by passing the Id generated in the previous endpoint. All inclusion endpoints return records saved in the database with their respective IDs for validation:

![image](https://user-images.githubusercontent.com/42974994/127156318-7fce53f7-b274-4860-a0ef-5a329fd66496.png)

<b>Note: The TDD project is still being adjusted. So, don't test the TDD for now. I'll provide another version fully functional as soon as possible.</b>

<b>IMPORTANT: This is a start of a project to illustrate a real-life project structure that is widely used in large companies. More examples will be added in this project such as, Web interface, Microservices architecture, Docker, Dapper, Authentication Patterns, among others. So at the moment I'm not accepting third party commits. Please don't create branches and don't change the sources of this project in my repository. They can be used as a great example for studies and applied to their personal and work projects. I hope they put it to good use ;)</b>
