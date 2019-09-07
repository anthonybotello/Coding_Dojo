const express = require('express');
const app = express();
const axios = require('axios');

//Settings
app.use(express.static(__dirname + "/static"));
app.set('view engine','ejs');
app.set('views',__dirname + "/views");
app.use(express.urlencoded({extended:true}));

//Routes
app.get('/',(req,res) => {
    res.render('index');
});
app.get('/people/:pg',(req,res) => {
    axios.get(`http://swapi.co/api/people?page=${req.params.pg}`)
    .then(data => {
        res.json(data.data);
    })
    .catch(error => {
        res.json(error);
    });
});
app.get('/planets/:pg',(req,res) => {
    axios.get(`http://swapi.co/api/planets/?page=${req.params.pg}`)
    .then(data => {
        res.json(data.data);
    })
    .catch(error => {
        res.json(error);
    });
});

//Port Number
app.listen(5000);