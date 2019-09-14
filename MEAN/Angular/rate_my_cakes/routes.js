const cakes = require('./controller').cakes;
const ratings = require('./controller').ratings;

module.exports = app => {
    app.get('/cakes',cakes.all);
    app.post('/cakes',cakes.create);
    app.get('/cakes/:id',cakes.info);
    app.post('/ratings',ratings.create);
}