# Pizza Shop Web API

This project implements a Web API for managing a pizza shop, providing various functionalities to interact with pizza orders and workers.

## Project Structure

The project is structured into different components:

- **Models**: Define the data structures for pizzas, orders, workers, and payment details.
- **Services**: Implement business logic for managing pizzas, orders, workers, and handling payment and invoice generation.
- **Controllers**: Expose APIs to interact with the system for creating, updating, deleting pizzas and orders, managing workers, and handling payments.

## Features

- **Pizza API**:
  - Implements CRUD operations for pizzas.
  - Supports POST, GET, PUT, and DELETE methods for managing pizzas.
  - Provides multiple types of routing configurations to handle different API requests.
  - Uses various forms of action results (ActionResult) to return responses.

- **Order API**:
  - Manages pizza orders, including creation, retrieval, and invoice generation.
  - Utilizes DI to inject dependencies, including a singleton lifetime for `PizzaService` and transient lifetime for `OrderService`.

- **Worker API**:
  - Handles worker management with role-based authorization.
  - Implements a controller for worker operations with scoped lifetime for the worker service.
  - Integrates attribute-based model validation and logs creation date for operations.

- **FileService**:
  - Implements file handling functionalities as a separate class library.
  - Includes functions for reading and writing objects of type T to a file.

- **Middleware**:
  - Adds custom middleware for logging HTTP requests and responses.
  - Logs request details such as date/time, HTTP method, action, parameters/body, headers, and response status code.
  - Utilizes `FileService` via DI for logging to a file.

- **Client Application**:
  - Includes HTML and JS files in the `wwwroot` directory for testing API actions.
  - Ensures that requests from the client to the API endpoints are correctly handled.

## Setup and Usage

### Prerequisites

- .NET Core SDK
- Visual Studio or Visual Studio Code

### How to Run

   - git clone https://github.com/LeahYudaikin/WebApi-PizzaProject.git
   - cd project
   - dotnet run
   - enter https://localhost:7140/


## User Interface:

### Login Page:
![image](https://github.com/LeahYudaikin/WebApi-PizzaProject/assets/151682731/e97a70ad-bc89-4430-8370-400652b4710b)

### Home Page:
![image](https://github.com/LeahYudaikin/WebApi-PizzaProject/assets/151682731/651e4955-eca8-4478-9524-cbd53424bd3e)

### Orders Page:
![image](https://github.com/LeahYudaikin/WebApi-PizzaProject/assets/151682731/3013d4f1-f1d9-4d39-b247-4a02ea3a1a0f)

### Examples:
![image](https://github.com/LeahYudaikin/WebApi-PizzaProject/assets/151682731/9d081a1a-1b5b-42ed-b779-d1165e76f3d7)


## Thank You
I appreciate the opportunity to present this project. If you have any questions or comments, please feel free to contact me.

Thank you and enjoy the project!
