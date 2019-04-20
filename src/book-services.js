const util = require('util');
const fs = require('fs');
const { to } = require('./helpers');

async function loadBooks(){
    const readFile = util.promisify(fs.readFile);
    const [err, books] = await to(readFile('./books.json'));
    if(err) throw err;
    return JSON.parse(books);
}

module.exports = {
    loadBooks
}