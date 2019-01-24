var BooksDao = require('./BooksDao');

module.exports = class BooksBo {
    constructor(){
    }

    /**
     * @author Luiz Lima
     * @since 2019/01/24
     * @param {*} orderBy 
     * @param {*} specifications 
     * 
     * Find Books
     */
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
                            return genre.includes(specifications.genre);
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
            }).filter(function(book){
                if (specifications.published){
                    return book.specifications["Originally published"].includes(specifications.published);
                } else{
                    return true;
                }
            }).filter(function(book){
                if (specifications.pages){
                    return book.specifications["Page count"] == (specifications.pages);
                } else{
                    return true;
                }
            }).filter(function(book){
                if (specifications.illustrator){
                    if (typeof book.specifications.Illustrator === 'string'){
                        return book.specifications.Illustrator.includes(specifications.illustrator);
                    } else {
                        return book.specifications.Illustrator.some(function(illustrator){
                            return illustrator.includes(specifications.illustrator);
                        });
                    }
                } else {
                    return true;
                }
            });
        }
    }
}
