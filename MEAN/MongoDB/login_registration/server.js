const express = require('express');
const app = express();
const session = require('express-session');
const flash = require('express-flash');
const mongoose = require('mongoose');
const validate = require('mongoose-validator');
const bcrypt = require('bcrypt');

//Settings
app.use(express.static(__dirname + "/static"));
app.set('view engine','ejs');
app.set('views',__dirname + "/views");
app.use(express.urlencoded({extended:true}));
app.set('trust proxy',1);
app.use(session({
    cookie:{maxAge:60000},
    resave: false,
    saveUninitialized: true,
    secret: "no secrets"
}));
app.use(flash());
mongoose.set('useFindAndModify', false);

//Database & Schema
mongoose.connect('mongodb://localhost/login_registration',{useNewUrlParser: true});


const UserSchema = new mongoose.Schema({
    first_name:{type:String,required:[true,"First name is required."],minlength:[2,"First name must be at least two characters."]},

    last_name:{type:String,required:[true,"Last name is required."],minlength:[2,"last name must be at least two characters."]},

    email:{type:String, required:[true,"Email address is required."],validate: validate({validator:'isEmail',message:"Enter a valid email address."})},

    password:{type:String,required:[true,"Password is required."],minlength:[8,"Password must be at least 8 characters."]}
});
const User = mongoose.model('User',UserSchema);

//Routes
app.get('/',(req,res) => {
    res.render('index');
});
app.get('/success',(req,res) => {
    res.render('success');
});
app.post('/sessions',(req,res) => {
    User.findOne({email:req.body.email})
        .then(usr => {
            bcrypt.compare(req.body.password,usr.password)
                .then(match => {
                    if (match){
                        req.session.user_id = usr._id;
                        req.session.email = usr.email;
                        res.redirect('/success');
                    }
                    else{
                        req.flash('wrong_pw','Password is incorrect.');
                        res.redirect('/');
                    }
                });
        })
        .catch(err => {
            console.log(errors);
            for (var key in err.errors){
                req.flash(`login_${key}`,err.errors[key].message);
            }
        });
});
app.post('/users',(req,res) => {
    User.create(req.body)
        .then(user => {
            bcrypt.hash(user.password,10)
            .then(hashed => {
                user.password = hashed;
                user.save();
            })
            .catch(err => res.json(err));
            req.session.user_id = user._id;
            req.session.email = user.email;
            res.redirect('/success');
        })
        .catch(err => {
            for (var key in err.errors){
                req.flash(`reg_${key}`,err.errors[key].message);
                res.redirect('/');
            }
        });
});

//Port Number
app.listen(5000);