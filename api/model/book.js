
const books = require('../../books.json');

class Book {
    getAll() {
        return books;
    }
    getBookByID(bookID) {
        try {
            let filteredBooks = books.filter(function (book) {
                return book.id == bookID;
            });
            filteredBooks = filteredBooks.shift();
            return filteredBooks;
        } catch (error) {
            return null;
        }
    }
    getBooksByParams(params) {
        try {
            /*
            name: req.query.name,
            price: req.query.price,
            publishDate: req.query.publish_date,
            author: req.query.author,
            pageCount: req.query.page_count,
            illustrator: req.query.illustrator,
            genres: req.query.genres
            */
            function getFilteredList(list, field, param){
                return list.filter(function (item) {
                    return item[field] == param;
                });
            }

            let filteredBooks = books;
            if(params.name != null){
                filteredBooks = getFilteredList(filteredBooks, 'name', params.name);
            }
            if(params.price != null){
                filteredBooks = getFilteredList(filteredBooks, 'price', params.price);
            }
            if(params.publishDate != null){
                filteredBooks = getFilteredList(filteredBooks, "specifications['Originally published']", params.publishDate);
            }
            if(params.author != null){
                filteredBooks = getFilteredList(filteredBooks, "Author", params.author);
            }

            
            return filteredBooks;
        } catch (error) {
            return null;
        }
    }
}
module.exports = Book;