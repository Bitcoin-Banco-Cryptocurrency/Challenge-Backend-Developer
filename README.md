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

## Observações do Autor

### Detalhes da Implementação

- Para a implementação deste desafio utilizei as seguintes ferramentas:

- 1 Para a implementação deste desafio utilizei as seguintes ferramentas:
	- 1.1. Visual Studio Code
	- 1.2. Docker com SQL Server instalado - Kitematic UI
	- 1.3. Azure Data Studio - Gerenciamento do SQL
	- 1.4. GitHub
	- 1.5. PostMan e Swagger para os testes na API

- 2 Tecnologias:
	- 2.1. .Net Core 2.2
	- 2.2. Padrões:
		- 2.2.1 Repository Pattern
		- 2.2.2 Fluent API (Objects Model > Mapping)
		- 2.2.3 Cash e Compressão
		- 2.3. Documentação com Swagger

- 3 Resumo da implementação
	- 3.1 Mecanismo de leitura do arquivo book.json e armazenamento no banco
	- 3.2 Controllers para Products e Specifications
