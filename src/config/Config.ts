import fs = require('fs');
import path = require('path');
import * as Logger from 'bunyan';

/**
 * @author Rodrigo Costa
 * @module Mentions
 */

module Mentions {
    /**
     * Configuração de toda a aplicação.
     */
    export class Config {
        /**
         * Instância singleton da classe.
         */
        private static _instance: Config

        /**
         *
         */
        private constructor() {
            //carrega as variáveis do arquivo .env dentro do process.env
            var env = require('node-env-file');
            env(__dirname + '/../../../.env');
        }


        //#endregion


        public get port(): string {
            return process.env.PORT;
        }

        public get httpUsername(): string {
            return process.env.HTTP_USERNAME;
        }
        public get locawebId(): number{
            return parseInt(process.env.LOCAWEB_ID);
        }

        public static getInstance(): Config {
            if (Config._instance == undefined) {
                Config._instance = new Config();
            }

            return Config._instance;
        }
    }
}

export default Mentions.Config;