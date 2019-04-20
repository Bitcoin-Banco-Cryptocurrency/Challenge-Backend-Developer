var assert = require('assert');
var request = require('request-promise-native');

var port = process.env.PORT || 3000

describe('API', function() {
	describe('Search book', function() {

		let booksUrl = `http://localhost:${port}/books?`;

		it('searches all books', function(done) {
			request(booksUrl).then((response => {
				assert(JSON.parse(response).length === 5)
				done()
			})).catch(done)
		})


		it('searches a book by id', function(done) {
			request(booksUrl + 'id=1').then((response => {
				assert(JSON.parse(response).length === 1)
				done()
			})).catch(done)
        })
        
        it('searches a book by especification', function(done) {
			request(booksUrl + 'Genres=Fantasy').then((response => {
				assert(JSON.parse(response).length >= 1)
				done()
			})).catch(done)
        })

        it('searches a book by especification and sort', function(done) {
			request(booksUrl + 'Genres=Fantasy&sort=desc').then((response => {
				assert(JSON.parse(response).length >= 1)
				done()
			})).catch(done)
        })
        

	})

});
