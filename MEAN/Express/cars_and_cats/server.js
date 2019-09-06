const express = require('express');
const app = express();

app.use(express.static(__dirname + "/static"));
app.set('view engine','ejs');
app.set('views',__dirname + '/views');

app.get('/cars',(req,res) => {
    res.render('cars');
});
app.get('/cats',(req,res) => {
    res.render('cats');
});
app.get('/cars/new',(req,res) => {
    res.render('newcar');
});

var cats = {
    lion:{name:'lion',food:'lioness',age:3,sleep:['in the jungle, the mighty jungle','pride rock']},
    tiger:{name:'tiger',food:'frosted flakes',age:5,sleep:['sometimes','never']},
    burr:{name:'burr',food:'a smackerel of honey',age:7,sleep:['a cave','mr. sanders house']}   
}

app.get(`/lion`,(req,res) => {
    res.render('details',{info:cats.lion});
});
app.get(`/tiger`,(req,res) => {
    res.render('details',{info:cats.tiger});
});
app.get(`/burr`,(req,res) => {
    res.render('details',{info:cats.burr});
});


app.listen(5000,() => console.log('listening on port 5000'));