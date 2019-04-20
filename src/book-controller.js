const url = require('url');
const { loadBooks, searchBooks } = require('./book-services');
const { to } = require('./helpers');

async function bookController(request){
    if (/^\/books/.test(request.url)) {
        const [err, books] = await to((loadBooks()))
        if(!!err) throw { statusCode: 500, message: 'Error loading books', err };

        const query = url.parse(request.url, true).query;
        if(Object.keys(query).length === 0){
            return books;
        }

        const [searchError, booksSearched] = await to(searchBooks(query, books));
        if(!!searchError) throw { statusCode: 500, message: 'Error searching books', searchError };
        
        return booksSearched;
    } else {
        throw { statusCode: 404, message: 'URL does not exist' };
    }
}

module.exports = {
    bookController
}