const express = require('express');
const router = express.Router();
const request = require('request');

/**
 * Realiza os testes com a expectativa de obter sucesso em todos
 */
router.get('/sucess', async (req, res) => {
    try {
        const host = req.headers.host;
        function requestRoute(url, method, json = true, expectedStatus) {
            return new Promise(function (resolve, reject) {
                request({
                    url: url,
                    method: method,
                    json: json
                }, function (err, res, body) {
                    if (err) { console.log(`${method} ${url} error: ${err}`); return null; }
                    resolve({
                        method: method,
                        route: url,
                        expectedStatus: expectedStatus,
                        receivedStatus: res.statusCode
                    })
                });
            });
        }
        let dataPost = {
            name: "The Boy in the Striped Pyjamas",
            price: 10.00,
            publish_date: "2006",
            author: "John Boyne",
            page_count: 216,
            illustrator: null,
            genres: "Juvenil"
        }
        let dataPut = {
            name: "Test Book",
            price: 15.00,
            publish_date: "February 08, 2019",
            author: "Caio",
            page_count: 100,
            illustrator: "Caio",
            genres: "Action"
        }
        Promise.all([
            requestRoute(`http://${host}/books/`, 'GET', true, 200),
            requestRoute(`http://${host}/books/book/1`, 'GET', true, 200),
            requestRoute(`http://${host}/books/search?name=Journey to the Center of the Earth&price=10.00&publish_date=November 25, 1864&author=Jules Verne&page_count=183&illustrator=Édouard Riou&genres=Science Fiction&genres=Adventure Fiction`, 'GET', true, 200),
            requestRoute(`http://${host}/books?order=DESC`, 'GET', true, 200),
            requestRoute(`http://${host}/books/`, 'POST', dataPost, 201),
            requestRoute(`http://${host}/books/3`, 'PUT', dataPut, 200),
            requestRoute(`http://${host}/books/4`, 'DELETE', true, 200)
        ])
        .then(([get1, get2, get3, get4, post1, put1, delete1]) => {
            let testResult = [];
            testResult.push(get1);
            testResult.push(get2);
            testResult.push(get3);
            testResult.push(get4);
            testResult.push(post1);
            testResult.push(put1);
            testResult.push(delete1);
            res.status(200).json({ testResult });
        })
        .catch((error) => {
            console.log(error);
            res.status(500).json({ message: 'Test fail.' });
        })
    } catch (error) {
        res.status(500).json({ error });
    }
});

module.exports = router;