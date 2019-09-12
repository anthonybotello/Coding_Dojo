const mongoose = require('mongoose');
const validate = require('mongoose-validator');

mongoose.connect('mongodb://localhost/mongoose_dashboard',{useNewUrlParser: true});

const GatorSchema = new mongoose.Schema({
    name:{type:String,required:[true,"Name is required."],minlength:[2,"Name must be at least 2 characters."]},
    age:{type:Number,required:[true,"Age is required."],min:[0,"Age must be a positive number."]},
    length:{type:Number, required:[true,"Length is required"],min:[0,"Length must be a positive number."]},
    weight:{type:Number, required:[true,"Weight is required"],min:[0,"Weight must be a positive number."]}
});
const Gator = mongoose.model('Gator',GatorSchema);

module.exports = Gator;