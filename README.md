<p align="center">
  <a href="https://www.btc-banco.com">
      <img src="https://s3.amazonaws.com/assinaturas-de-emails/btc.png" alt="Grupo Bitcoin Banco"/>
  </a>
</p>

## requisitos
node 8.11.3 ou superior
testado em windows

## para rodar o projeto
execute o comando npm install;
npm run build;
npm run start;


## endpoints publicos
os endpoints acessíveis são:

http://localhost:{{porta}}/api/searchBySpecification

http://localhost:{{porta}}/api/search

Parametros de get para as duas consultas:
name
sort
  valores possíveis: ASC ou DESC

parametros para consulta por specificação:
specification:
  formato: specificação:valor,specificação:valor
  nome da specificação, dois pontos, valor para busca.
  para enviar mais valores para busca elesdevem ser separados por virgula.

exemplos de requisição:

http://localhost:{{porta}}/api/searchBySpecification?sort=ASC&specification=Illustrator:Édouard%20Riou
http://localhost:3000/api/searchBySpecification?sort=DESC&specification=Illustrator:%C3%89douard%20Riou,Author:Jules%20Verne
http://localhost:{{porta}}/api/search?name=Harry&sort=ASC
