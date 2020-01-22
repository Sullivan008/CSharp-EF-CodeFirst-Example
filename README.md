# C# - Entity Framework Code First Example Application [Year of Development: 2019]

About the application technologies and operation:

### Technologies:
- Programming Language: C#
- FrontEnd Side: **Not contains FrontEnd Side**
- BackEnd Side: .NET Framework 4.6.2.
- Database: SQL Server (Code First Database Migration)

### Installation/ Configuration:

1. Restore necessary Packages, run the following command in **PM Console**

   ```
   Update-Package -reinstall
   ```
 
### About the application:

**Entity Framework** introduced the **Code-First** approach with Entity Framework 4.1. **Code-First** is mainly useful in **Domain Driven Design**. 

**In the Code-First approach**, you focus on the domain of your application and start creating classes for your domain entity rather than design your database first and then create the classes which match your database design.

Let's assume that we want to create a simple application for XYZ Blog. Users of this Blog application should be able to add and update people, addresses, posts, and blog post types information.

The application shows the following:
- How to set **Table Keys**.
- How to set **DbSets**.
- How to set **Relations**: 
  - How to implement a **one-to-Zero-or-One** relationship between the following entities.
  - How to implement a **One-to-Many** relationship between the following entities with **Fluent API**.
- How to use **Data Annotation Attributes**.

### Helping PM Console Commands:

1. **Enable-Migrations**: Enables the migration in your project by creating a Configuration class.

   ```
   Enable-Migrations
   ```

2. **Add-Migrations**: Creates a new migration class as per specified name with the **Up()** and **Down()** methods.

   ```
   Add-Migrations Initial
   ```

3. **Update-Database**: Executes the last migration file created by the Add-Migration command and applies changes to the database schema.

   ```
   Update-Database -verbose
   ```
