import App from './app';
import path = require('path');
import Config from './config/Config';


var app = App.getInstance();

app.restify.listen(Config.getInstance().port, '0.0.0.0', function() {
	console.log('server listening on port number', Config.getInstance().port);
});

export default app;