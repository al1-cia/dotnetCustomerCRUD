Customers CRUD Application

This is a simple ASP.NET Core (.NET) project demonstrating full CRUD (Create, Read, Update, Delete) functionality. The application uses Razor Pages for the UI and Microsoft SQL Server for data storage.

**Technologies Used**

  ASP.NET Core (.NET)
  
  Razor Pages
  
  Microsoft SQL Server
  
  Entity Framework Core
  
  SQL Server Management Studio (SSMS)

Clone the repository to Visual Studio.

Create database named CustomersDB in SSMS. In appsettings.json, update the connection string to match your SQL Server instance.

The customers table has ID, Name, and isBlocked columns.

**Features**

  Create new customers (C)
  
  View all customers (R)
  
  Block customers (U)
  
  Delete customers (D)
  
  RESTful API endpoints
  
  Repository pattern implementation
