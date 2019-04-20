const { loadBooks } = require('./book-services');
const { to } = require('./helpers');

async function bookController(request){
    if (/^\/books/.test(request.url)) {
        const [err, books] = await to((loadBooks()))
        if(!!err) throw { statusCode: 500, message: 'Error loading books', err };
        return books;
    } else {
        throw { statusCode: 404, message: 'URL not found' };
    }
}

module.exports = {
    bookController
}