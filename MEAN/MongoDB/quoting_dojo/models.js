const mongoose = require('mongoose');
const validate = require('mongoose-validator');

mongoose.connect('mongodb://localhost/quoting_dojo',{useNewUrlParser: true});

const QuoteSchema = new mongoose.Schema({
    user: {type: String,required:[true,"Your name cannot be blank."]},
    quote: {type:String, required: [true,"Your quote cannot be blank."]}
},{timestamps:true});
const Quote = mongoose.model('Quote', QuoteSchema);

module.exports = Quote;