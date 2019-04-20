const util = require('util');
const fs = require('fs');
const { to, escape, sortPrice, sortDesc } = require('./helpers');

async function loadBooks(){
    const readFile = util.promisify(fs.readFile);
    const [err, books] = await to(readFile('./books.json'));
    if(err) throw err;
    return JSON.parse(books);
}

async function searchBooks(params, books) {

    let sort = '';

    if (params.id) {
        const reg = new RegExp(escape(params.id), 'i')
        books = books.filter(book => reg.test(book.id))
        delete params.id
    }

    if (params.sort) {
        sort = params.sort;
        delete params.sort;
    }

    for (let key in params) {
        let paramRegex = new RegExp(escape(params[key]), 'i')

        books = books.filter(book => {

            if (book.specifications[key]) { 
                let data = book.specifications[key];

                if (!Array.isArray(book.specifications[key])) { 
                    data = [book.specifications[key].toString()];
                }
                return data.some(specify => paramRegex.test(specify))
            } else {
                return false
            }
        })
    }

    if (sort === 'asc') {
        books = books.sort(sortPrice);
    }
    if (sort === 'desc') {
        books = books.sort(sortDesc);
    }

    return books;
}

module.exports = {
    loadBooks,
    searchBooks
}