const express = require('express');
const router = express.Router();
const Book = require('../model/book.js');

/**
 * Recupera todos os livros
 */
router.get('/', (req, res) => {
    try {
        const bookModel = new Book();
        const books = bookModel.getAll();
        res.status(200).json({ books });
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Recupera um livro específico por ID
 */
router.get('/:id', (req, res) => {
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
 * rota exemplo: http://localhost:3000/books/filtered/book?name=teste&price=teste&publish_date=teste&genres=teste&genres=teste
 */
router.get('/filtered/book', (req, res) => {
    try {
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
        const book = BookModel.getBooksByParams(params);
        if(book != null && book.length > 0){
            res.status(200).json({ book });
        }else{
            res.status(404).json({ message: params });
        }
    } catch (error) {
        res.status(500).json({ error });
    }
});

router.post('/', (req, res) => {
    res.status(200).json({
        message: "Deu boa"
    });
});

module.exports = router;