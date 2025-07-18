# Book Management Backend API

A RESTful Web API built with ASP.NET Core for managing books. This project provides full CRUD operations for book management with Entity Framework Core and SQL Server integration.

## Features

- **Complete CRUD Operations**: Create, Read, Update, and Delete books
- **Entity Framework Core**: Database operations with Code First approach
- **AutoMapper Integration**: Automatic mapping between entities and DTOs
- **Repository Pattern**: Clean separation of concerns
- **Swagger Documentation**: Interactive API documentation
- **SQL Server Database**: Reliable data persistence
- **RESTful API Design**: Standard HTTP methods and status codes

## Technologies Used

- **ASP.NET Core 8.0** (or your version)
- **Entity Framework Core**
- **SQL Server**
- **AutoMapper**
- **Swagger/OpenAPI**
- **Repository Pattern**

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/books` | Get all books |
| GET | `/api/books/{id}` | Get book by ID |
| GET | `/api/books/title/{title}` | Get book by title |
| POST | `/api/books` | Create a new book |
| PUT | `/api/books/{id}` | Update an existing book |
| DELETE | `/api/books/{id}` | Delete a book |

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (or your version)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB, Express, or Full)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Setup Instructions

### 1. Clone the Repository

```bash
git clone [your-repository-url]
cd Book_Management_Backend
```

### 2. Configure Database Connection

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BookManagementDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

**Note**: Adjust the connection string based on your SQL Server setup:
- For LocalDB: `Server=(localdb)\\mssqllocaldb;Database=BookManagementDb;Trusted_Connection=true`
- For SQL Server Express: `Server=.\\SQLEXPRESS;Database=BookManagementDb;Trusted_Connection=true`
- For Full SQL Server: `Server=localhost;Database=BookManagementDb;Trusted_Connection=true`

### 3. Install Dependencies

```bash
dotnet restore
```

### 4. Create and Apply Database Migrations

```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
```

### 5. Run the Application

```bash
dotnet run
```

The API will be available at:
- **HTTPS**: `https://localhost:7xxx`
- **HTTP**: `http://localhost:5xxx`
- **Swagger UI**: `https://localhost:7xxx/swagger`

## Project Structure

```
Book_Management_Backend/
├── Controllers/
│   └── BooksController.cs          # API endpoints
├── Entities/
│   └── Book.cs                     # Book entity model
├── Dtos/
│   └── BookDto.cs                  # Data transfer objects
├── Interfaces/
│   └── IbookInterface.cs           # Repository interface
├── Repositories/
│   └── BookRepository.cs           # Repository implementation
├── BookDbContext.cs                # Entity Framework context
├── MappingProfile.cs               # AutoMapper configuration
├── Program.cs                      # Application entry point
└── appsettings.json                # Configuration file
```

## Sample API Usage

### Create a Book
```http
POST /api/books
Content-Type: application/json

{
  "title": "The Great Gatsby",
  "author": "F. Scott Fitzgerald",
  "publishedYear": 1925,
  "genre": "Fiction"
}
```

### Get All Books
```http
GET /api/books
```

### Get Book by ID
```http
GET /api/books/1
```

### Update a Book
```http
PUT /api/books/1
Content-Type: application/json

{
  "title": "The Great Gatsby - Updated",
  "author": "F. Scott Fitzgerald",
  "publishedYear": 1925,
  "genre": "Classic Fiction"
}
```

### Delete a Book
```http
DELETE /api/books/1
```

## Configuration Notes

### CORS (Optional)
The project includes commented CORS configuration in `Program.cs`. To enable CORS for frontend integration, uncomment the following lines:

```csharp
builder.Services.AddCors(Options =>
{
    Options.AddPolicy("MyPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
```

And in the middleware pipeline:
```csharp
app.UseCors("MyPolicy");
```

### Static Files (Optional)
Static file serving is available but commented out. Uncomment `app.UseStaticFiles();` if needed.

## Assumptions and Design Decisions

1. **Database**: Uses SQL Server with Entity Framework Core Code First approach
2. **Repository Pattern**: Implements repository pattern for data access abstraction
3. **AutoMapper**: Used for mapping between entities and DTOs
4. **Error Handling**: Basic exception handling with appropriate HTTP status codes
5. **Validation**: Relies on model validation attributes (can be extended)
6. **Authentication**: Not implemented (can be added as needed)

## Testing

The API can be tested using:
- **Swagger UI**: Available at `/swagger` endpoint
- **Postman**: Import the API endpoints
- **curl**: Command-line testing
- **Unit Tests**: Can be added using xUnit framework

