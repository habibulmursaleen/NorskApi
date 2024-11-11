# Norsk API v2

## List of Endpoints

- [Subjunction](#subjunction)
- [LocalExpressions](#localexpressions)
- [Essay](#essay)
- [Dictation](#dictation)
- [Podcasts](#podcasts)
- [Discussion](#discussion)
- [Word](#word)
- [Grammars](#grammars)
- [Grammar Rules](#grammar-rules)
- [Tasks](#tasks)
- [Quiz](#quiz)


- [Norskprove](#norskprove)


![Norsk API Aggregate](norskapi.png)

## Subjunction

<!-- seeding -->
### GET `{host}/api/v1/subjunction`

```json
{
  "id": "0f93768b-2fbd-46e0-a752-d570889969f5",
  "label": "voluptatem",
  "type" : "TIME", //Enum "ITME", "ARSAK", "HENSLIKT", BETINGELSE", "MOTSETNING"
  "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
}
```

## LocalExpressions

### POST PUT DELETE GET `{host}/api/v1/localexpressions`
### GET PUT DELETE `{host}/api/v1/localexpressions/{id}`

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


## Essay

### POST PUT DELETE GET `{host}/api/v1/conversation/essays`
### POST PUT DELETE GET `{host}/api/v1/conversation/essays`
### Query params 
    Filters:
        difficultyLevel

```json
[
  {
    "id": "dd4d0668-7ef1-4656-bca7-78a7798211af",
    "logo": "http://placeimg.com/640/480/nature",
    "label": "Foo",
    "description": "foo description",
    "status": "ACTIVE", // enums "ACTIVE" and "INACTIVE"
    "progress": 75,
    "activities":  [
      {
        "id": "a9230259-e947-4525-85ae-275b2524fdcc", 
        "label": "paragraph"
      }
    ],
    "isCompleted": false,
    "isSaved": true,
    "tags": [
      {
        "id": "a9230259-e947-4525-85ae-275b2524fdcc", 
        "label": "odit"
      }
    ],
    "difficultyLevel": "B1", // enum "A1", "A2", "B1", "B2" , "C1"
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

### POST PUT DELETE GET `{host}/api/v1/conversation/essays/{id}`
### POST PUT DELETE GET `{host}/api/v1/conversation/essays/{id}`

```json
{
  "id": "dd4d0668-7ef1-4656-bca7-78a7798211af",
  "logo": "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/8.jpg", //or base64
  "label": "accusantium magni optio",
  "description": "doloremque occaecati et",
  "progress": 75,
  "activities":  [
      {
        "id": "a9230259-e947-4525-85ae-275b2524fdcc", 
        "label": "paragraph"
      }
  ],
  "status": "ACTIVE", // enums "ACTIVE" and "INACTIVE",
  "notes": "Eos aspernatur sunt in eum dicta fugiat quia. Qui distinctio alias veritatis nihil voluptas iusto ab.",
  "isCompleted": false,
  "isSaved": true,
  "tags": [
    {
      "id": "a9230259-e947-4525-85ae-275b2524fdcc", 
      "label": "odit"
    }
  ],
  "difficultyLevel": "A1", // enum "A1", "A2", "B1", "B2" , "C1"
  "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  "paragraphs": [
    {
      "id": "3e81b2a6-417d-470c-a537-17a2896728c1",
      "title": "nostrum nemo rerum",
      "content": "Nihil quod eveniet architecto quia neque facere. Ea accusantium repellendus inventore rerum minus quo.",
      "contentType": "RELATED", //Enum "RELATED" & "ADDITIONAL"
      "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
      "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
    }
  ],
  "questions": [
    {
      "id": "388dcd8d-24f3-4d2a-bb46-4604169a155e",
      "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af",  // child of Essay aggregate
      "label": "Dolores voluptate rerum quisquam ipsam animi voluptatem fugiat rem id?",
      "answer": "Id vitae veniam qui omnis omnis labore est voluptatem.",
      "isCompleted": true,
      "difficultyLevel": "B1", // Enum: A1, A2, B1, B2, C1
      "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
      "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
    }
  ],
  "roleplays": [
    {
      "id": "27ed959e-6240-4039-b83c-a93368d948e9",
      "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af", // child of Essay aggregate
      "content": "Rerum et numquam possimus assumenda. Quas delectus ut dolorem quia. Quis et odio commodi aut.",
      "difficultyLevel": "B1", // Enum: A1, A2, B1, B2, C1
      "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
      "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
    }
  ],
  "essayGrammarTopicIds": [
    {
      "grammarTopicId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543"
    }
  ]
}
```


## Dictation

### POST PUT DELETE GET `{host}/api/v1/dictations`
### GET PUT DELETE `{host}/api/v1/dictations/{id}`
### Query params 
    Filters:
        difficultyLevel
        essayId

```json
[
  {
    "id": "a750259a-d8b0-4dae-9a2d-3d850f715bec",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af", // just Id, no relation
    "label": "odio nulla perferendis",
    "content": "Optio fuga voluptatem aut omnis. Numquam odio harum deleniti praesentium repudiandae dolores.",
    "answer": "Sit repellat velit accusamus harum est. Nostrum ratione sequi. Rinventore odio tempore laudantium.",
    "isCompleted": false,
    "difficultyLevel": "B1", // Enum: A1, A2, B1, B2, C1
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Podcasts

### POST GET `{host}/api/v1/podcasts`
### GET PUT DELETE `{host}/api/v1/podcasts/{id}`
### Query params 
    Filters:
        difficultyLevel
        essayId

```json
[
  {
    "id": "8d634e39-bf18-4a4b-8d90-b85a9ccb1ab7",
    "essayId": "015f1628-10b5-4bb2-836c-6ae873de4739", // just Id, no relation
    "lebel": "sint",
    "descriptions": "voluptatem hic alias", 
    "logo": "http://placeimg.com/640/480/technics",
    "url": "http://placeimg.com/640/480/technics", 
    "isCompleted": true,
    "isFeatured": true,
    "difficultyLevel": "B1", // Enum: A1, A2, B1, B2, C1
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Discussion

### POST GET `{host}/api/v1/discussions`
### GET `{host}/api/v1/discussions`
### GET PUT DELETE `{host}/api/v1/discussions/{id}`
### Query params 
    Filters:
        difficultyLevel
        essayId

```json
[
  {
    "id": "1609915b-b62c-4e63-bd44-2427905dbab6",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af",  // no relation but just id
    "title": "culpa rerum quasi",
    "discussionEssays": "Id rerum rerum eum architecto aut et vel. Suscipit iure qui ut voluptatum nesciunt laboriosam.",
    "isCompleted": true,
    "difficultyLevel": "B1", // Enum: A1, A2, B1, B2, C1
    "note": "", //user input
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Word

### POST GET `{host}/api/v1/words`
### GET PUT DELETE `{host}/api/v1/words/{id}`
### Query params 
    Filters:
        difficultyLevel
        essayId

```json
[
  {
    "id": "554aab40-c9a9-4e6d-8baa-3510096ac957",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af", // just Id, no relation
    "title": "odit adipisci praesentium",
    "meaning": "architecto dolor rerum",
    "enTranslation": "repellendus labore ut",
    "nativeMeaning": "numquam modi adipisci",
    "type": "INFORMAL", // enum "LOCAL", "ACADEMIC", "FORMAL", "INFORMAL", "SLANG", "PHRASE"
    "partOfSpeechTag ": "VERB", // enum "NOUN", "PRONOUN", "ADVERB", "ADJECTIVE", "VERB", "CONJUNTION", "PREPOSITION", "ARTICLE"
    "isCompleted": true,
    "difficultyLevel": "B1", // Enum: A1, A2, B1, B2, C1
    "synonymes": [
      {
        "wordId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543"
      }
    ],
    "antonymes": [
      {
        "wordId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543"
      }
    ],
    "wordGrammar": {
      "id": "4fb6a24b-400b-4840-860a-9ceea493960b",
      "wordId": "3a46496e-52fc-4b4c-9ad3-5b9e985d669b",
      "genderMasculine": "et",
      "genderFeminine": "aperiam",
      "genderNeutral": "accusamus",
      "singularDefinitiv": "totam",
      "singularIndefinitiv": "error",
      "pluralDefinitiv": "quisquam",
      "pluralIndefinitiv": "saepe",
      "infinitiv": "minus",
      "presentTense": "temporibus",
      "pastTense": "dicta",
      "presentPerfectTense": "molestiae",
      "futureTense": "ut",
      "positive": "nisi",
      "comparative": "quo",
      "superlative": "ipsa",
      "superlativeDetermined": "et",
      "pastParticiple": "aut",
      "presentParticiple": "deserunt",
      "irregular": true,
      "strongVerb": true,
      "weakVerb": false,
    },
    "WordUsageExample ": {
      "id": "9cb2a603-fa74-46b8-bf97-b23698dbe714",
      "correctSentence": "Ducimus placeat voluptatem.",
      "incorrectSentence": "dignissimos eos autem",
      "englishSentence": "autem animi quia",
      "newSentence": "Recusandae aspernatur eos esse voluptas eius impedit."
    },
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  }
]
```

## Grammars

### POST PUT DELETE GET `{host}/api/v1/grammarsTopics`
### GET `{host}/api/v1/grammarsTopics/{id}`
### Query params 
    Filters:
        difficultyLevel

```json
[
  {
    "id": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543",
    "label": "Foo Grammar",
    "description": "Foo Grammar description",
    "status": "ACTIVE", // enums "ACTIVE" and "INACTIVE"
    "chapter": 1,
    "moduleCount": 3,
    "progress": 75,
    "isCompleted": false,
    "isSaved": true,
    "tags": [
      {
        "id": "a9230259-e947-4525-85ae-275b2524fdcc", 
        "label": "odit"
      }
    ],
    "difficultyLevel": "B1", // enum "A1", "A2", "B1", "B2" , "C1"
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Grammmar Rules

### POST PUT DELETE GET `{host}/api/v1/grammars/topics/{topicId}/rules`
### POST PUT DELETE GET `{host}/api/v1/grammars/topics/all/rules`
### GET `{host}/api/v1/grammars/topics/{topicId}/rules/{id}`
### Query params 
    Filters:
        difficultyLevel

```json
[
  {
    "id": "6d737c85-35fa-4e1b-b341-ac883ef751d4",
    "topicId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543", // child of Topic aggregate
    "label": "Quia illo aliquid consequuntur.",
    "description": "Sed et qui iusto omnis sed et modi.",
    "explanatoryNotes": "animi consequatur suscipit",
    "sentenceStructure": [
      {
        "id": "a9230259-e947-4525-85ae-275b2524fdcc", 
        "label": "odit"
      }
    ],
    "ruleType": "perspiciatis",
    "difficultyLevel": "B1", // enum "A1", "A2", "B1", "B2" , "C1"
    "tags": [
      {
        "id": "a9230259-e947-4525-85ae-275b2524fdcc", 
        "label": "odit"
      }
    ],
    "additionalInformation": "Ipsa aut in vel a.",
    "exceptions": [
      {
        "id": "1a1d6cd8-d652-4491-8765-fc0b6f216782",
        "grammarRuleId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543", // child of grammer Rule entity
        "title": "dignissimos",
        "description": "Hun",
        "comments": "in",
        "correctSentence": "spiser",
        "incorrectSentence": "spiser"
      }
    ],
    "exampleOfRule": [
      {
        "id": "84dd4e04-5b9b-49c6-b5ee-cadb6fc2c21b",
        "grammarRuleId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543", // child of grammer Rule entity
        "subjunction": "dignissimos",
        "subject": "Hun",
        "adverbial": "in",
        "verb": "spiser",
        "object": "eplet",
        "rest": "temporibus",
        "correctSentence": "Delectus vel id incidunt libero molestiae.",
        "englishSentence": "Architecto perferendis quis.",
        "incorrectSentence": "Sed provident esse modi quis modi aut vitae qui.",
        "transformationFrom": "voluptatibus",
        "transformationTo": "corporis consequatur praesentium",
      }
    ],
    "comment1": "Vitae dolorem qui quibusdam quia voluptatem id.",
    "comment2": "Vitae dolorem qui quibusdam quia voluptatem id.",
    "comment3": "Vitae dolorem qui quibusdam quia voluptatem id.",
    "grammarRules": [
      {
        "grammarRuleId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543"
      }
    ],
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Tasks

### POST PUT DELETE GET `{host}/api/v1/tasks`
### GET `{host}/api/v1/tasks/{id}`
### Query params 
    Filters:
        difficultyLevel
        topicId
        
```json
[
  {
    "id": "2b772cd8-4f73-402d-b658-391e6af61d5e",
    "topicId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543", // child of Topic aggregate
    "logo": "http://placeimg.com/640/480/abstract",
    "label": "Quis minus sit.",
    "taskPointer": "Iste ut incidunt.",
    "isCompleted": true,
    "difficultyLevel": "B1", // enum "A1", "A2", "B1", "B2" , "C1"
    "answer": "Odio quod omnis quo expedita dolores aut esse suscipit.", // user input
    "comments": "Sequi dolor nam eos consectetur sed fugit ex.",
    "additionalInfo": "In sed alias dignissimos numquam impedit.",
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```



## Quiz

### POST GET `{host}/api/v1/quizes`
### GET PUT DELETE `{host}/api/v1/quizes/{id}`
### Query params 
    Filters:
        difficultyLevel
        essayId
        topicId

```json
[
  {
    "id": "2af80963-ab29-4aa2-a6a7-bf1237d96926",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af", // just Id, no relation
    "topicId": "749cd452-3398-4338-af03-d15bcdb291c7", // just Id, no relation
    "dictationId": "d3103c71-86ff-4f05-bf50-c9ad93dada17",
    "question": "Totam minus dolores deserunt quod iste sapiente?",
    "answer": "quis neque voluptate",
    "isRightAnswer": false,
    "difficultyLevel": "B1", // Enum: A1, A2, B1, B2, C1
    "quizType": "BOOLEAN", // enum "MULTIPLE_CHOICE" OR "BOOLEAN" OR "TEXT"
    "options": [
      {
        "id": "40ed9bed-edb8-433f-9f60-b0e726a906d4",
        "title": "Impedit ut iste.",
        "isCorrect": true,
        "multipleChoiceAnswer": true, // user input 
      }
    ],
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  }
]
```

## Norskprove 

### POST GET `{host}/api/v1/norskprove`
### GET PUT DELETE `{host}/api/v1/norskprove/{id}`
### Query params 
    Filters:
        difficultyLevel

```json
[
  {
    "id": "554aab40-c9a9-4e6d-8baa-3510096ac957",
    "title": "odit adipisci praesentium",
    "description": "quis porro quaerat",
    "isCompleted": true,
    "difficultyLevel": "B1", // Enum: A1, A2, B1, B2, C1
    "listening":[
      {
        "dictationId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543"
      }
    ],
    "reading": [
      {
        "essayId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543"
      }
    ],
    "writing": [
      {
        "discussionId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543"
      }
    ],
    "additionalGrammarTasks": [
      {
        "taskId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543"
      }
    ],
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  }
]