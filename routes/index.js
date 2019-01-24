var express = require('express');
var router = express.Router();
var BooksBo = require('../BooksBo');
var BooksBoTest = require('../BooksBoTest');

router.post('/', function(req, res) {
  var bo = new BooksBo();
  
  var specfications = {};

  if(req.body.author)
    specfications.author = req.body.author;
  
  if(req.body.genre)
    specfications.genre = req.body.genre;

  if(req.body.published)
    specfications.published = req.body.published;
  
  if(req.body.pages)
    specfications.pages = req.body.pages;
  
  if(req.body.illustrator)
    specfications.illustrator = req.body.illustrator;
  
  res.render('index', {title:'Books', customers: bo.findBooks("desc", specfications)});
});

router.get('/', function(req, res) {
  res.render('index', {title:'Books',customers:[]});
});

router.get('/test', function(req, res) {
  var test = new BooksBoTest();
  res.render('test', {msg:test.findBooksTest()});
});

module.exports = router;
