var should = require("should");
var request = require("request");
var chai = require("chai");
var expect = chai.expect;
var urlBase = "http://localhost:8080/api/v1";

describe("Teste API localhost",function(){
  it("Deve retornar 5 livros",function(done){
    request.get(
      {
        url : urlBase + "/books"
      },
      function(error, response, body){
        var _body = {};
        try{
          _body = JSON.parse(body);
        }
        catch(e){
          _body = {};
        }
        expect(response.statusCode).to.equal(200);

        if( _body.should.have ){
          expect(_body).to.have.lengthOf.at.most(5);
        }

        done();
      }
    );
  });

  it("Deve ordernar asc",function(done){
    request.get(
      {
        url : urlBase + "/books?order=asc"
      },
      function(error, response, body){
        var _body = {};
        try{
          _body = JSON.parse(body);
        }
        catch(e){
          _body = {};
        }

        expect(response.statusCode).to.equal(200);

        if( _body.should.have ){
          expect(_body).to.have.lengthOf.at.least(5);

          if(_body[0].should.have.property('price')){
            expect(_body[0]["price"]).to.be.below(_body[_body.length-1]["price"]);
          }
        }

        done();
      }
    );
  });

  it("Deve ordernar desc",function(done){
    request.get(
      {
        url : urlBase + "/books?order=desc"
      },
      function(error, response, body){
        var _body = {};
        try{
          _body = JSON.parse(body);
        }
        catch(e){
          _body = {};
        }

        expect(response.statusCode).to.equal(200);

        if( _body.should.have ){
          expect(_body).to.have.lengthOf.at.least(5);

          if(_body[0].should.have.property('price')){
            expect(_body[0]["price"]).to.be.above(_body[_body.length-1]["price"]);
          }
        }

        done();
      }
    );
  });

  it("Deve ter livros publicados na data 25/11/1864",function(done){
    request.get(
      {
        url : urlBase + "/books?published=25/11/1864"
      },
      function(error, response, body){
        var _body = {};
        try{
          _body = JSON.parse(body);
        }
        catch(e){
          _body = {};
        }

        expect(response.statusCode).to.equal(200);

        if( _body.should.have ){
          expect(_body).to.have.lengthOf.at.least(1);

          if(_body[0]["specifications"].should.have.property('Originally published')){
            expect(_body[0]["specifications"]["Originally published"]).to.equal('November 25, 1864');
          }
        }

        done();
      }
    );
  });

  it("Deve ter o author Jules Verne ",function(done){
    request.get(
      {
        url : urlBase + "/books?author=Jules Verne"
      },
      function(error, response, body){
        var _body = {};
        try{
          _body = JSON.parse(body);
        }
        catch(e){
          _body = {};
        }

        expect(response.statusCode).to.equal(200);

        if( _body.should.have ){
          expect(_body).to.have.lengthOf.at.least(1);

          if(_body[0]["specifications"].should.have.property('Author')){
            expect(_body[0]["specifications"]["Author"]).to.equal('Jules Verne');
          }
        }

        done();
      }
    );
  });

  it("Deve ter livros com a pagina 183",function(done){
    request.get(
      {
        url : urlBase + "/books?page=183"
      },
      function(error, response, body){
        var _body = {};
        try{
          _body = JSON.parse(body);
        }
        catch(e){
          _body = {};
        }

        expect(response.statusCode).to.equal(200);

        if( _body.should.have ){
          expect(_body).to.have.lengthOf.at.least(1);

          if(_body[0]["specifications"].should.have.property('Page count')){
            expect(_body[0]["specifications"]["Page count"]).to.equal(183);
          }
        }

        done();
      }
    );
  });

  it("Deve ter o author Jules Verne em ordem desc",function(done){
    request.get(
      {
        url : urlBase + "/books?author=Jules Verne&order=desc"
      },
      function(error, response, body){
        var _body = {};
        try{
          _body = JSON.parse(body);
        }
        catch(e){
          _body = {};
        }

        expect(response.statusCode).to.equal(200);

        if( _body.should.have ){
          expect(_body).to.have.lengthOf.at.least(2);

          if(_body[0].should.have.property('price')){
            expect(_body[0]["price"]).to.be.above(_body[_body.length-1]["price"]);
          }
        }

        done();
      }
    );
  });
});
