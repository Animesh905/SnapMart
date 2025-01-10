# User Module Documentation

## Overview
The User Module handles all user-related operations, such as user registration, authentication, and profile management.

## API Endpoints

### 1. **GET** [https://agri20-admin-uat.azurewebsites.net/api/v1/User/GetUser](URL "Get User")

- **Description:** Fetches details of a user by their ID.
- **Request Parameters:**
  - `id`: The unique identifier for the user (int).
  - `name`: The name for the user (string).
- **Response Example:**
```json
{
  "id": 1,
  "name": "John Doe",
  "email": "johndoe@example.com"
}
```

