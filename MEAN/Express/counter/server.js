const express = require('express');
const app = express();
const session = require('express-session');

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

//Routes
app.get('/',(req,res) => {
    if(!req.session.count){
        req.session.count = 1;
    }
    else{
        req.session.count++;
    }
    res.render('index',{count:req.session.count});
});
app.post('/',(req,res) => {
    req.session.count++;
    res.redirect('/');
});
app.post('/reset',(req,res) => {
    req.session.count = 0;
    res.redirect('/');
});


//Port Number
app.listen(5000);