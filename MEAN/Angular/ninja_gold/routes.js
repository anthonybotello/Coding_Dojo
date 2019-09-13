const controller = require('./controller');

module.exports = app => {
    app.post('/new',controller.new);
    app.put('/update',controller.update);
}