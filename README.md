### Customers

- **POST /api/customers**  
  **Description:** Creates a new customer.  
  **Request Body:**  
  A JSON object containing the customer details.  
  **Example:**
  ```json
  {
    "name": "John Doe",
    "email": "john.doe@example.com",
    "address": "123 Main St"
  }

- **GET /api/customers/{customerId}**  
  **Description:** Retrieves the details of a customer by their unique `customerId`.  
  **Path Parameters:**  
    - `customerId` (required): The unique identifier for the customer. Must be an integer.  
  **Response:**
    - **202 Accepted**  
      **Description:** Indicates that the customer retrieval process has been initiated and a message has been sent to the message queue.  
      **Body Example:**
      ```json
      {
        "Message": "Customer retrieval started.",
        "CorrelationId": "generated-correlation-id"
      }
      ```
    - **400 Bad Request**  
      **Description:** Returned when the `customerId` is not provided or is null.  
      **Body Example:**
      ```json
      {
        "Error": "Customer Id is null"
      }
      ```

  
