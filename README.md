# Advanced File Handling in C#

A practical learning repository focused on understanding and implementing file handling in C#. It covers file and directory operations, data persistence, CRUD operations, JSON serialization, and object-oriented programming concepts.

## Topics Covered

- File and Directory Operations
- Reading, Writing, and Appending Files
- Building a Simple File Explorer
- Working with File Helper Classes
- Saving and Managing Lists of Objects
- Implementing CRUD Operations Using Files
- Code Refactoring and OOP Principles
- JSON Serialization and Deserialization
- Using JSON for Data Persistence
- Applying Interfaces to Support Different Storage Implementations

## Learning Objectives

- Understand file handling concepts in C#.
- Practice storing and retrieving data using files.
- Apply OOP principles to organize and maintain code.
- Understand JSON serialization and deserialization.
- Use interfaces to make storage implementations more flexible.


## Architecture Diagram

The following diagram illustrates the application's overall architecture and the interaction between its main components, from user input to file system operations.

```mermaid
flowchart TD
    A["Program.cs<br/>Application Entry Point"] --> B["Main Menu"]
    B --> C{"User Selection"}

    C --> D["Directory Operations"]
    C --> E["File Operations"]
    C --> F["Simple File Explorer"]

    D --> G["Directory / DirectoryInfo"]
    E --> H["File / FileInfo"]
    F --> G
    F --> H

    G --> I["File System"]
    H --> I

    I --> J["Files and Directories<br/>on Disk"]

