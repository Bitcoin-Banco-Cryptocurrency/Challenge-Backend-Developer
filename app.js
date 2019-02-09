const express = require('express');
const app = express();
const bookRoutes = require('./api/routes/books');
const testRoutes = require('./api/test/test');
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());
app.use('/books', bookRoutes);
app.use('/test', testRoutes);

module.exports = app;