/**
 * @author Rodrigo Costa
 * @module Services
 */

/**
 * SortService.
 */
export default interface ISearchService {
    searchByName(name:string):any[];
    searchBySpecification(query:any, name:string):any[];
}
