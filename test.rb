require './src/datasource.rb'

require 'test/unit'
require 'patron'

class TestDatasource < Test::Unit::TestCase
  def test_initialize_datasource
    datasource = Datasource.init
    assert_not_nil datasource
    assert datasource.length == 5
  end

  def test_search
    result = Datasource.search({'Name' => 'Harry Potter'})
    assert_equal result, [ {'id' => 3,
                            'name' => 'Harry Potter and the Goblet of Fire',
                            'price' => 7.31,
                            'specifications' => {
                                'Originally published' => 'July 8, 2000',
                                'Author' => 'J. K. Rowling',
                                'Page count' => 636,
                                'Illustrator' => ['Cliff Wright', 'Mary GrandPré'],
                                'Genres' => ['Fantasy Fiction', 'Drama', 'Young adult fiction',
                                          'Mystery', 'Thriller', 'Bildungsroman']
                                        }
                          }]

    result = Datasource.search({'Illustrator'  =>  'Édouard Riou', 'Sort'  =>  'desc'})
    assert_equal result, [ {'id' => 2,
                              'name' => '20,000 Leagues Under the Sea',
                              'price' => 10.1,
                              'specifications' => {
                                  'Originally published' => 'June 20, 1870',
                                  'Author' => 'Jules Verne',
                                  'Page count' => 213,
                                  'Illustrator' => ['Édouard Riou', 'Alphonse-Marie-Adolphe de Neuville'],
                                  'Genres' => 'Adventure fiction'}
                                  },
                              {'id' => 1,
                               'name' => 'Journey to the Center of the Earth',
                               'price' => 10.0,
                               'specifications' => {
                                  'Originally published' => 'November 25, 1864',
                                  'Author' => 'Jules Verne',
                                  'Page count' => 183,
                                  'Illustrator' => 'Édouard Riou',
                                  'Genres' => ['Science Fiction', 'Adventure fiction']
                                }
                            }]
  end
end

class TestServer < Test::Unit::TestCase
  def setup
    @sess = Patron::Session.new
    @sess.base_url = 'http://127.0.0.1:8080'
  end

  def test_connection
    response = @sess.get('search?Author=J. K. Rowling&Sort=asc')
    assert_equal response.body.force_encoding('UTF-8'), [ {"id":3,
                                                          "name":"Harry Potter and the Goblet of Fire",
                                                          "price":7.31,
                                                          "specifications":{
                                                            "Originally published":"July 8, 2000",
                                                            "Author":"J. K. Rowling",
                                                            "Page count":636,
                                                            "Illustrator":["Cliff Wright","Mary GrandPré"],
                                                            "Genres":["Fantasy Fiction","Drama","Young adult fiction",
                                                              "Mystery","Thriller","Bildungsroman"]}
                                                              },
                                                          {"id":4,
                                                           "name":"Fantastic Beasts and Where to Find Them: The Original Screenplay",
                                                           "price":11.15,
                                                           "specifications":{
                                                             "Originally published":"November 18, 2016",
                                                             "Author":"J. K. Rowling",
                                                             "Page count":457,
                                                             "Illustrator":"Cliff Wright",
                                                             "Genres":["Fantasy Fiction","Contemporary fantasy","Screenplay"]
                                                           }
                                                        }].to_json

    response = @sess.get('nothing')
    assert response.status, '404'

    response = @sess.get('search?Genres=Fantasy Fiction')
    assert_equal response.body.force_encoding('UTF-8'), [ {"id":3,
                                                           "name":"Harry Potter and the Goblet of Fire",
                                                           "price":7.31,
                                                           "specifications":{
                                                             "Originally published":"July 8, 2000",
                                                             "Author":"J. K. Rowling",
                                                             "Page count":636,
                                                             "Illustrator":["Cliff Wright","Mary GrandPré"],
                                                             "Genres":["Fantasy Fiction","Drama","Young adult fiction",
                                                               "Mystery","Thriller","Bildungsroman"]}
                                                              },
                                                            {"id":4,
                                                             "name":"Fantastic Beasts and Where to Find Them: The Original Screenplay",
                                                             "price":11.15,
                                                             "specifications":{
                                                               "Originally published":"November 18, 2016",
                                                               "Author":"J. K. Rowling",
                                                               "Page count":457,
                                                               "Illustrator":"Cliff Wright",
                                                               "Genres":["Fantasy Fiction","Contemporary fantasy","Screenplay"]}
                                                               },
                                                            {"id":5,
                                                             "name":"The Lord of the Rings",
                                                             "price":6.15,
                                                             "specifications":{
                                                               "Originally published":"July 29, 1954",
                                                               "Author":"J. R. R. Tolkien",
                                                               "Page count":715,
                                                               "Illustrator":["Alan Lee","Ted Nashmith","J. R. R. Tolkien"],
                                                               "Genres":["Fantasy Fiction","Adventure Fiction"]}
                                                            }].to_json
  end

end
