<p align="center">
  <a href="https://www.btc-banco.com">
      <img src="https://s3.amazonaws.com/assinaturas-de-emails/btc.png" alt="Grupo Bitcoin Banco"/>
  </a>
</p>

## Challenge for Developer

### Developer Level
- Mid-level
- Senior

A customer needs to search in our product catalog (available in this <a href="https://github.com/Bitcoin-Banco-Cryptocurrency/challenge/blob/master/books.json">JSON</a>) and he wants to find products that suit his style of reading.
Based on this you will need to develop:

- a simple API to search products in the .json available;
- it should be possible to search for products by their specifications (one or more);
- it must be possible to order the result by price (asc and desc);

The test should be done in Ruby, Go, Python or Node and we do like if you avoid frameworks. We expect at the end of the test, outside the API running, the following items:

- an explanation of what is needed to make your project work;
- an explanation of how to perform the tests

Remember that at the time of the evaluation we will look at:

- Code organization;
- Object-Oriented Principles;
- Maintenance;
- Version control knowledge;
- Unit Test;
- Design Pattern;

To send us your code, you must:

Make a fork of this repository, and send us a pull-request.


## Documentation 

To run the project, in "src/BancoBitcoin.Api" path, execute the command: dotnet build
After that, execute next command: dotnet run
API will run in URL path: http://localhost:5000

Also, To run the test project, in "test/BancoBitcoin.Api", execute the command: dotnet test

If you want to use Swagger, you just need to add /swagger after main URL.
For example, to get a book by url parameters:
  http://localhost:5000/api/Book/GetBooksBySpecification?author=Jule&pageCount=0&order=false

File has been added Teste.postman_collection.json for integration test by Newman.

** SYSTEM

![alt text](https://github.com/awilliansd/Challenge-Backend-Developer/blob/master/assets/Sistema.png)

** TEST SHELL COMMAND

![alt text](https://github.com/awilliansd/Challenge-Backend-Developer/blob/master/assets/TestShellCommand.png)

** KITEMATIC

![alt text](https://github.com/awilliansd/Challenge-Backend-Developer/blob/master/assets/Kitematic.png)


** POSTMAN - NEWMAN

** KITEMATIC

![alt text](https://github.com/awilliansd/Challenge-Backend-Developer/blob/master/assets/Postman.png)
