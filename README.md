<p align="center">
  <a href="https://www.btc-banco.com">
      <img src="https://s3.amazonaws.com/assinaturas-de-emails/btc.png" alt="Grupo Bitcoin Banco"/>
  </a>
</p>

## Challenge for Developer

Search book API

## Requirements

* Node v8 installed.

## start application 
* Run the command `npm install`
* Run the command `npm start`
* Server will be running by the enviroment variable `PORT`, or `3000`.

## Commands

Access the following endpoint to get book `/books`.

All parameters must be encoded in the URL

Parameter|Value|Description
----|----|----
|"id"| Any String | Show only books which id contain this string.
|"sort"| "asc" or "desc"| Orders by price
|Any Specification| Any String | Show only books which id contain this string.

## Exemples

* `http://localhost:3000/books?id=1` - Searches only books with this id
* `http://localhost:3000/books?Genres=Fantasy&sort=desc` - Searches only books with the Genres Fantasy and sort by descending price

## Test
* To make test, install packages `npm install`
* start the server with `npm start` 
* In another window terminal run `npm run test`
