const express = require('express');
const app = express();
const session = require('express-session');
const flash = require('express-flash');
const mongoose = require('mongoose');
const validate = require('mongoose-validator');
const moment = require('moment')

//Settings
app.use(express.static(__dirname + "/static"));
app.set('view engine','ejs');
app.set('views',__dirname + "/views");
app.use(express.urlencoded({extended:true}));
app.use(session({
    cookie:{maxAge:60000},
    resave: false,
    saveUninitialized: true,
    secret: "no secrets"
}));
app.use(flash());

//Database & Schema
mongoose.connect('mongodb://localhost/quoting_dojo',{useNewUrlParser: true});

const QuoteSchema = new mongoose.Schema({
    user: {type: String,required:[true,"Your name cannot be blank."]},
    quote: {type:String, required: [true,"Your quote cannot be blank."]}
},{timestamps:true});

const Quote = mongoose.model('Quote',QuoteSchema);

//Routes
app.get('/',(req,res) => {
    res.render('index');
});
app.post('/quotes',(req,res) => {
    Quote.create(req.body)
        .then(() => res.redirect('/quotes'))
        .catch(err => {
            for (var key in err.errors){
                req.flash('errors',err.errors[key].message);
            }
            res.redirect('/');
        })
});
app.get('/quotes',(req,res) => {
    Quote.find()
        .then(quotes => {
            res.render('quotes',{quotes:quotes,moment:moment});
        })
        .catch(err => res.json(err));
});

//Port Number
app.listen(5000);