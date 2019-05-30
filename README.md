<p align="center">
  <a href="https://www.btc-banco.com">
      <img src="https://s3.amazonaws.com/assinaturas-de-emails/btc.png" alt="Grupo Bitcoin Banco"/>
  </a>
</p>

## How to run this project?

### By Automated Testing
- Just open the solution file in visual studio and run the tests from Test Explorer Window 
- Or, by command line, navigate at the root folder of this app and run the following command
```
dotnet test
```

As simple as that

### By Manual Testing
- Open the solution file in visual studio and run the project by pressing F5 shortcut. It will open a browser with a list of books. You can use the OrderBy param as ASC(default) or DESC. Also, you can filter the collection using ```Name``` and/or ```Author``` params

- Or, by command line, navigate at the root folder of this app and run the following command
```
dotnet run
```

I hope you enjoy this very simple implementation!


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
