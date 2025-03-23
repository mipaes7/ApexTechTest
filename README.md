# ApexTechTest

# Questions API Documentation

This API allows you to create, update, retrieve questions, and submit answers for different types of questions such as multiple choice, rating-based, and single-choice questions.

## Features
- **Create, Read, Update Questions**
- **Submit Answers**
- **Supports Question Types:**
  - **Five-Star Rating** (rating from 1 to 10)
  - **Multiple Option** (multiple choice questions)
  - **Single Option** (single choice questions)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/mipaes7/ApexTechTest.git
   cd QuestionsAPI
   ```
     
### Endpoints
#### 1. Create or Update a Question
- **URL:** `/api/questions/{id}`
- **Method:** `PUT`

##### URL Params:
- `id` (required): GUID of the question. 0038fe72-bfe0-4c56-9430-078ec7269a17; e7e4d2eb-3f86-481b-a658-c913b96d0680

#### Request Body Example:
```json
{
    "title": "Question Title",
    "type": 1,
    "options": ["option1", "option2", "option3"],
    "minRating": 1,
    "maxRating": 5
}
```
### Postman Setup:

1. **Set the Method**:
   - In Postman, set the method to `PUT`.

2. **Enter the URL**:
   - Enter the URL: `http://localhost:{port}/api/questions/0038fe72-bfe0-4c56-9430-078ec7269a17` 

3. **Set the Body**:
   - Under the `Body` tab, select `raw` and choose `JSON`.
   - Paste the request body into the body section.

4. **Send the Request**:
   - Click `Send` to make the request.

### Response:

- **201 Created**: When a new question is added.
- **200 OK**: When an existing question is updated.

### 2. Get All Questions
- **URL:** `/api/questions`
- **Method:** `GET`

### Postman Setup:

1. **Set the Method**:
   - In Postman, set the method to `GET`.

2. **Enter the URL**:
   - Enter the URL: `http://localhost:{port}/api/questions`

3. **Send the Request**:
   - Click `Send` to make the request.

### Response:
- **200 OK**: Returns a list of all questions.
### 3. Get a Single Question
- **URL:** `/api/questions/{id}`
- **Method:** `GET`

##### URL Params:
- `id` (required): GUID of the question.

### Postman Setup:

1. **Set the Method**:
   - In Postman, set the method to `GET`.

2. **Enter the URL**:
   - Enter the URL: `http://localhost:{port}/api/questions/{id}`
   - 
3. **Send the Request**:
   - Click `Send` to make the request.

### Response:
- **200 OK**: Returns the question if found.
- **404 Not Found**: If the question does not exist.
### 4. Submit an Answer
- **URL:** `/api/questions/{id}`
- **Method:** `POST`

##### URL Params:
- `id` (required): GUID of the question.

### Request Body Example:

 1. **For a Rating Question** (e.g., `FiveStarRating`):
```json
{
  "answer": 4,
  "rating": "FiveStarRating"
}
```
2. **For Multiple Options Question:** 
```json
{
    "selection": ["option1", "option2"]
}
```
3. **For Single Option Question:** 
```json
{
    "selection": ["option1"]
}
```
### Postman Setup:

1. **Set the Method**:
   - In Postman, set the method to `POST`.

2. **Enter the URL**:
   - Enter the URL: `http://localhost:{port}/api/questions/{id}`

3. **Set the Body**:
   - Under the `Body` tab, select `raw` and choose `JSON`.

4. **Send the Request**:
   - Click `Send` to make the request.

### Response:
- **200 OK**: If the answer is successfully submitted.
- **400 Bad Request**: If the answer is invalid (e.g., out of range or invalid selection).