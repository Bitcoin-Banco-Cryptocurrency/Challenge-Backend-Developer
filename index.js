var http = require('http');
const { loadBooks } = require('./src/book-services');

http.createServer(function(request, response) {}).listen(process.env.PORT || 3000);
console.log(`Server started at http://0.0.0.0:${process.env.PORT || 3000}/`)
