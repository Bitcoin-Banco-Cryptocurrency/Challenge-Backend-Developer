const express = require('express');
const router = express.Router();
const Book = require('../model/book.js');

function validateFields(req, res, next) {
    if(req.body.name == null || req.body.price == null || req.body.publish_date == null || req.body.author == null || req.body.page_count == null || req.body.illustrator == null || req.body.genres == null){
        res.status(400).json({ message: "One or more parameters are null!" });
    }else{
        next();
    }
}

/**
 * Recupera todos os livros
 */
router.get('/', (req, res) => {
    try {
        const order = req.query.order;
        const bookModel = new Book();
        const books = bookModel.getAll(order);
        res.status(200).json({ books });
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Recupera um livro específico por ID
 */
router.get('/book/:id', (req, res) => {
    try {
        const bookModel = new Book();
        const book = bookModel.getBookByID(req.params.id);
        if(book != null){
            res.status(200).json({ book });
        }else{
            res.status(404).json({ message: "Book not found." });
        }
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Recupera o(s) livro(s) com base nos filtros
 * rota exemplo: http://localhost:3000/books/search?name=Journey to the Center of the Earth&price=10.00&publish_date=November 25, 1864&author=Jules Verne&page_count=183&illustrator=Édouard Riou&genres=Science Fiction&genres=Adventure Fiction
 */
router.get('/search', (req, res) => {
    try {
        const order = req.query.order;
        const params = {
            name: req.query.name,
            price: req.query.price,
            publishDate: req.query.publish_date,
            author: req.query.author,
            pageCount: req.query.page_count,
            illustrator: req.query.illustrator,
            genres: req.query.genres
        }
        const BookModel = new Book();
        const book = BookModel.getBooksByParams(order, params);
        if(book != null && book.length > 0){
            res.status(200).json({ book });
        }else{
            res.status(404).json({ message: 'Book(s) not found.' });
        }
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Insere um novo livro
 */
router.post('/', validateFields, (req, res) => {
    try {
        let payload = {
            id: 0,
            name: req.body.name,
            price: parseFloat(req.body.price),
            specifications: {
                'Originally published': req.body.publish_date,
                Author: req.body.author,
                'Page count': req.body.page_count,
                Illustrator: req.body.illustrator,
                Genres: req.body.genres
            }
        }
        const BookModel = new Book();
        const addedBook = BookModel.addBook(payload);
        res.status(201).json({ addedBook });
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Edita um livro específico
 */
router.put('/:id', (req, res) => {
    try {
        const BookModel = new Book();
        const response = BookModel.updateBook(req.params.id, req.body);
        if(response === 200){
            res.status(response).json({ message: 'Updated.'});
        }else if(response === 404){
            res.status(response).json({ message: 'Book not found.'});
        }else{
            res.status(response).json({ message: 'Error.'});
        }
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Remove um novo livro específico
 */
router.delete('/:id', (req, res) => {
    try {
        const BookModel = new Book();
        const response = BookModel.removeBook(req.params.id);
        if(response === 200){
            res.status(response).json({ message: 'Deleted.'});
        }else if(response === 404){
            res.status(response).json({ message: 'Book not found.'});
        }else{
            res.status(response).json({ message: 'Error.'});
        }
    } catch (error) {
        res.status(500).json({ error });
    }
});

module.exports = router;