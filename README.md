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

## Candidate 

Steps to execute the project:
- Install git, with git bash
- After install, create a new folder to clone the project
- Access the new folder through the git bash(terminal/prompt) 'n paste this command: git clone git@github.com:Bitcoin-Banco-Cryptocurrency/Challenge-Backend-Developer.git
- Verify that you have already installed the NodeJS on your computer
- After install the Node JS, run on git bash this command: "npm start"
- To sample test, run this on ur browser: "http://localhost:3000/books/book/1"
- To test other routes, use the POSTMAN

## Tests

I has created a sample of unity tests, the routes are on the test.js, on test folder.
To run tests, execute the following routes:
- This route test the 200 http status of all GET methods with fixed params
http://localhost:3000/test
- This route test the 201 http status of POST method
http://localhost:3000/test/create
- This route test the 200 http status of PUT method
http://localhost:3000/test/update
- This route test the 200 http status of DELETE method
http://localhost:3000/test/remove

Now, the following routes of test handle the fail responses:
- This route try search by a unexisting book id or invalid value of parameter
http://localhost:3000/search/fail
- This route try send a incomplete body requisition do create a new book
http://localhost:3000/create/fail
- This route try update a unexisting book
http://localhost:3000/update/fail
- This route try remove a unexisting book
http://localhost:3000/remove/fail