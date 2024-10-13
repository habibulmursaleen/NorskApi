# Norsk API

## Possibler endpoints

## Quiz

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/quizes`

### GET `{host}/api/v1/level/{b1}/quizes/{essayId}`

```json
[
  {
    "id": "2af80963-ab29-4aa2-a6a7-bf1237d96926",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af",
    "question": "Totam minus dolores deserunt quod iste sapiente?",
    "type": "BOOLEAN", // enum "MULTIPLE_CHOICE" OR "BOOLEAN" OR "STRING"
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "options": [
      {
        "id": "40ed9bed-edb8-433f-9f60-b0e726a906d4",
        "title": "Impedit ut iste.",
        "isCorrect": true,
        "answer": true // user input (both string and bool)
      },
      {
        "id": "40ed9bed-edb8-433f-9f60-b0e726a906d4",
        "title": "Impedit ut iste.",
        "isCorrect": true,
        "answer": "Nisi debitis error eum." // user input (both string and bool)
      }
    ]
  }
]
```

## Discussion

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/discussions`

### GET `{host}/api/v1/level/{b1}/discussions/{essayId}`

```json
[
  {
    "id": "1609915b-b62c-4e63-bd44-2427905dbab6",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af",
    "title": "culpa rerum quasi",
    "discussionessays": "Id rerum rerum eum architecto aut et vel. Suscipit iure qui ut voluptatum nesciunt laboriosam.",
    "isCompleted": true,
    "note": "", //user input
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Word

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/words`

### GET `{host}/api/v1/level/{b1}/words/{essayId}`

```json
[
  {
    "id": "554aab40-c9a9-4e6d-8baa-3510096ac957",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af",
    "title": "odit adipisci praesentium",
    "meaning": "architecto dolor rerum",
    "enTranslation": "repellendus labore ut",
    "nativeMeaning": "numquam modi adipisci",
    "type": "INFORMAL", // enum "LOCAL", "ACADEMIC", "FORMAL", "INFORMAL", "SLANG", "PHRASE"
    "partOfSpeechTag ": "VERB", // enum "NOUN", "PRONOUN", "ADVERB", "ADJECTIVE", "VERB", "CONJUNTION", "PREPOSITION", "ARTICLE"
    "isCompleted": true,
    "synonymes": [
      "92061233-a115-473c-9b6f-8167f061c77d",
      "dfb18038-e5eb-4465-8747-91d7dc626855",
      "adf61dff-b4da-41d2-8017-bc75f7496433"
    ],
    "antonymes": [
      "b6fa1201-718a-4fd9-964a-ed836b6582cf",
      "c7414f1c-c275-45a4-a5af-f563a77b6122"
    ],
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "grammar": {
      "gender": {
        "masculine": "et",
        "feminine": "aperiam",
        "neutral": "accusamus"
      },
      "definitiveness": {
        "singularDefinitiv": "totam",
        "singularIndefinitiv": "error",
        "pluralDefinitiv": "quisquam",
        "pluralIndefinitiv": "saepe"
      },
      "tense": {
        "infinitiv": "minus",
        "present": "temporibus",
        "past": "dicta",
        "presentPerfect": "molestiae",
        "future": "ut"
      },
      "comparison": {
        "positive": "nisi",
        "comparative": "quo",
        "superlative": "ipsa",
        "superlativeDetermined": "et"
      },
      "irregular": true,
      "verbForm": {
        "strong": true,
        "weak": false
      },
      "participle": {
        "pastParticiple": "aut",
        "presentParticiple": "deserunt"
      },
      "adjectiveDegree": {
        "comparative": "autem",
        "superlative": "eum"
      }
    },
    "usage": {
      "correctSentence": "Ducimus placeat voluptatem.",
      "incorrectSentence": "dignissimos eos autem",
      "englishSentence": "autem animi quia",
      "newSentence": "Recusandae aspernatur eos esse voluptas eius impedit."
    }
  }
]
```

