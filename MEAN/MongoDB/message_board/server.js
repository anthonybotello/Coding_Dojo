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
mongoose.set('useFindAndModify', false);

//Database & Schema
mongoose.connect('mongodb://localhost/message_board',{useNewUrlParser: true});

const CommentSchema = new mongoose.Schema({
    name:{type:String,required:[true,"You must enter a name."],minlength:[2,"Name must be at least 2 characters."]},
    content:{type:String,required:[true,"Comment cannot be blank."]}
},{timestamps:true});
const Comment = mongoose.model('Comment',CommentSchema);

const MessageSchema = new mongoose.Schema({
    name: {type:String,required:[true,"You must enter a name."],minlength: [2,"Name must be at least 2 characters."]},
    content: {type:String,required: [true,"Message cannot be blank."]},
    comments:[CommentSchema]
},{timestamps:true});
const Message = mongoose.model('Message',MessageSchema);

//Routes
app.get('/',(req,res) => {
    Message.find()
        .then(messages => {
            res.render('index',{msgs:messages});
        })
        .catch(err => res.json(err));
});
app.post('/messages',(req,res) => {
    Message.create(req.body)
        .then(() => {
            res.redirect('/');
        })
        .catch(err => {
            for (var key in err.errors){
                console.log(`message_${key}`,err.errors[key].message);
                req.flash(`message_${key}`,err.errors[key].message);
            }
            res.redirect('/');
        });
});
app.post('/comments',(req,res) => {
    Comment.create(req.body)
        .then(comment => {
            Message.findOneAndUpdate({_id:req.body.messageid},{$push:{comments:comment}})
                .then(message => {
                    res.redirect('/');
                })
                .catch(err => res.json(err));
        })
        .catch(err => {
            for (var key in err.errors){
                console.log(`comment_${key}`,err.errors[key].message);
                req.flash(`comment_${key}`,err.errors[key].message);
            }
            res.redirect('/');
        });
});

//Port Number
app.listen(5000);