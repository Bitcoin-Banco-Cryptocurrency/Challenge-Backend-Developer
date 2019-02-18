import ISearchService from './interfaces/ISearchService';
import books from './../../books.json';
/**
 * @author Rodrigo Costa
 * @module Services
 */

module Services {
    /**
     * SortService.
     */
    export class SearchService implements ISearchService {

        searchByName(name: string): any[] {
            let ret = [];
            books.forEach(book => {
                if(book.name.toLowerCase().includes(name.toLowerCase())){
                    ret.push(book);
                }
            });
            return ret;
        }
        searchBySpecification(query: any, name: string): any[] {
            let filtered = books;
            if(name != undefined){
                filtered = this.searchByName(name);
            }
            if(query == undefined) return filtered;
            let ret = [];
            let specifications = query.split(',');
            filtered.forEach(book => {
                let bookspecs = book.specifications;
                let matched = 0;
                specifications.forEach(item => {
                    let specs = item.split(':');
                    let key = specs[0];
                    let value = specs[1];
                    let spec = bookspecs[key];
                    if(spec instanceof Array){
                        spec.forEach(aux => {
                            if (aux == value){
                                matched++;
                            }
                        });
                    }else if(spec == value){
                        matched++;
                    }
                });
                if(matched == specifications.length){
                    ret.push(book);
                }
            });
            return ret;
        }

       
    }
}
export default Services.SearchService;