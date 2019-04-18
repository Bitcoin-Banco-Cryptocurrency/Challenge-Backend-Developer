<p align="center">
  <a href="https://www.btc-banco.com">
      <img src="https://s3.amazonaws.com/assinaturas-de-emails/btc.png" alt="Grupo Bitcoin Banco"/>
  </a>
</p>

## Challenge for Developer

### Developer Level
- Mid-level
- Senior

A customer needs to search in our product catalog (available in this <a href="https://github.com/Bitcoin-Banco-Cryptocurrency/challenge/blob/master/books.json">JSON</a>) and he wants to find products that suit his style of reading.
Based on this you will need to develop:

- a simple API to search products in the .json available;
- it should be possible to search for products by their specifications (one or more);
- it must be possible to order the result by price (asc and desc);

The test should be done in Ruby, Go, Python or Node and we do like if you avoid frameworks. We expect at the end of the test, outside the API running, the following items:

- an explanation of what is needed to make your project work;
- an explanation of how to perform the tests

Remember that at the time of the evaluation we will look at:

- Code organization;
- Object-Oriented Principles;
- Maintenance;
- Version control knowledge;
- Unit Test;
- Design Pattern;

To send us your code, you must:

Make a fork of this repository, and send us a pull-request.


# Resposta do Teste


Projeto feito em Docker, o projeto conta com REST API:
- GET:/api/v1/books/ (retorna todos os books);
- GET:/api/v1/books/:id (retorna único livro com o id)
- POST:/api/v1/books/ (insere outro livro no json)
* obs: (tem que mandar no body o json com os dados)
```
{
    "name": "Journey to the Center of the Earth",
    "price": 3.5,
    "specifications": {
        "Originally published": "November 25, 1864",
        "Author": "Roberto Aoki",
        "Page count": 183,
        "Illustrator": "Édouard Riou",
        "Genres": [
            "Science Fiction",
            "Adventure fiction"
        ]
    }
}
```
- PUT:/api/v1/books/:id (atualização do book id)
* obs: (tem que mandar no body o json com os dados)
```
{
    "name": "Journey to the Center of the Earth",
    "price": 10.5,
    "specifications": {
        "Originally published": "November 25, 1864",
        "Author": "Roberto",
        "Page count": 183,
        "Illustrator": "Édouard Riou",
        "Genres": [
            "Science Fiction",
            "Adventure fiction"
        ]
    }
}
```
- DELETE:/api/v1/books/:id (deleta o book id)

# para subir o projeto:
```
$ docker-compose build
$ docker-compose up -d
```

# para acessar o Projeto:
http://localhost:8080/api/v1/books/

# para executar unitário exigido no teste
É preciso entrar no container para executar o mocha
```
$ docker exec -it challenge-backend-developer_web_1 bash
$ mocha
```
