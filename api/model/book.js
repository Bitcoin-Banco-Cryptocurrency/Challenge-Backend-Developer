
const books = require('../../books.json');

class Book {
    getAll(order) {
        if(order === 'ASC'){
            books.sort((a, b) => parseFloat(a.price) - parseFloat(b.price));
        }else if(order === 'DESC'){
            books.sort((a, b) => parseFloat(b.price) - parseFloat(a.price));
        }
        return books;
    }
    getBookByID(bookID) {
        try {
            let filteredBooks = books.filter(function (book) {
                return book.id === parseInt(bookID);
            });
            filteredBooks = filteredBooks.shift();
            return filteredBooks;
        } catch (error) {
            return null;
        }
    }
    getBooksByParams(order, params) {
        try {
            function getFilteredList(list, field, subfield, param){
                let filteredList = [];
                for (var l in list) {
                    if (subfield == null){
                        if (Array.isArray(list[l][field])){
                            if (Array.isArray(param)){
                                for (var i in list[l][field]) {
                                    for (var p in param) {
                                        if(list[l][i] == param[p]){
                                            filteredList.push(list[l]);
                                        }
                                    }
                                }
                            }else{
                                for (var i in list[l][field]) {
                                    if(list[l][i] == param){
                                        filteredList.push(list[l]);
                                    }
                                }
                            }
                        }else{
                            if (Array.isArray(param)){
                                for (var i in params) {
                                    if(list[l][field] == params[i]){
                                        filteredList.push(list[l]);
                                    }
                                }
                            }else{
                                if(list[l][field] == param){
                                    filteredList.push(list[l]);
                                }
                            }
                        }
                    }else{
                        if (Array.isArray(list[l][field][subfield])){
                            if (Array.isArray(param)){
                                for (var i in list[l][field][subfield]) {
                                    for (var p in param) {
                                        if(list[l][field][subfield][i] == param[p]){
                                            filteredList.push(list[l]);
                                        }
                                    }
                                }
                            }else{
                                for (var i in list[l][field][subfield]) {
                                    if(list[l][field][subfield][i] == param){
                                        filteredList.push(list[l]);
                                    }
                                }
                            }
                        }else{
                            if (Array.isArray(param)){
                                for (var i in params) {
                                    if(list[l][field][subfield] == params[i]){
                                        filteredList.push(list[l]);
                                    }
                                }
                            }else{
                                if(list[l][field][subfield] == param){
                                    filteredList.push(list[l]);
                                }
                            }
                        }
                    }
                }
                return filteredList;
            }
            let filteredBooks = books;
            if(params.name != null){                
                filteredBooks = getFilteredList(filteredBooks, 'name', null, params.name);
            }
            if(params.price != null){
                filteredBooks = getFilteredList(filteredBooks, 'price', null, parseFloat(params.price));
            }
            if(params.publishDate != null){
                filteredBooks = getFilteredList(filteredBooks, "specifications", "Originally published", params.publishDate);
            }
            if(params.author != null){
                filteredBooks = getFilteredList(filteredBooks, "specifications", "Author", params.author);
            }
            if(params.pageCount != null){
                filteredBooks = getFilteredList(filteredBooks, "specifications", "Page count", params.pageCount);
            }
            if(params.illustrator != null && params.illustrator.length > 0){
                filteredBooks = getFilteredList(filteredBooks, "specifications", "Illustrator", params.illustrator);
            }
            if(params.genres != null && params.genres.length > 0){
                filteredBooks = getFilteredList(filteredBooks, "specifications", "Genres", params.genres);
            }
            if(order === 'ASC'){
                filteredBooks.sort((a, b) => parseFloat(a.price) - parseFloat(b.price));
            }else if(order === 'DESC'){
                filteredBooks.sort((a, b) => parseFloat(b.price) - parseFloat(a.price));
            }
            return filteredBooks;
        } catch (error) {
            return null;
        }
    }
    addBook(payload){
        try {
            const bookCount = books.length;
            payload.id = (parseInt(books[bookCount-1].id) + 1);
            books.push(payload);
            let fs = require('fs');
            fs.writeFile ("books.json", JSON.stringify(books), function(err) {
                    if (err) throw err;
                    console.log('Created!');
                }
            );
            return payload;
        } catch (error) {
            return null;
        }
    }
    removeBook(id){
        try {
            let newBookList = books.filter(function (book) {
                return book.id !== parseInt(id);
            });
            if(newBookList.length < books.length){
                let fs = require('fs');
                fs.writeFile ("books.json", JSON.stringify(newBookList), function(err) {
                        if (err) throw err;
                        console.log('Deleted!');
                    }
                );
                return 200;
            }else{
                return 404;
            }
        } catch (error) {
            console.log('teste')
            console.log(error);
            return 500;
        }
    }
    updateBook(id, payload){
        try {
            let updateBooks = false;
            let bookWasFound = false;
            for (var i in books) {
                if(books[i].id === parseInt(id)){
                    bookWasFound = true;
                    if(payload.name != null && books[i].name !== payload.name){                
                        books[i].name = payload.name;
                        updateBooks = true;
                    }
                    if(payload.price != null && books[i].price !== payload.price){
                        books[i].price = parseFloat(payload.price);
                        updateBooks = true;
                    }
                    if(payload.publish_date != null && books[i]['specifications']['Originally published'] !== payload.publish_date){
                        books[i]['specifications']['Originally published'] = payload.publish_date;
                        updateBooks = true;
                    }
                    if(payload.author != null && books[i]['specifications']['Author'] !== payload.author){
                        books[i]['specifications']['Author'] = payload.author;
                        updateBooks = true;
                    }
                    if(payload.page_count != null && books[i]['specifications']['Page count'] !== payload.page_count){
                        books[i]['specifications']['Page count'] = payload.page_count;
                        updateBooks = true;
                    }
                    if(payload.illustrator != null && payload.illustrator.length > 0 && books[i]['specifications']['Illustrator'] !== payload.illustrator){
                        books[i]['specifications']['Illustrator'] = payload.illustrator;
                        updateBooks = true;
                    }
                    if(payload.genres != null && payload.genres.length > 0 && books[i]['specifications']['Genres'] !== payload.genres){
                        books[i]['specifications']['Genres'] = payload.genres;
                        updateBooks = true;
                    }
                }
            }
            if(bookWasFound === true){
                if(updateBooks === true){
                    let fs = require('fs');
                    fs.writeFile ("books.json", JSON.stringify(books), function(err) {
                            if (err) throw err;
                            console.log('Updated!');
                        }
                    );
                }
                return 200;
            }else{
                return 404;
            }
        } catch (error) {
            return 500;
        }
    }
}
module.exports = Book;