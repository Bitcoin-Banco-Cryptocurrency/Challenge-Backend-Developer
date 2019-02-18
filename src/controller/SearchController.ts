import { NotFoundError, BadRequestError, InternalServerError } from 'restify-errors';
import { Request, Response, Server } from 'restify';
import App from './../app';
import Config from "../config/Config";
import ISearchService from './../services/interfaces/ISearchService';
import SortService from '../services/SortService';


module Controller {
    /**
     * @author Rodrigo Costa
     */
    export class SearchController {
        searchService: ISearchService
        sortService: SortService;

        constructor(searchService:ISearchService, sortService:SortService){
            this.searchService = searchService;
            this.sortService = sortService;
        }
        /**
         * .
         * 
         * @param req 
         * @param res 
         * @param next 
         */
        async searchByName(req, res, next) {
            try {                          
                let response = await this.searchService.searchByName(req.query.name);
                response = await this.sortService.sort(response,req.query.sort == 'ASC');
                res.send(200,response);
                return next();
            } catch(err) {
                return next(err);
            } 
        }
        /**
         * .
         * 
         * @param req 
         * @param res 
         * @param next 
         */
        async searchBySpecification(req, res, next) {
            try {                          
                let response = await this.searchService.searchBySpecification(req.query.specification, req.query.name);
                response = await this.sortService.sort(response,req.query.sort == 'ASC');
                res.send(200,response);
                return next();
            } catch(err) {
                return next(err);
            } 
        }

    }
}

export default Controller.SearchController;