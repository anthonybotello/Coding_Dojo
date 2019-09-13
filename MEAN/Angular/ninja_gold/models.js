const mongoose = require('mongoose');
const validate = require('mongoose-validator');

mongoose.connect('mongodb://localhost/ninja_gold',{useNewUrlParser: true});

const GameSchema = new mongoose.Schema({
    gold: {type:Number,required:true,default:0},
    activities:{type:Array,default:[]}
},{timestamps:true});
const Game = mongoose.model('Game',GameSchema);

module.exports = Game;