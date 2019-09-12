const express = require('express');
const app = express();
const session = require('express-session');

//Settings
app.use(express.static(__dirname + "/static"));
app.set('view engine','ejs');
app.set('views',__dirname + "/views");
app.use(express.urlencoded({extended:true}));
app.use(session({
    secret: 'keyboardkitten',
    resave: false,
    saveUninitialized: true,
    cookie: {maxAge: 60000}
}));

//Routes
app.get('/',(req,res) => {
    console.log('Value of name is session: ' + req.session.name);
    res.render('index',{title:"my root route",name:req.session.name});
});
app.post('/users',(req,res) => {
    req.session.name = req.body.name;
    console.log(req.body);
    console.log("I'm redirecting back to index");
    res.redirect('/');
});
app.get('/users/:id', (req, res) => {
    console.log(req.params);
    console.log(req.params.id);
    const {id} = req.params;
    console.log(id);
    res.redirect('/');
});

//Port Number
app.listen(5000);