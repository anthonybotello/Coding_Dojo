const controller = require('./controller');
const Quote = require('./models');

module.exports = app => {
    app.get('/', controller.index);

    app.post('/quotes',controller.create);

    app.get('/quotes',controller.display);
}