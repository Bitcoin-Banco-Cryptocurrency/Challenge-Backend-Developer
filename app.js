const express = require('express');
const app = express();
const bookRoutes = require('./api/routes/books');

app.use('/books', bookRoutes);

module.exports = app;