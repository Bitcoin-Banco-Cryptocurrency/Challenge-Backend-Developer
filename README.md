<!--<p align="center">
  <a href="https://www.btc-banco.com">
      <img src="https://s3.amazonaws.com/assinaturas-de-emails/btc.png" alt="Grupo Bitcoin Banco"/>
  </a>
</p> -->

## Challenge for Developer

To run this API, follow the following instructions:

* You need Node v8 installed.
* Run the command `npm start`
* The server should start on port configured by the enviroment variable `PORT`, or `8080`.

## Commands

The API has a single endpoint, `search`, and only accepts the verb `GET`.

All parameters must be encoded in the URL, folowing the following schema:

Parameter|Value|Description
----|----|Description
|"Name"| Any String | Show only books which names contain this string.
|"Sort"| "asc" or "desc"| Orders by price
|Any Specification| Any String | Show only books which names contain this string.

Examples:
* `https://localhost:8080/search?Name=Journey to the Center of the Earth` - Searches only books with this name
* `https://localhost:8080/search?Illustrator=Édouard&Sort=desc` - Searches only books with the Illustrator Édouard and sort by descending price

## Testing
* To test, run the command `npm install`
* In another terminal, start the server (`npm start`)
* Then run the command `npm test`

## Notes
* There are no dependencies to the project, therefore it is only using vanilla Node.js
* All the filters are case-insensitive
