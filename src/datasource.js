/* This file should export the following functions
    async function initDatasource() //May throw error.
    async function search() //May throw error.
 */

const { escapeRegExp, sortBookPrice, sortBookPriceDesc } = require('./utils')
//All data shall be loaded in this variable.
var data = []


// This function is on the start of the application to create the connection with
// the database (in this case, with the books.json file.).
module.exports.initDatasource = async function() {
    console.log('Starting initiating datasouce')

    const fs = require('fs')
    const util = require('util')

    const readfile = util.promisify(fs.readFile)

    var booksString = await readfile('./books.json')

    data = JSON.parse(booksString)

    console.log('Successfully initiated datasource')
    return
}


module.exports.search = async function(params) {

    // The script here defined is not the best for large datasets, therefore,
    // it is recomended using a database with fast search, using for example 
    // Lucene ElasticSearch

    var res = data


    //Searches the name
    if (params.Name) {
        var nameRegex = new RegExp(escapeRegExp(params.Name), 'i')
        res = res.filter(book => nameRegex.test(book.name))
        delete params.Name
    }

    var sort = ''
    //Gets sort param
    if (params.Sort) {
        sort = params.Sort
        delete params.Sort
    }

    //Searches the rest of the inputs
    for (var key in params) {
        var paramRegex = new RegExp(escapeRegExp(params[key]), 'i')

        res = res.filter(book => {

            if (book.specifications[key]) { // Key exists 
                var testArray = book.specifications[key];

                if (!Array.isArray(book.specifications[key])) { // Transform into an array of strings...
                    testArray = [book.specifications[key].toString()]
                }
                // Check if at least one element contain the string specified
                return testArray.some(
                    specification => paramRegex.test(specification))
            }
            else { // Book does not contain the specification specified...
                return false
            }
        })
    }

    if (sort === 'asc') {
        res = res.sort(sortBookPrice)
    }
    if (sort === 'desc') {
        res = res.sort(sortBookPriceDesc)
    }

    return res
}
