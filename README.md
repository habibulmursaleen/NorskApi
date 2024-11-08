# Norsk API

A very comprehensive backend api for norsk learning application. 

## Table of contents

- [Norsk API](#norsk-api)
  - [Table of contents](#table-of-contents)
    - [Requirements](#requirements)
    - [Architecture Overview](#architecture-overview)
    - [Setup](#setup)
      - [Step 1: Clone the Repository](#step-1-clone-the-repository)
      - [Step 2: Restore NuGet Packages](#step-2-restore-nuget-packages)
      - [Step 3: Set Up Docker and Database](#step-3-set-up-docker-and-database)
      - [Step 3: Apply Migrations](#step-3-apply-migrations)
      - [Step 4: Build and Run the Application](#step-4-build-and-run-the-application)
      - [Test](#test)
  - [Endpoints](#endpoints)
      - [LocalExpressions Endpoint](#localexpressions-endpoint)
      - [Dictation Endpoint](#dictation-endpoint)
      - [Podcast Endpoint](#podcast-endpoint)
      - [Discussion Endpoint](#discussion-endpoint)
      - [Question Endpoint](#question-endpoint)
      - [Roleplay Endpoint](#roleplay-endpoint)
      - [Quiz Endpoint](#quiz-endpoint)
      - [Word Endpoint](#word-endpoint)
      - [Essay Endpoint](#essay-endpoint)
      - [Grammar Topic Endpoint](#grammar-topic-endpoint)
      - [Grammar Rule Endpoint](#grammar-rule-endpoint)
      - [Tasks Endpoint](#tasks-endpoint)
      - [Subjunction Endpoint](#subjunction-endpoint)

![Norsk API Aggregate](norskapi.png)

This project follows Clean Architecture principles combined with Domain-Driven Design (DDD) to create a maintainable and scalable .NET application.

### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any database of your choice)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (Recommended for development)
- [Docker](https://www.docker.com/) 

### Architecture Overview

This project is structured based on Clean Architecture, with separation into the following main layers:

- **Core** - Contains the Domain layer, including entities, aggregates, value objects, and domain services.
- **Application** - Contains use cases, DTOs, and interfaces.
- **Infrastructure** - Contains the implementations of repositories, data access, and integrations.
- **WebApi** - The entry point for the API, handling requests and responses.

### Setup

####  Step 1: Clone the Repository

```bash
git clone https://github.com/habibulmursaleen/NorskApi
cd NorskApi
```

####  Step 2: Restore NuGet Packages
Run the following command to restore the necessary NuGet packages:

```bash
dotnet clean
dotnet restore
```

####  Step 3: Set Up Docker and Database
Ensure your SQL Server is running. Update the connection string in appsettings.Development.json located in the Api project:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=norskapi;User Id=your_userId;Password=your_password;Pooling=true;Min Pool Size=10;Max Pool Size=200;Connection Lifetime=180;Connection Timeout=30;Encrypt=false;"
  }
}
```
Go to the root of the folder and run - (if you already setup the Docker in your pc, you can skip this)

```bash
docker network create mssqlnetwork 
docker compose up
```

####  Step 3: Apply Migrations
Navigate to the Infrastructure layer where the DbContext is located and run the following commands to apply migrations:
```bash
dotnet ef migrations add Init -p src/NorskApi.Infrastructure -s src/NorskApi.Api; 
```

To add a new migration, run the following command:

```bash
dotnet ef migrations add MigrationName -p src/NorskApi.Infrastructure -s src/NorskApi.Api; 
```

Use the following command to apply the existing migrations and update the database:

```bash
dotnet ef database update -p src/NorskApi.Infrastructure -s src/NorskApi.Api;
```
To remove the last migration, use:

```bash
dotnet ef migrations remove -p src/NorskApi.Infrastructure -s src/NorskApi.Api;
```

####  Step 4: Build and Run the Application
Navigate to the root of project directory and start the API:

```bash
dotnet clean
dotnet restore
dotnet build
dotnet watch run --project src/NorskApi.Api 
```

Open your brower and go to http://localhost:5160/swagger/index.html.

#### Test

```
dotnet test
```

## Endpoints 

These are the main endpoints for the Norsk learning platform, grouped by type. They cover common CRUD (Create, Read, Update, Delete) actions and allow you to manage, localExpressions, quizzes, discussions, words, questions, dictations, roleplays, podcasts, essays, grammar topics, grammar rules, and subjunctions.

#### LocalExpressions Endpoint

- GET - POST `{host}/api/v1/localexpressions` 
- GET - PUT - DELETE `{host}/api/v1/localexpressions/{id}`  
---

#### Dictation Endpoint

- POST GET `{host}/api/v1/dictations`
- GET PUT DELETE `{host}/api/v1/dictations/{id}`
- Query params `Filters by difficultyLevel & essayId`
---

#### Podcast Endpoint
- POST GET `{host}/api/v1/podcasts`
- GET PUT DELETE `{host}/api/v1/podcasts/{id}`
- Query params `Filters by by difficultyLevel & essayId`
---

#### Discussion Endpoint

- POST GET `{host}/api/v1/essays/{essayId}/discussions`
- GET `{host}/api/v1/essays/all/discussions`
- GET PUT DELETE `{host}/api/v1/essays/{essayId}/discussions/{id}`
- Query params `Filters by difficultyLevel`
---

#### Question Endpoint

- POST GET `{host}/api/v1/essays/{essayId}/questions`
- GET `{host}/api/v1/essays/all/questions`
- GET PUT DELETE `{host}/api/v1/essays/{essayId}/questions/{id}`
- Query params `Filters by difficultyLevel`
---

#### Roleplay Endpoint

- POST GET `{host}/api/v1/essays/{essayId}/roleplays`
- GET `{host}/api/v1/essays/all/roleplays`
- GET PUT DELETE `{host}/api/v1/essays/{essayId}/roleplays/{id}`
- Query params `Filters by difficultyLevel`
---

#### Quiz Endpoint

- GET - POST `{host}/api/v1/quizes`
- GET - PUT - DELETE `{host}/api/v1/quizes/{id}`
- Query params `difficultyLevel & essayId & topicId`
---

#### Word Endpoint

- GET - POST `{host}/api/v1/words`
- GET - PUT - DELETE `{host}/api/v1/words/{id}`
- Query params `difficultyLevel & essayId`
---

#### Essay Endpoint

- GET - POST `{host}/api/v1/conversation/essays`
- GET - PUT - DELETE `{host}/api/v1/conversation/essays/{id}`
---

#### Grammar Topic Endpoint

- GET - POST `{host}/api/v1/grammars/topics`
- GET - PUT - DELETE `{host}/api/v1/grammars/topics/{id}`
---

#### Grammar Rule Endpoint

- POST PUT DELETE GET `{host}/api/v1/grammars/topics/{topicId}/rules`
- POST PUT DELETE GET `{host}/api/v1/grammars/topics/all/rules`
- GET `{host}/api/v1/grammars/topics/{topicId}/rules/{id}`
---

#### Tasks Endpoint
- POST PUT DELETE GET `{host}/api/v1/grammars/topics/{topicId}/tasks`
- GET `{host}/api/v1/grammars/topics/{topicId}/tasks/{id}`

#### Subjunction Endpoint

- GET `{host}/api/v1/subjunctions`  
---

