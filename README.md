<p align="center">
  <a href="https://www.btc-banco.com">
      <img src="https://s3.amazonaws.com/assinaturas-de-emails/btc.png" alt="Grupo Bitcoin Banco"/>
  </a>
</p>

## Challenge for Developer

This API was created for Bitcoin Banco Cryptocurrency Challenge by Felipe Lopes Pereira. The language choose was Ruby.

Some specifications:

- API endpoint only accept 'GET'
- The endpoint is 'search'
- The configured server port is '8080'
- This API dont have any frameworks, only two gems to help in the test scripts

1. Run

To run this API its necessary:

- Ruby v2.4.1 or higher
- Bundle installed
- Run the command 'bundle install', dependency gems only used in tests scripts
- Run the command 'ruby server.rb' to start the server, the configured port is '8080'

2. Commands

"Name" = Any String --- Show books that contain this name.
"Sort" = "asc" or "desc" --- Order by price.
Specification = Any String --- Show books that contain this specifications. Any specification is accepted.

Examples:

https://127,0,0,1:8080/search?Author=J. K. Rowling&Sort=asc
https://127,0,0,1:8080/search?Illustrator=GrandPré

3. Tests

Start the server with command 'ruby server.rb' then run 'ruby test.rb'

The gems used are:

- 'test-util' is a tests helper
- 'patron' is a HTTP protocol helper
