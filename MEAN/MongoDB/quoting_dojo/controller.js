const moment = require('moment');
const Quote = require('./models');

module.exports = {
    index: (req,res) => {
        res.render('index');
    },
    create: (req,res) => {
        Quote.create(req.body)
            .then(() => res.redirect('/quotes'))
            .catch(err => {
                for (var key in err.errors){
                    req.flash('errors',err.errors[key].message);
                }
                res.redirect('/');
            });
    },
    display: (req,res) => {
        Quote.find()
            .then(quotes => {
                res.render('quotes',{quotes:quotes,moment:moment});
            })
            .catch(err => res.json(err));
    }
}