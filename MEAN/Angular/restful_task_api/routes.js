const controller = require('./controller');

module.exports = app => {
    app.get('/tasks',controller.tasks);
    app.get('/tasks/:id',controller.taskInfo);
    app.post('/tasks/',controller.create);
    app.put('/tasks/:id',controller.update);
    app.delete('/task/:id',controller.delete);
}