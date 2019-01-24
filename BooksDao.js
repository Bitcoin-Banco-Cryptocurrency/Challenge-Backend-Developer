'use strict';

var json = require('./books.json');

module.exports = class BooksDao {
    getBooks() {
        return json;
   }

}
