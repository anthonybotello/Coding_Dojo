const mongoose = require('mongoose');
const validate = require('mongoose-validator');

mongoose.connect('mongodb://localhost/authors',{useNewUrlParser: true});

const QuoteSchema = new mongoose.Schema({
    quote:{type:String,required:[true,"Quote cannot be blank."],minlength:[3,"Quote must be at least 3 characters."]}
});
const Quote = mongoose.model('Quote',QuoteSchema);

const AuthorSchema = new mongoose.Schema({
    name:{type:String,required:[true,"Author name is required."],minlength:[3,"Arthur name must be at least 3 characters."]},
    quotes:[QuoteSchema]
},{timestamps:true});
const Author = mongoose.model('Author',AuthorSchema);

module.exports = {Quote,Author};