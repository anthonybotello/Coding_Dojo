const controller = require('./controller');

module.exports = app => {
    app.get('/authors',controller.author.getAll);
    app.get('/authors/:id',controller.author.getOne);
    app.post('/authors',controller.author.new);
    app.put('/authors/:id',controller.author.update);
    app.delete('/authors/:id',controller.author.delete);
    app.post('/authors/:id/quotes',controller.quote.new);
    app.use("*", (req,res,next) => {
      res.sendFile(__dirname + "/authors/dist/authors/index.html");
    });
}