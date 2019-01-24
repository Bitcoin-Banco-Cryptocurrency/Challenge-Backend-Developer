var express = require('express');
var router = express.Router();
//var BooksDao = require('../BooksDao');
var BooksBo = require('../BooksBo');

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Books' });
});

/* GET new page. */
router.get('/new', function(req, res, next) {
  res.render('new', { title: 'Novo Cadastro' });
});

/* GET new page. */
router.post('/new', function(req, res, next) {
  var nome = req.body.nome;
  var idade = req.body.idade;

  console.log(nome);

  res.redirect('/?nome=' + nome);
});

router.get('/list', function(req, res, next) {
  var bo = new BooksBo();
  var specfications = {genre:"Adventure", author:"Jules"};
  res.render('index', {title:'Books', customers: bo.findBooks("desc", specfications)});
});

module.exports = router;
