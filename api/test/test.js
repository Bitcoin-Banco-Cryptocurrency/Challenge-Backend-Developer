const express = require('express');
const router = express.Router();
const request = require('request');

function requestRoute(url, method, json = true, expectedStatus) {
    return new Promise(async function (resolve, reject) {
        await request({
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

/**
 * 
 * --------- SUCCESS TESTS ---------
 * 
 */

/**
 * Realiza os testes de get com a expectativa de obter sucesso em todos
 */
router.get('/', async (req, res) => {
    try {
        const host = req.headers.host;
        Promise.all([
            requestRoute(`http://${host}/books/`, 'GET', true, 200),
            requestRoute(`http://${host}/books/book/1`, 'GET', true, 200),
            requestRoute(`http://${host}/books/search?name=Journey to the Center of the Earth&price=10.00&publish_date=November 25, 1864&author=Jules Verne&page_count=183&illustrator=Édouard Riou&genres=Science Fiction&genres=Adventure Fiction`, 'GET', true, 200),
            requestRoute(`http://${host}/books?order=DESC`, 'GET', true, 200)
        ])
        .then(([get1, get2, get3, get4]) => {
            let testResult = [];
            testResult.push(get1);
            testResult.push(get2);
            testResult.push(get3);
            testResult.push(get4);
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

/**
 * Realiza o teste de post com a expectativa de obter sucesso
 */
router.get('/create', async (req, res) => {
    try {
        const host = req.headers.host;
        let dataPost = {
            name: "The Boy in the Striped Pyjamas",
            price: 10.00,
            publish_date: "2006",
            author: "John Boyne",
            page_count: 216,
            illustrator: null,
            genres: "Juvenil"
        }
        Promise.all([requestRoute(`http://${host}/books/`, 'POST', dataPost, 201)])
        .then(([post1]) => {
            res.status(200).json({ post1 });
        })
        .catch((error) => {
            console.log(error);
            res.status(500).json({ message: 'Test fail.' });
        })
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Realiza o teste de put com a expectativa de obter sucesso
 */
router.get('/update', async (req, res) => {
    try {
        const host = req.headers.host;
        let dataPut = {
            name: "Test Book",
            price: 15.00,
            publish_date: "February 08, 2019",
            author: "Caio",
            page_count: 100,
            illustrator: "Caio",
            genres: "Action"
        }
        Promise.all([requestRoute(`http://${host}/books/3`, 'PUT', dataPut, 200)])
        .then(([put1]) => {
            res.status(200).json({ put1 });
        })
        .catch((error) => {
            console.log(error);
            res.status(500).json({ message: 'Test fail.' });
        })
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Realiza o teste de delete com a expectativa de obter sucesso
 */
router.get('/remove', async (req, res) => {
    try {
        const host = req.headers.host;
        Promise.all([requestRoute(`http://${host}/books/4`, 'DELETE', true, 200)])
        .then(([delete1]) => {
            res.status(200).json({ delete1 });
        })
        .catch((error) => {
            console.log(error);
            res.status(500).json({ message: 'Test fail.' });
        })
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * 
 * --------- FAIL TESTS ---------
 * 
 */

/**
 * Realiza os testes de get com a expectativa de obter falha(404) em todos
 */
router.get('/search/fail', async (req, res) => {
    try {
        const host = req.headers.host;
        Promise.all([
            requestRoute(`http://${host}/books/book/19`, 'GET', true, 404),
            requestRoute(`http://${host}/books/search?name=The Rock`, 'GET', true, 404)
        ])
        .then(([get1, get2]) => {
            let testResult = [];
            testResult.push(get1);
            testResult.push(get2);
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

/**
 * Realiza o teste de post com a expectativa de obter falha(400)
 */
router.get('/create/fail', async (req, res) => {
    try {
        const host = req.headers.host;
        let dataPost = {
            name: "The Rock"
        }
        Promise.all([requestRoute(`http://${host}/books/`, 'POST', dataPost, 400)])
        .then(([post1]) => {
            res.status(200).json({ post1 });
        })
        .catch((error) => {
            console.log(error);
            res.status(500).json({ message: 'Test fail.' });
        })
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Realiza o teste de put com a expectativa de obter falha(404)
 */
router.get('/update/fail', async (req, res) => {
    try {
        const host = req.headers.host;
        let dataPut = {
            name: "Test Book",
            price: 15.00,
            publish_date: "February 08, 2019",
            author: "Caio",
            page_count: 100,
            illustrator: "Caio",
            genres: "Action"
        }
        Promise.all([requestRoute(`http://${host}/books/52`, 'PUT', dataPut, 404)])
        .then(([put1]) => {
            res.status(200).json({ put1 });
        })
        .catch((error) => {
            console.log(error);
            res.status(500).json({ message: 'Test fail.' });
        })
    } catch (error) {
        res.status(500).json({ error });
    }
});

/**
 * Realiza o teste de delete com a expectativa de obter falha(404)
 */
router.get('/remove/fail', async (req, res) => {
    try {
        const host = req.headers.host;
        Promise.all([requestRoute(`http://${host}/books/55`, 'DELETE', true, 404)])
        .then(([delete1]) => {
            res.status(200).json({ delete1 });
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