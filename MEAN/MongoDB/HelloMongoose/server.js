const express = require('express');
const app = express();
const mongoose = require('mongoose');
const session = require('express-session');
const flash = require('express-flash');
const validate = require('mongoose-validator');

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
mongoose.connect('mongodb://localhost/my_first_db',{useNewUrlParser: true});
const UserSchema = new mongoose.Schema({
    first_name:  { type: String, required: true, minlength: 6},
    last_name: { type: String, required: true, maxlength: 20 },
    age: { type: Number, min: 1, max: 150 },
    email: { type: String, required: true }
}, {timestamps: true });


const User = mongoose.model('User',UserSchema);

//Routes
app.get('/',(req,res) => {
    User.find()
        .then(data => res.render('index',{users:data}))
        .catch(err => res.json(err));
});
app.post('/users',(req,res) => {
    const user = new User(req.body);
    user.save()
        .then(() => res.redirect('/'))
        .catch(err => {
            console.log("ERROR!", err);
            for (var key in err.errors) {
                req.flash('errors',err.errors[key].message);
            }
            res.redirect('/');
        });
});

//Port Number
app.listen(5000);
