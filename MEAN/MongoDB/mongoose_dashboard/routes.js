const controller = require('./controller');

module.exports = app => {
    app.get('/',controller.index);

    app.get('/gators/new',controller.new);

    app.get('/gators/:id',controller.info);

    app.post('/gators',controller.create);

    app.get('/gators/edit/:id',controller.edit);

    app.post('/gators/:id',controller.update);

    app.post('/gators/destroy/:id',controller.destroy);
}