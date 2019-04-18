FROM node:11.14.0

RUN mkdir -p /home/node/app/node_modules && chown -R node:node /home/node/app

WORKDIR /home/node/app

COPY package*.json ./

RUN npm install

RUN npm install mocha -g --save-dev

COPY . .

EXPOSE 8080
