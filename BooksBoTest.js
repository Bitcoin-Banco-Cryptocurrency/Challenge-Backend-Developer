var BooksBo = require('./BooksBo');

module.exports = class BooksBoTest {
    constructor(){
    }

    findBooksTest(){
        var bo = new BooksBo();

        var specfications = {author:"Jules", genre:"Science"};
        
        if (bo.findBooks("desc", specfications)[0].id == 1){
            return "Test Ok";
        } else{
            return "Test Fail";
        }
    }
}