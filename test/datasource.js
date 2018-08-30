var assert = require('assert');
var datasource = require('../src/datasource');


describe('Datasource', function() {
	describe('Initialization', function() {
		it('initializes without error', function(done) {
			datasource.initDatasource()
				.then(done)
				.catch((e) => {
					done(e)
				})
		})

		it('searches by name and gives full details', function(done) {
			datasource.search({ Name: 'Journey to the Center of the Earth' })
				.then((res) => {
					assert.deepStrictEqual(res, [{
						id: 1,
						name: 'Journey to the Center of the Earth',
						price: 10,
						specifications: {
							'Originally published': 'November 25, 1864',
							Author: 'Jules Verne',
							'Page count': 183,
							Illustrator: 'Édouard Riou',
							Genres: [
								'Science Fiction',
								'Adventure fiction'
							]
						}
					}])
					done()
				})
				.catch((e) => {
					done(e)
				})
		})


		it('searches by Illustrator (array or single string)', function(done) {
			datasource.search({ Illustrator: 'Édouard Riou' })
				.then((res) => {
					assert.deepStrictEqual(res, [{
						id: 1,
						name: 'Journey to the Center of the Earth',
						price: 10,
						specifications: {
							'Originally published': 'November 25, 1864',
							Author: 'Jules Verne',
							'Page count': 183,
							Illustrator: 'Édouard Riou',
							Genres: [
								'Science Fiction',
								'Adventure fiction'
							]
						}
					}, {
						'id': 2,
						'name': '20,000 Leagues Under the Sea',
						'price': 10.10,
						'specifications': {
							'Originally published': 'June 20, 1870',
							'Author': 'Jules Verne',
							'Page count': 213,
							'Illustrator': [
								'Édouard Riou',
								'Alphonse-Marie-Adolphe de Neuville'
							],
							'Genres': 'Adventure fiction'
						}
					}])
					done()
				})
				.catch((e) => {
					done(e)
				})
		})

		it('searches by Illustrator (array or single string) and sort desc', function(done) {
			datasource.search({
					Illustrator: 'Édouard Riou',
					Sort: 'desc'
				})
				.then((res) => {
					assert.deepStrictEqual(res, [{
							id: 2,
							name: '20,000 Leagues Under the Sea',
							price: 10.10,
							specifications: {
								'Originally published': 'June 20, 1870',
								Author: 'Jules Verne',
								'Page count': 213,
								Illustrator: [
									'Édouard Riou',
									'Alphonse-Marie-Adolphe de Neuville'
								],
								Genres: 'Adventure fiction'
							}
						},
						{
							id: 1,
							name: 'Journey to the Center of the Earth',
							price: 10,
							specifications: {
								'Originally published': 'November 25, 1864',
								Author: 'Jules Verne',
								'Page count': 183,
								Illustrator: 'Édouard Riou',
								Genres: [
									'Science Fiction',
									'Adventure fiction'
								]
							}
						}
					])
					done()
				})
				.catch((e) => {
					done(e)
				})
		})
	});
});
