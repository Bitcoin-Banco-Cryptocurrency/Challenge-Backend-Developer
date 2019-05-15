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

==========================================================================

To make the project work:

1 - Visual Studio 2019 required;
2 - Set as StartUp project BBCReadJson.Services.Api;
3 - The Challenge-Backend-Developer / BBCReadJson / BBCReadJson.Infra.Data / Data / books.json file is with the Copy to Output Directory property to Copy always;
4 - Run the project;

To perform the tests:

1 - When running the project the screen with the swagger will open;
2 - Fill in the required parameters:
  2.1 - Parameter search: Search by Name, Author, Illustrator and Genres.
  2.2 - Parameter order: Order by PriceASC or PriceDESC, any other value will not be performed ordering.
3 - Click execute;
4 - Wait for the return to appear just below;
