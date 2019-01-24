var BooksDao = require('./BooksDao');

module.exports = class BooksBo {
    constructor(){

    }

    findBooks(orderBy, specifications){
        var dao = new BooksDao();
        var list = dao.getBooks();

        if (orderBy === "asc"){
            return list.sort(function(book1, book2){
                return book1.price - book2.price;
            });
        } else {
            return list.sort(function(book1, book2){
                return book2.price - book1.price;
            })
            .filter(function(book){
                if (specifications.genre){
                    if (typeof book.specifications.Genres === 'string'){
                        return book.specifications.Genres.includes(specifications.genre);
                    } else {
                        return book.specifications.Genres.some(function(genre){
                            return genre.includes('Adventure');
                        });
                    }
                } else {
                    return true;
                }
            }).filter(function(book){
                if (specifications.author){
                    return book.specifications.Author.includes(specifications.author);
                } else{
                    return true;
                }
            });
        }
    }
}
