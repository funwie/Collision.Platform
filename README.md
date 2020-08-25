# Collision.Platform Registration API

## Tech Stack
- ASP.Net core 3.1 and C#
- EF Core with InMemory Database
- Docker on Windows for deployment
- IIS deployment also possible
- Swagger


## Futher Improvements

This is a quick solution. There are many improvements before this can be considered a production ready solution. Some are:

Add Paging, Filtering, Sorting to Search and Get()

Spend more time to properly design for Domain Driven Design and utilise Event Sourcing, and Command Query Responsibility Segregation (CQRS) patterns. These will greatly decouple the microservice articheture and make it easier to deploy and scale the microservice independently.

Write More Tests

Add Response Layer to Abstract the Respose Status Code and the Response Value

Refactor to remove most of the code in the controller. I usually want controller actions to have at most 5 lines of code, 2 preferable.

