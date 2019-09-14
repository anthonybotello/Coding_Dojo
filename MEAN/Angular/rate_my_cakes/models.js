const mongoose = require('mongoose');
const validate = require('mongoose-validator');

mongoose.connect('mongodb://localhost/rate_my_cakes',{useNewUrlParser: true});

const RatingSchema = new mongoose.Schema({
    rating:{type: Number, required:[true,"You must provide a rating."],min: 1, max: 5},
    comment:{type:String,required:[true,"You must provide a comment."]}
},{timestamps:true});
const Rating = mongoose.model('Rating',RatingSchema);

const CakeSchema = new mongoose.Schema({
    baker:{type:String,required:[true,"Baker's name is required."],minlength:[2,"Baker's name must be at least two characters."]},
    image:{type:String,required:[true,"Cake url is required."],validate:validate({validator:'isURL',message:'Enter a valid url.'})},
    ratings:[RatingSchema]
},{timestamps:true});
const Cake = mongoose.model('Cake',CakeSchema);

module.exports = {Cake,Rating};