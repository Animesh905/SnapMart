# User Module Documentation

## Overview
The User Module handles all user-related operations, such as user registration, authentication, and profile management.

## API Endpoints

### 1.  GET /api/user/{id}**
- **Description:** Fetches details of a user by their ID.
- **Request Parameters:**
  - `id`: The unique identifier for the user (int).
- **Response Example:**
```json
{
  "id": 1,
  "name": "John Doe",
  "email": "johndoe@example.com"
}
