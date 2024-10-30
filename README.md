# Norsk API

A comprehensive backend api for norsk learning application. 

## Table of contents

- [Norsk API](#norsk-api)
  - [Table of contents](#table-of-contents)
    - [Requirements](#requirements)
    - [Architecture Overview](#architecture-overview)
    - [Setup](#setup)
      - [Step 1: Clone the Repository](#step-1-clone-the-repository)
      - [Step 2: Set Up Database](#step-2-set-up-database)
      - [Step 3: Apply Migrations](#step-3-apply-migrations)
      - [Step 4: Run the Application](#step-4-run-the-application)
      - [Other Commands](#other-commands)
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

####  Step 2: Set Up Database
Ensure your SQL Server is running. Update the connection string in appsettings.Development.json located in the WebApi project:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyDatabase;User Id=your-username;Password=your-password;"
  }
}

```

####  Step 3: Apply Migrations
Navigate to the Infrastructure layer where the DbContext is located and run the following commands to apply migrations:
```bash
dotnet ef migrations add InitialCreate --project src/Infrastructure --startup-project src/WebApi
dotnet ef database update --project src/Infrastructure --startup-project src/WebApi
```

####  Step 4: Run the Application
Navigate to the WebApi project directory and start the API:

```bash
cd src/NorskApi.Api
dotnet run
```
#### Other Commands

```
dotnet test
dotnet watch
dotnet run
dotnet build
```
## Endpoints 

These are the main endpoints for the Norsk learning platform, grouped by type. They cover common CRUD (Create, Read, Update, Delete) actions and allow you to manage, localExpressions, quizzes, discussions, words, questions, dictations, roleplays, podcasts, essays, grammar topics, grammar rules, and subjunctions.

#### LocalExpressions Endpoints

- POST `{host}/api/v1/localexpressions` 
- PUT `{host}/api/v1/localexpressions/{localexpressionId}`  
- DELETE `{host}/api/v1/localexpressions/{localexpressionId}`  
- GET `{host}/api/v1/localexpressions`  
- GET `{host}/api/v1/localexpressions/{localexpressionId}`  
---

#### Quiz Endpoints

- POST `{host}/api/v1/level/{b1}/quizes`  
- PUT `{host}/api/v1/level/{b1}/quizes/{quizId}` 
- DELETE `{host}/api/v1/level/{b1}/quizes/{quizId}`  
- GET `{host}/api/v1/level/{b1}/quizes`  
- GET `{host}/api/v1/level/{b1}/quizes/{quizId}` 
---

#### Discussion Endpoints

- POST `{host}/api/v1/level/{b1}/discussions`  
- PUT `{host}/api/v1/level/{b1}/discussions/{discussionId}`  
- DELETE `{host}/api/v1/level/{b1}/discussions/{discussionId}`  
- GET `{host}/api/v1/level/{b1}/discussions`  
- GET `{host}/api/v1/level/{b1}/discussions/{discussionId}`  

---

#### Word Endpoints

- POST `{host}/api/v1/level/{b1}/words`  
- PUT `{host}/api/v1/level/{b1}/words/{wordId}`  
- DELETE `{host}/api/v1/level/{b1}/words/{wordId}`  
- GET `{host}/api/v1/level/{b1}/words`  
- GET `{host}/api/v1/level/{b1}/words/{wordId}`  
---

#### Question Endpoints

- POST `{host}/api/v1/level/{b1}/questions`  
- PUT `{host}/api/v1/level/{b1}/questions/{questionId}`  
- DELETE `{host}/api/v1/level/{b1}/questions/{questionId}`  
- GET `{host}/api/v1/level/{b1}/questions`  
- GET `{host}/api/v1/level/{b1}/questions/{questionId}`  
---

#### Dictation Endpoints

- POST `{host}/api/v1/level/{b1}/dictations`  
- PUT `{host}/api/v1/level/{b1}/dictations/{dictationId}`  
- DELETE `{host}/api/v1/level/{b1}/dictations/{dictationId}`  
- GET `{host}/api/v1/level/{b1}/dictations`  
- GET `{host}/api/v1/level/{b1}/dictations/{dictationId}`  
---

#### Roleplay Endpoints

- POST `{host}/api/v1/level/{b1}/roleplays`  
- PUT `{host}/api/v1/level/{b1}/roleplays/{roleplayId}`  
- DELETE `{host}/api/v1/level/{b1}/roleplays/{roleplayId}`  
- GET `{host}/api/v1/level/{b1}/roleplays`  
- GET `{host}/api/v1/level/{b1}/roleplays/{roleplayId}`  
---

#### Podcast Endpoints

- POST `{host}/api/v1/level/{b1}/podcasts`  
- PUT `{host}/api/v1/level/{b1}/podcasts/{podcastId}`  
- DELETE `{host}/api/v1/level/{b1}/podcasts/{podcastId}`  
- GET `{host}/api/v1/level/{b1}/podcasts`  
- GET `{host}/api/v1/level/{b1}/podcasts/{podcastId}`  

---

#### Essay Endpoints

- POST `{host}/api/v1/level/{b1}/conversation/essays`  
- PUT `{host}/api/v1/level/{b1}/conversation/essays/{essayId}`  
- DELETE `{host}/api/v1/level/{b1}/conversation/essays/{essayId}`  
- GET `{host}/api/v1/level/{b1}/conversation/essays`  
- GET `{host}/api/v1/level/{b1}/conversation/essays/{essayId}`  
  
---

#### Grammar Topic Endpoints

- POST `{host}/api/v1/level/{b1}/grammars/topics`  
- PUT `{host}/api/v1/level/{b1}/grammars/topics/{topicId}`  
- DELETE `{host}/api/v1/level/{b1}/grammars/topics/{topicId}`  
- GET `{host}/api/v1/level/{b1}/grammars/topics`  
- GET `{host}/api/v1/level/{b1}/grammars/topics/{topicId}`  
  
---

#### Grammar Rule Endpoints

- POST `{host}/api/v1/level/{b1}/grammars/rules`  
- PUT `{host}/api/v1/level/{b1}/grammars/rules/{ruleId}`  
- DELETE `{host}/api/v1/level/{b1}/grammars/rules/{ruleId}`  
- GET `{host}/api/v1/level/{b1}/grammars/rules`  
- GET `{host}/api/v1/level/{b1}/grammars/rules/{ruleId}`  
---

#### Subjunction Endpoints

- GET `{host}/api/v1/level/{b1}/subjunctions`  
---

