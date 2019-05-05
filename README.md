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

==============================================================

an explanation of what is needed to make your project work;
- An environment with node installed is mandatory
- After downloading the code, go to the folder and type the following command line: node index.js

an explanation of how to perform the tests
- Endpoint is called search: localhost:3000/search
- The following are accepted via query string: published to search in Originally published; author to search in Author; pageCount to search in Page count, illustrator to search in Illustrator; genre to search in Genres; order to order by price (ASC or DESC values only)
- Only one value per parameter is possible and it must be the exact value found in one of the items in books.json
- You can combine parameters
- Examples: http://localhost:3000/search?genre=Adventure%20fiction, http://localhost:3000/search?author=J.%20K.%20Rowling&order=ASC, http://localhost:3000/search?author=J.%20K.%20Rowling&order=DESC, http://localhost:3000/search?illustrator=Cliff%20Wright&order=ASC