/**
 * Books Router
 */
var express = require('express');
var router = express.Router();
var BooksDao = require('./BooksDao');

router.get('/', function(req, res, next) {
    var dao = new BooksDao();
    res.send(dao.getBooks());
});

module.exports = router;
