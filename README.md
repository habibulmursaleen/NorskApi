# Norsk API

## Table of contents

- [Norsk API](#norsk-api)
  - [Table of contents](#table-of-contents)
  - [LocalExpressions](#localexpressions)
    - [POST PUT DELETE GET `{host}/api/v1/localexpressions`](#post-put-delete-get-hostapiv1localexpressions)
    - [GET `{host}/api/v1/localexpressions/{localexpressionId}`](#get-hostapiv1localexpressionslocalexpressionid)
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

## LocalExpressions

### POST PUT DELETE GET `{host}/api/v1/localexpressions`

### GET `{host}/api/v1/localexpressions/{localexpressionId}`

```json
[
  {
    "id": "430c537b-3f63-439e-a7b2-acaf5e1ce836",
    "label": "Totam minus dolores deserunt quod iste sapiente?",
    "description": "fugiat illum et",
    "meaningInNorsk": "quis dolorem impedit",
    "meaningInEnglish":  "totam consequuntur est",
    "type": "PHASES_IDIOMS", // enum "EVERYDAY_PHRASE" OR "YOUTH_SLANG" OR "PROFESSIONAL" OR "PHASES_IDIOMS" OR "URBAN_SLANG"
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  }
]
```

### Quiz Endpoints

- **POST `{host}/api/v1/level/{b1}/quizes`**  
  Create a new quiz under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/quizes/{quizId}`**  
  Update an existing quiz by `quizId` under the level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/quizes/{quizId}`**  
  Delete the quiz by `quizId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/quizes`**  
  Retrieve all quizzes available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/quizes/{quizId}`**  
  Retrieve details of a specific quiz by `quizId` under the specified level `{b1}`.

---

### Discussion Endpoints

- **POST `{host}/api/v1/level/{b1}/discussions`**  
  Create a new discussion under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/discussions/{discussionId}`**  
  Update an existing discussion by `discussionId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/discussions/{discussionId}`**  
  Delete the discussion by `discussionId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/discussions`**  
  Retrieve all discussions available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/discussions/{discussionId}`**  
  Retrieve details of a specific discussion by `discussionId` under the specified level `{b1}`.

---

### Word Endpoints

- **POST `{host}/api/v1/level/{b1}/words`**  
  Create a new word entry under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/words/{wordId}`**  
  Update an existing word entry by `wordId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/words/{wordId}`**  
  Delete the word entry by `wordId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/words`**  
  Retrieve all word entries available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/words/{wordId}`**  
  Retrieve details of a specific word entry by `wordId` under the specified level `{b1}`.

---

### Question Endpoints

- **POST `{host}/api/v1/level/{b1}/questions`**  
  Create a new question under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/questions/{questionId}`**  
  Update an existing question by `questionId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/questions/{questionId}`**  
  Delete the question by `questionId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/questions`**  
  Retrieve all questions available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/questions/{questionId}`**  
  Retrieve details of a specific question by `questionId` under the specified level `{b1}`.

---

### Dictation Endpoints

- **POST `{host}/api/v1/level/{b1}/dictations`**  
  Create a new dictation under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/dictations/{dictationId}`**  
  Update an existing dictation by `dictationId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/dictations/{dictationId}`**  
  Delete the dictation by `dictationId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/dictations`**  
  Retrieve all dictations available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/dictations/{dictationId}`**  
  Retrieve details of a specific dictation by `dictationId` under the specified level `{b1}`.

---

### Roleplay Endpoints

- **POST `{host}/api/v1/level/{b1}/roleplays`**  
  Create a new roleplay under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/roleplays/{roleplayId}`**  
  Update an existing roleplay by `roleplayId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/roleplays/{roleplayId}`**  
  Delete the roleplay by `roleplayId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/roleplays`**  
  Retrieve all roleplays available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/roleplays/{roleplayId}`**  
  Retrieve details of a specific roleplay by `roleplayId` under the specified level `{b1}`.

---

### Podcast Endpoints

- **POST `{host}/api/v1/level/{b1}/podcasts`**  
  Create a new podcast entry under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/podcasts/{podcastId}`**  
  Update an existing podcast entry by `podcastId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/podcasts/{podcastId}`**  
  Delete the podcast entry by `podcastId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/podcasts`**  
  Retrieve all podcast entries available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/podcasts/{podcastId}`**  
  Retrieve details of a specific podcast entry by `podcastId` under the specified level `{b1}`.

---

### Essay Endpoints

- **POST `{host}/api/v1/level/{b1}/conversation/essays`**  
  Create a new essay under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/conversation/essays/{essayId}`**  
  Update an existing essay by `essayId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/conversation/essays/{essayId}`**  
  Delete the essay by `essayId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/conversation/essays`**  
  Retrieve all essays available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/conversation/essays/{essayId}`**  
  Retrieve details of a specific essay by `essayId` under the specified level `{b1}`.

---

### Grammar Topic Endpoints

- **POST `{host}/api/v1/level/{b1}/grammars/topics`**  
  Create a new grammar topic under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/grammars/topics/{topicId}`**  
  Update an existing grammar topic by `topicId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/grammars/topics/{topicId}`**  
  Delete the grammar topic by `topicId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/grammars/topics`**  
  Retrieve all grammar topics available for the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/grammars/topics/{topicId}`**  
  Retrieve details of a specific grammar topic by `topicId` under the specified level `{b1}`.

---

### Grammar Rule Endpoints

- **POST `{host}/api/v1/level/{b1}/grammars/rules`**  
  Create a new grammar rule under the specified level `{b1}`.

- **PUT `{host}/api/v1/level/{b1}/grammars/rules/{ruleId}`**  
  Update an existing grammar rule by `ruleId` under the specified level `{b1}`.

- **DELETE `{host}/api/v1/level/{b1}/grammars/rules/{ruleId}`**  
  Delete the grammar rule by `ruleId` under the specified level `{b1}`.

- **GET `{host}/api/v1/level/{b1}/grammars/rules`**  
  Retrieve all grammar rules available for the specified level `{b

1}`.

- **GET `{host}/api/v1/level/{b1}/grammars/rules/{ruleId}`**  
  Retrieve details of a specific grammar rule by `ruleId` under the specified level `{b1}`.

---

### Subjunction Endpoints

- **GET `{host}/api/v1/level/{b1}/subjunctions`**  
  Retrieve a list of subjunctions categorized by type such as time, cause, condition, and contrast for the specified level `{b1}`.

---

These are the main endpoints for the Norsk learning platform, grouped by type. They cover common CRUD (Create, Read, Update, Delete) actions and allow you to manage quizzes, discussions, words, questions, dictations, roleplays, podcasts, essays, grammar topics, grammar rules, and subjunctions.