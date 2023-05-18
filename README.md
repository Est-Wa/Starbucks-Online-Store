# Starbucks Online Store
This is an online store for Starbucks coffee and products, built using ASP.NET Core 7.0. The project follows a REST API architecture and incorporates server-side and client-side validations for enhanced security. It emphasizes password strength checks to ensure the safety of user accounts. 
The project is structured based on a layered model and utilizes Dependency Injection (DI) for loose coupling and improved testability. 
Async-await is used throughout the application to support scalability. 
The project also includes a DTO layer with object mapping using AutoMapper in order to prevent circular dependencies between objects and provide encapsulation..

## Technologies
-	C#
-	ASP.NET Core 7.0
## Packages
### The project utilizes the following packages:
-	Entity Framework Core: Used for ORM and database operations.
-	NLog: Provides logging functionality.
-	NLog.MailKit: Integrates NLog with MailKit for email notifications.
-	AutoMapper: Enables object mapping between entities and DTOs.
-	zxcvbn-core: Provides password strength checking capabilities.
-	Swashbuckle: Integrates Swagger for API documentation.
## Installation
To set up and run the Starbucks Online Store on your local machine, follow these steps:
1.	Clone the repository to your local machine: git clone Est-Wa/WebApiWebsite
2.	Open the project in your preferred IDE.
3.	Build the project to restore dependencies and compile the code.
4.	Run the application.
## Usage
Once the application is running, you can interact with the Starbucks Online Store through its API endpoints. You can use a web browser or tools like Swagger to explore and interact with the available endpoints.
Configuration
The project's configuration can be found in the appsettings.json file. It includes settings such as the database connection string.
## Contributors
- [Bracha Heimowitz](https://github.com/bhandho)
- [Esther Wanderer](https://github.com/Est-Wa)




