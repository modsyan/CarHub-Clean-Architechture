# CarHub

Proposal:
System to facilitate transparent and secure car storage and inspection processes. The system relies on modern technologies to enhance the user experience and ensure the accuracy and efficiency of operations. Through mobile applications and the dashboard, customers can easily track their cars and access the necessary information.

System Requirements:
Functional Requirements:
The "Car Control" app must allow users to submit requests for car storage and specify the required duration.
The system must enable the inspection of cars for scratches, record internal properties, and document the car's condition before storage.
The system must register and store customs documents and issue storage licenses.
The "My Garage" app should allow the car owner to track their car's status and storage duration.
The dashboard app should provide comprehensive information about stored cars and timeframes.

Non-Functional Requirements:
The system must be secure and protected to ensure the safety of user data and sensitive information.
The user interface should be user-friendly and visually appealing on mobile applications and the dashboard.
The system should comply with local and international quality and security standards.
The system should have high performance to ensure the quick processing of requests and updates.
Technical support should be available to users through various communication channels.


## Project description.
#### A Full System to Manage Cars with triptick system where we provided 3 applications

Applications:
- Car Hub (Dashboard) : To manage the overall system.
- Car Control (Mobile): Data Entry mobile application with staff to register cars and do with it multiple operations using mobile camera.
- My Garage (Car Owner): Application to Car Owner to track and send requests if needed to company when needed for owned cars.
- 
## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Code Scaffolding

The template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

If you encounter the error *"No templates or subcommands found matching: 'ca-usecase'."*, install the template and try again:

```bash
dotnet new install Clean.Architecture.Solution.Template::8.0.0
```

## Test

The solution contains unit, integration, and functional tests.

To run the tests:
```bash
dotnet test
```

## Help
To learn more about the template go to the [project website](https://github.com/JasonTaylorDev/Mac.CarHub). Here you can find additional guidance, request new features, report a bug, and discuss the template with other users.
