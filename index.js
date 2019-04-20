const http = require('http');
const { bookController } = require('./src/book-controller');

http.createServer(function(request, response) {

        bookController(request)
        .then(data => {

            response.writeHead(200, { 'Content-Type': 'application/json' });
            response.end(JSON.stringify(data));

        }).catch( err => {

            console.log('err', err)

            response.writeHead(err.statusCode || 500, { 'Content-Type': 'application/json' });
            response.end(JSON.stringify(err.message || 'Error'));

        })
  

}).listen(process.env.PORT || 3000);
console.log(`Server started at http://0.0.0.0:${process.env.PORT || 3000}/`);
