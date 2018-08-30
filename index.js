var http = require('http')

//var {controller} = require('src/controller')
var { initDatasource } = require('./src/datasource')
var { controller } = require('./src/controller')

try { initDatasource() }
catch (e) {
    console.error(e.toString())
    console.error('Error when initiating datasource, exiting...')
    process.exit(1)
}

http.createServer(function(request, response) {
    console.log('request ', request.url)
    controller(request.url, response)


}).listen(process.env.PORT || 8080)
console.log(`Server running at http://127.0.0.1:${process.env.PORT || 8080}/`)
