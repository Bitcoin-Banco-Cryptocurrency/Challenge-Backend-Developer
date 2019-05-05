var express = require("express");
var app = express();

var jsonBooks = [
    {
        "id": 1,
        "name": "Journey to the Center of the Earth",
        "price": 10.00,
        "specifications": {
            "Originally published":"November 25, 1864",
            "Author":"Jules Verne",
            "Page count": 183,
            "Illustrator": "Édouard Riou",
            "Genres": [
              "Science Fiction", 
              "Adventure fiction"
            ]
        }
    },
    {
        "id": 2,
        "name": "20,000 Leagues Under the Sea",
        "price": 10.10,
        "specifications": {
            "Originally published":"June 20, 1870",
            "Author":"Jules Verne",
            "Page count": 213,
            "Illustrator": [
               "Édouard Riou", 
               "Alphonse-Marie-Adolphe de Neuville"
            ],
            "Genres": "Adventure fiction"
        }
    },
    {
        "id": 3,
        "name": "Harry Potter and the Goblet of Fire",
        "price": 7.31,
        "specifications": {
            "Originally published":"July 8, 2000",
            "Author":"J. K. Rowling",
            "Page count": 636,
            "Illustrator": [
               "Cliff Wright", 
               "Mary GrandPré"
            ],
             "Genres": [
              "Fantasy Fiction",
              "Drama",
              "Young adult fiction", 
              "Mystery", 
              "Thriller", 
              "Bildungsroman"
            ]
        }
    },
    {
        "id": 4,
        "name": "Fantastic Beasts and Where to Find Them: The Original Screenplay",
        "price": 11.15,
        "specifications": {
            "Originally published":"November 18, 2016",
            "Author":"J. K. Rowling",
            "Page count": 457,
            "Illustrator": "Cliff Wright",
             "Genres": [
              "Fantasy Fiction",
              "Contemporary fantasy",
              "Screenplay"
            ]
        }
    },
    {
        "id": 5,
        "name": "The Lord of the Rings",
        "price": 6.15,
        "specifications": {
            "Originally published":"July 29, 1954",
            "Author":"J. R. R. Tolkien",
            "Page count": 715,
            "Illustrator": [
              "Alan Lee",
              "Ted Nashmith",
              "J. R. R. Tolkien"
             ],
             "Genres": [
              "Fantasy Fiction",
              "Adventure Fiction"
            ]
        }
    }
];

app.get('/search', function (req, res, next) {
	var searchResult = [];
	
	var published = req.query.published;	
	var author = req.query.author;
	var pageCount = req.query.pageCount;
	var illustrator = req.query.illustrator;
	var genre = req.query.genre;	
	var order = req.query.order;
	
	for (var i = 0; i < jsonBooks.length; i++)
	{
		var item = jsonBooks[i];
		if (published != undefined)
		{			
			if (item.specifications["Originally published"] == published)
			{
				searchResult.push(item);
			}
		}
		
		if (author != undefined)
		{			
			if (item.specifications["Author"] == author)
			{
				searchResult.push(item);
			}
		}
		
		if (pageCount != undefined)
		{			
			if (item.specifications["Page count"] == eval(pageCount))
			{
				searchResult.push(item);
			}
		}
		
		if (illustrator != undefined)
		{	
			var illustrators = item.specifications["Illustrator"];	
			if (typeof illustrators === 'string') 
			{
				if (item.specifications["Illustrator"] == illustrator)
				{
					searchResult.push(item);
				}		
			}
			else
			{
				for (var illu = 0; illu < illustrators.length; illu++)					
				{
					var illuValue = illustrators[illu];
					if (illuValue == illustrator)
					{
						searchResult.push(item);
					}					
				}				
			}				
		}
		
		if (genre != undefined)
		{			
			var genres = item.specifications["Genres"];
			if (typeof genres === 'string') 
			{
				if (genres == genre)
				{
					searchResult.push(item);
				}					
			}			
			else
			{
				for (var g = 0; g < genres.length; g++)					
				{
					var gValue = genres[g];
					if (gValue == genre)
					{
						searchResult.push(item);
					}					
				}				
			}		
		}
	}	
	
	if (order != undefined)
	{
		if (order == "ASC" || order == "asc")
		{
			searchResult = searchResult.sort(function(a, b){return a.price - b.price});
		}
		else if (order == "DESC" || order == "desc")
		{
			searchResult = searchResult.sort(function(a, b){return b.price - a.price});
		}		
	}
	
	res.json(searchResult);
});

app.get("/test", (req, res, next) => {
	res.json(jsonBooks);
});

app.listen(3000, () => {
	console.log("Server running on port 3000");
});