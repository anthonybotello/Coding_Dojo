const express = require('express');
const app = express();

//Settings
app.use(express.static(__dirname + "/static"));
app.set('view engine','ejs');
app.set('views',__dirname + "/views");
app.use(express.urlencoded({extended:true}));

//Routes
app.get('/',(req,res) => {
    res.render('index');
});
app.post('/result',(req,res) => {
    res.render('result',{data:req.body});
});

//Port Number
app.listen(5000);