# FileManagementAPI
Working with Files and PostgresDB: Basic/fundamental Operations

Efficiently handle files and database operations(using PostgresDB) with services for storing, retrieving, deleting, and updating files.

the API supports HTTP requests using Swagger, allowing for easy integration and testing of the provided services. Unit tests for all the methods in the Services.

The current implementation of the `getFile` method returns a `FileDB` object without proper error handling. This could lead to potential malfunctions and may not provide informative responses in case of errors during file retrieval.
