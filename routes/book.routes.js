const express = require('express')
const router = express.Router()
const book = require('../models/book.model')
const m = require('../helpers/middlewares')

const sortJsonArray = require('sort-json-array');
const moment = require('moment');

/* All books */
router.get('/', async (req, res) => {
    const order = req.query.order
    const specifications = req.query.published
    const author = req.query.author
    const page = req.query.page

    await book.getPosts()
    .then(books => {
      books = sortJsonArray(books, "id")
        if(specifications){
          published = moment(specifications, "DD/MM/YYYY").format("MMMM DD, YYYY")
          books = books.filter(function(book){ return book["specifications"]["Originally published"]==published})
        }
        if(author){
          books = books.filter(function(book){ return book["specifications"]["Author"]==author})
        }
        if(page){
          books = books.filter(function(book){ return book["specifications"]["Page count"]==page})
        }
        if(order)
          if (order  == "asc" )
            books = books.sort(function(a,b){if(a.price < b.price) return -1;if(a.price > b.price) return 1; return 0;})
          else if (order == "desc")
            books = books.sort(function(a,b){if(a.price > b.price) return -1;if(a.price < b.price) return 1; return 0;})

        res.json(books)
      }
    )
    .catch(err => {
        if (err.status) {
          res.status(err.status).json({ message: err.message })
        } else {
          res.status(500).json({ message: err.message })
        }
    })
})

/* A book by id */
router.get('/:id', m.mustBeInteger, async (req, res) => {
    const id = req.params.id

    await book.getPost(id)
    .then(book => res.json(book))
    .catch(err => {
        if (err.status) {
            res.status(err.status).json({ message: err.message })
        } else {
            res.status(500).json({ message: err.message })
        }
    })
})

/* Insert a new book */
router.post('/', m.checkFieldsPost, async (req, res) => {
    await book.insertPost(req.body)
    .then(book => res.status(201).json({
        message: `The book #${book.id} has been created`,
        content: book
    }))
    .catch(err => res.status(500).json({ message: err.message }))
})

/* Update a book */
router.put('/:id', m.mustBeInteger, m.checkFieldsPost, async (req, res) => {
    const id = req.params.id

    await book.updatePost(id, req.body)
    .then(book => res.json({
        message: `The book #${id} has been updated`,
        content: book
    }))
    .catch(err => {
        if (err.status) {
            res.status(err.status).json({ message: err.message })
        }
        res.status(500).json({ message: err.message })
    })
})

/* Delete a book */
router.delete('/:id', m.mustBeInteger, async (req, res) => {
    const id = req.params.id

    await book.deletePost(id)
    .then(book => res.json({
        message: `The book #${id} has been deleted`
    }))
    .catch(err => {
        if (err.status) {
            res.status(err.status).json({ message: err.message })
        }
        res.status(500).json({ message: err.message })
    })
})

module.exports = router
