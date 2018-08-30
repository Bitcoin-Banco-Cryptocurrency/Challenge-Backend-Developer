var { search } = require('./datasource')


module.exports.controller = async function(url, response) {
    try {
        if (/^\/search/.test(url)) {
            var regex = /[?&]([^=#]+)=([^&#]*)/g

            var params = {},
                match

            while (match = regex.exec(url)) {
                params[match[1]] = decodeURIComponent(match[2])
            }

            var res = await search(params)

            response.writeHead(200, { 'Content-Type': 'application/json' })
            response.end(JSON.stringify(res))
        }
        else {
            response.writeHead(404, { 'Content-Type': 'application/json' })
            response.end(JSON.stringify('Page not found'))
        }
    }
    catch (e) {
        console.error(`Request ${url} has returned the following error`, e)
        response.writeHead(500, { 'Content-Type': 'application/json' })
        response.end(JSON.stringify('Erro'))
    }
}