## Question

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/questions`

### GET `{host}/api/v1/level/{b1}/questions/{essayId}`

```json
[
  {
    "id": "388dcd8d-24f3-4d2a-bb46-4604169a155e",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af",
    "question": "Dolores voluptate rerum quisquam ipsam animi voluptatem fugiat rem id?",
    "answer": "Id vitae veniam qui omnis omnis labore est voluptatem.",
    "isCompleted": true,
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Dictation

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/dictations`

### GET `{host}/api/v1/level/{b1}/dictations/{essayId}`

```json
[
  {
    "id": "a750259a-d8b0-4dae-9a2d-3d850f715bec",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af",
    "content": "Optio fuga voluptatem aut omnis. Numquam odio harum deleniti praesentium repudiandae dolores.",
    "answer": "Sit repellat velit accusamus harum est. Nostrum ratione sequi. Rinventore odio tempore laudantium.",
    "isCompleted": false,
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Roleplays

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/roleplays`

### GET `{host}/api/v1/level/{b1}/roleplays/{essayId}`

```json
[
  {
    "id": "27ed959e-6240-4039-b83c-a93368d948e9",
    "essayId": "dd4d0668-7ef1-4656-bca7-78a7798211af",
    "content": "Rerum et numquam possimus assumenda. Quas delectus ut dolorem quia. Quis et odio commodi aut.",
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Essay

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/conversation/essays`

```json
[
  {
    "id": "dd4d0668-7ef1-4656-bca7-78a7798211af",
    "logo": "http://placeimg.com/640/480/nature",
    "label": "Foo",
    "description": "foo description",
    "status": "ACTIVE", // enums "ACTIVE" and "INACTIVE"
    "progress": 75,
    "activities": ["paragraphs", "discussions", "quizes", "words", "roleplay"],
    "isCompleted": false,
    "isSaved": true,
    "tags": ["odit", "officiis"],
    "difficultyLevel": "", // enum "A1", "A2", "B1", "B2" , "C1"
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/conversation/essays/{id}`

```json
{
  "id": "dd4d0668-7ef1-4656-bca7-78a7798211af",
  "logo": "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/8.jpg", //or base64
  "label": "accusantium magni optio",
  "description": "doloremque occaecati et",
  "progress": 75,
  "activities": ["paraghraphs", "discussions", "quizes", "words", "roleplay"],
  "status": "ACTIVE", // enums "ACTIVE" and "INACTIVE",
  "notes": "Eos aspernatur sunt in eum dicta fugiat quia. Qui distinctio alias veritatis nihil voluptas iusto ab.",
  "isCompleted": false,
  "isSaved": true,
  "tags": ["odit", "officiis"],
  "difficultyLevel": "", // enum "A1", "A2", "B1", "B2" , "C1"
  "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
  "paraghraphs": [
    {
      "id": "3e81b2a6-417d-470c-a537-17a2896728c1",
      "title": "nostrum nemo rerum",
      "content": "Nihil quod eveniet architecto quia neque facere. Ea accusantium repellendus inventore rerum minus quo.",
      "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
      "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
    }
  ],
  "additional": [
    {
      "id": "5bd27ae8-4ddf-4a89-9798-eccaaa67676e",
      "content": "Ipsum similique quos consectetur. Assumenda quam tenetur porro omnis blanditiis necessitatibus quae.",
      "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
      "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
    }
  ],
  "relatedGrammersTopics": ["1ea2629c-c4cd-43ee-87b6-eed68d1ab543"]
}
```

## Grammars

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/grammars/topics`

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
    "tags": ["odit", "officiis"],
    "difficultyLevel": "", // enum "A1", "A2", "B1", "B2" , "C1"
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

### GET `{host}/api/v1/level/{b1}/grammars/topics/{id}`

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
    "tags": ["odit", "officiis"],
    "difficultyLevel": "", // enum "A1", "A2", "B1", "B2" , "C1"
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Subjunction

### POST PUT DELETE GET `{host}/api/v1/subjunction`

```json
{
  "time": ["quae", "voluptatem", "eum"],
  "arsak": ["officiis", "atque", "est"],
  "henslikt": ["est", "modi", "reprehenderit"],
  "betingelse": ["minus", "explicabo", "recusandae"],
  "motsetning": ["veritatis", "ab", "beatae"]
}
```

## Grammmar Rules

### POST PUT DELETE GET `{host}/api/v1/level/{b1}/grammars/rules`

### GET `{host}/api/v1/level/{b1}/grammars/rules/{topicId}`

```json
[
  {
    "id": "6d737c85-35fa-4e1b-b341-ac883ef751d4",
    "topicId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543",
    "label": "Quia illo aliquid consequuntur.",
    "description": "Sed et qui iusto omnis sed et modi.",
    "explanatoryNotes": "animi consequatur suscipit",
    "sentenceStructure": ["S", "V", "O"],
    "ruleType": "perspiciatis",
    "difficultyLevel": "B1", // enum "A1", "A2", "B1", "B2" , "C1"
    "tags": ["Word Order", "SVO", "Verb", "Subject"],
    "exceptions": "Verb 'å være' doesn't follow the typical conjugation rules.",
    "additionalInformation": "Ipsa aut in vel a.",
    "example": [
      {
        "exampleBreakdown": {
          "subjunction": "dignissimos",
          "subject": "Hun",
          "adverbial": "in",
          "verb": "spiser",
          "object": "eplet",
          "rest": "temporibus"
        },
        "sentences": {
          "correctSentence": "Delectus vel id incidunt libero molestiae.",
          "englishSentence": "Architecto perferendis quis.",
          "incorrectSentence": "Sed provident esse modi quis modi aut vitae qui."
        }
      }
    ],
    "comments": [
      "facere nemo omnis",
      "aut nihil vel",
      "magnam saepe excepturi"
    ],
    "transformation": {
      "from": "Sed provident esse modi...",
      "to": "Delectus vel id incidunt..."
    },
    "relatedRules": [
      "7c2e5b20-bb8b-4a0e-a21d-5593b7a34e21",
      "68adfbb3-53b9-4b7c-bcda-033cbbfe3a87"
    ],
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Tasks

### POST PUT DELETE GET `{host}/api/v1/tasks`

### GET `{host}/api/v1/tasks/{topicId}`

```json
[
  {
    "id": "2b772cd8-4f73-402d-b658-391e6af61d5e",
    "topicId": "1ea2629c-c4cd-43ee-87b6-eed68d1ab543",
    "logo": "http://placeimg.com/640/480/abstract",
    "label": "Quis minus sit.",
    "taskPointer": "Iste ut incidunt.",
    "answer": "Odio quod omnis quo expedita dolores aut esse suscipit.", // user input
    "comments": "Sequi dolor nam eos consectetur sed fugit ex.",
    "additionalInfo": "In sed alias dignissimos numquam impedit.",
    "createdAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)",
    "updatedAt": "Fri Oct 14 2061 08:47:19 GMT+0200 (Central European Summer Time)"
  }
]
```

## Search and Pagination

### `GET {host}/api/v1/level/{b1}/search?type=words&keyword=modi&difficultyLevel=B1&isCompleted=true`
