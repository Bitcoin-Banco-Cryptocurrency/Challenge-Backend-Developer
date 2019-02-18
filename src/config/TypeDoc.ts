import * as restify from 'restify';
import { Server } from 'restify';

module Mentions {
    /**
     * Gerador de documentação para Typescript.
     */
    export class TypeDoc {
        static route = '/docs'
        static wildcard : string = '/.*'
        
        /**
         * Carrega a rota da documentação das classes.
         * @param api 
         * @param host 
         */
        static LoadConfig(api : any) {
            api.get(this.route+this.wildcard, restify.plugins.serveStatic({
                directory: __dirname+"/../../",
                default: '/index.html',
                // appendRequestPath: false
            }));

            api.get(this.route, (req,res,next) => {
                return res.redirect({ pathname: this.route+'/' }, next);   
            });
        }
    }
}

export default Mentions.TypeDoc;