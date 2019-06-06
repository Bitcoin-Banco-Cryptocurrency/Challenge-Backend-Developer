## BookApi Project

### Project DEMO
https://booksapibitcoinbanco.azurewebsites.net/api

### How to run

- Clone this project
- `dotnet run` in `BooksApi.Api` folder
- navigate to /api

### How to run unit tests
- `dotnet test` in `BooksApi.Tests` folder

### How to use graphql playgound

#### Basic query:
``` 
query BookApi {
  books{
    id
    name
    price
    specifications{
      author
      pageCount
      originallyPublished
      genres
      illustrator
    }
  }
}
```

#### Filtering:
``` 
query BookApi {
  books(author: "Jules Verne"){
    id
    name
   ...
}
```
Filters available: author, pageCount, genre, illustrator

#### Sorting:
``` 
query BookApi {
  books(sortByPrice: "Ascending"){
    id
    name
   ...
}
```
Sorting available: Ascending, Descending
