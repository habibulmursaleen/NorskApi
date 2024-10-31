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
      - [LocalExpressions Endpoints](#localexpressions-endpoints)
      - [Quiz Endpoints](#quiz-endpoints)
      - [Discussion Endpoints](#discussion-endpoints)
      - [Word Endpoints](#word-endpoints)
      - [Question Endpoints](#question-endpoints)
      - [Dictation Endpoints](#dictation-endpoints)
      - [Roleplay Endpoints](#roleplay-endpoints)
      - [Podcast Endpoints](#podcast-endpoints)
      - [Essay Endpoints](#essay-endpoints)
      - [Grammar Topic Endpoints](#grammar-topic-endpoints)
      - [Grammar Rule Endpoints](#grammar-rule-endpoints)
      - [Subjunction Endpoints](#subjunction-endpoints)

![Norsk API Aggregate](norskapi.png)

This project follows Clean Architecture principles combined with Domain-Driven Design (DDD) to create a maintainable and scalable .NET application.

### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any database of your choice)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (Recommended for development)

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
Navigate to the WebApi project directory and start the API:

```bash
dotnet build
dotnet watch run --project src/NorskApi.Api   
```
#### Test

```
dotnet test
```
## Endpoints 

These are the main endpoints for the Norsk learning platform, grouped by type. They cover common CRUD (Create, Read, Update, Delete) actions and allow you to manage, localExpressions, quizzes, discussions, words, questions, dictations, roleplays, podcasts, essays, grammar topics, grammar rules, and subjunctions.

#### LocalExpressions Endpoints

- GET - POST `{host}/api/v1/localexpressions` 
- GET - PUT - DELETE `{host}/api/v1/localexpressions/{id}`  
---
#### Quiz Endpoints

- GET - POST `{host}/api/v1/level/{b1}/quizes`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/quizes/{id}`
---

#### Discussion Endpoints

- GET - POST `{host}/api/v1/level/{b1}/discussions`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/discussions/{id}`
---

#### Word Endpoints

- GET - POST `{host}/api/v1/level/{b1}/words`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/words/{id}`
---

#### Question Endpoints

- GET - POST `{host}/api/v1/level/{b1}/questions`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/questions/{id}`
---

#### Dictation Endpoints

- GET - POST `{host}/api/v1/level/{b1}/dictations`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/dictations/{id}`
---

#### Roleplay Endpoints

- GET - POST `{host}/api/v1/level/{b1}/roleplays`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/roleplays/{id}`
---

#### Podcast Endpoints

- GET - POST `{host}/api/v1/level/{b1}/podcasts`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/podcasts/{id}`
---

#### Essay Endpoints

- GET - POST `{host}/api/v1/level/{b1}/conversation/essays`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/conversation/essays/{id}`
---

#### Grammar Topic Endpoints

- GET - POST `{host}/api/v1/level/{b1}/grammars/topics`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/grammars/topics/{id}`
---

#### Grammar Rule Endpoints

- GET - POST `{host}/api/v1/level/{b1}/grammars/rules`
- GET - PUT - DELETE `{host}/api/v1/level/{b1}/grammars/rules/{id}`
---

#### Subjunction Endpoints

- GET `{host}/api/v1/level/{b1}/subjunctions`  
---

