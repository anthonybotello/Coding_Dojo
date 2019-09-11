const express = require('express');
const app = express();
const session = require('express-session');
const flash = require('express-flash');
const mongoose = require('mongoose');
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
mongoose.connect('mongodb://localhost/mongoose_dashboard',{useNewUrlParser: true});

const GatorSchema = new mongoose.Schema({
    name:{type:String,required:[true,"Name is required."],minlength:[2,"Name must be at least 2 characters."]},
    age:{type:Number,required:[true,"Age is required."],min:[0,"Age must be a positive number."]},
    length:{type:Number, required:[true,"Length is required"],min:[0,"Length must be a positive number."]},
    weight:{type:Number, required:[true,"Weight is required"],min:[0,"Weight must be a positive number."]}
});
const Gator = mongoose.model('Gator',GatorSchema);

//Routes
app.get('/',(req,res) => {
    Gator.find()
        .then(gators => {
            console.log(gators);
            res.render('index',{gators:gators});
        })
        .catch(err => res.json(err));
});
app.get('/gators/new',(req,res) => {
    res.render('new');
});
app.get('/gators/:id',(req,res) => {
    Gator.findOne({_id:req.params.id})
        .then(gator => {
            res.render('info',{gator:gator});
        })
        .catch(err => res.json(err));
});
app.post('/gators',(req,res) => {
    Gator.create(req.body)
        .then(newGator => {
            const id = newGator._id;
            res.redirect(`/gators/${id}`);
        })
        .catch(err => {
            for (var key in err.errors){
                req.flash(key,err.errors[key].message);
            }
            res.redirect('/gators/new');
        });
});
app.get('/gators/edit/:id',(req,res) => {
    Gator.findOne({_id:req.params.id})
        .then(gator => {
            res.render('edit',{gator:gator});
        })
        .catch(err => res.json(err));
});
app.post('/gators/:id',(req,res) => {
    Gator.findOne({_id:req.params.id})
        .then(gator => {
            gator.name = req.body.name;
            gator.age = req.body.age;
            gator.length = req.body.length;
            gator.weight= req.body.weight;
            return gator.save();
        })
        .then(savedGator => {
            const id = savedGator._id;
            res.redirect(`/gators/${id}`);
        })
        .catch(err => {
            for (var key in err.errors){
                req.flash(key,err.errors[key].message);
            }
            res.redirect(`/gators/edit/${req.params.id}`);
        });
});
app.post('/gators/destroy/:id',(req,res) => {
    Gator.remove({_id:req.params.id})
        .then(() => {
            res.redirect('/');
        })
        .catch(err => res.json(err));
});

//Port Number
app.listen(5000);