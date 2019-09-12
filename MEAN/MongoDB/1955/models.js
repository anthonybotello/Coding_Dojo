const mongoose = require('mongoose');
const validate = require('mongoose-validator');

mongoose.connect('mongodb://localhost/1955',{useNewUrlParser: true});

const PersonSchema = new mongoose.Schema({
    name:{type:String},
},{timestamps:true});
const Person = mongoose.model('Person',PersonSchema);

module.exports = Person;