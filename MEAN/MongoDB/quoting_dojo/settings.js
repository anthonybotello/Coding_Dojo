const express = require('express');
const session = require('express-session');
const flash = require('express-flash');

module.exports = app => {
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
}

