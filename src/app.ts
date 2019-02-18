import Config from "./config/Config";
import * as restify from 'restify';
import { Server } from 'restify';
import TypeDoc from './config/TypeDoc';
import { AuditLoggerOptions } from 'restify-plugins';
import { BadRequestError } from 'restify-errors';
import path = require('path');
import fs = require('fs');
import SearchController from './controller/SearchController';
import SortByPrice from './services/SortByPrice';
import SearchService from "./services/SearchService";


/**
 * Classe que gerencia toda inicialização da aplicação.
 * 
 * @author Rodrigo Costa
 */
export default class App {
    /**
     * @description Instância do app.
     */
    private static instance : App;

    /**
     * @description Instância do módulo restify
     */
    restify : Server;

    /**
     * @description Configuração de ENV.
     */
    config : Config;
    
    private constructor() {
        this.restify = restify.createServer({
            name:'Teste Técnico'
        });

        this.restify.use(restify.plugins.queryParser());        
        this.restify.use(restify.plugins.bodyParser());
        this.restify.use(restify.plugins.requestLogger());
    }
    
    /**
     * Carrega os repositórios, as controllers e as rotas de documentação da API.
     */
    setup() {
        //SwaggerUI.LoadConfig(this.restify);
        TypeDoc.LoadConfig(this.restify);
        let controller = new SearchController(new SearchService(), new SortByPrice());
        this.restify.get('/api/search',(req,res,next) => {controller.searchByName(req,res,next)});
        this.restify.get('/api/searchBySpecification',(req,res,next) => {controller.searchBySpecification(req,res,next)});
        
    }

    public static getInstance() : App {
        if(App.instance == undefined) {            
            App.instance = new App();
            App.instance.setup();
        }
        return App.instance;
    }

}