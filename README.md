# MVCSystem 
This project consists of three projects: Demo.PL, Demo.DAL, and Demo.BLL. Each project serves a specific purpose within the application, following a three-tier architecture.
## Project Structure
- Demo.PL: This project represents the presentation layer of the application. It contains the user interface components, including UI forms, views, and controllers. The presentation layer is responsible for handling user interactions and displaying data to the users.

- Demo.DAL: This project represents the data access layer of the application. It includes the necessary code to interact with the database and perform CRUD (Create, Read, Update, Delete) operations. The data access layer encapsulates the database-specific logic and provides an interface for the business logic layer to access and manipulate data.

- Demo.BLL: This project represents the business logic layer of the application. It contains the business rules, logic, and workflows that govern the application's behavior. The business logic layer processes the user input from the presentation layer, interacts with the data access layer to retrieve or modify data, and orchestrates the overall flow of the application.

## Three-Tier Architecture
The project follows a three-tier architecture, which separates the application into three distinct layers: presentation, business logic, and data access. This architectural pattern promotes modularity, scalability, and maintainability by enforcing separation of concerns.

- The presentation layer(Demo.PL) focuses on delivering a user-friendly interface and handling user interactions. It is responsible for presenting data to the user and collecting user input.

- The business logic layer(Demo.BLL) encapsulates the core functionality and rules of the application. It processes requests from the presentation layer, performs necessary computations, and coordinates data access operations.

- The data access layer(Demo.DAL) provides an abstraction for accessing and manipulating data from the underlying database. It handles the storage and retrieval of data, ensuring data integrity and security.

# The Project
