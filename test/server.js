var assert = require('assert');
var request = require('request-promise-native');

var port = process.env.PORT || 8080

describe('Server', function() {
	describe('Search (Requires server to be running)', function() {

		var searchUrl = `http://localhost:${port}/search?`;

		it('searches all books', function(done) {
			request(searchUrl).then((response => {
				assert(JSON.parse(response).length === 5)
				done()
			})).catch(done)
		})


		it('searches a specific book', function(done) {
			request(searchUrl + 'Name=Journey to the Center of the Earth').then((response => {
				assert(JSON.parse(response).length === 1)
				done()
			})).catch(done)
		})
	})

});
