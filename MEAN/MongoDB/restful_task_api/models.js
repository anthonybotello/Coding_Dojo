const mongoose = require('mongoose');
const validate = require('mongoose-validator');

mongoose.connect('mongodb://localhost/restful_task_api',{useNewUrlParser: true});

const TaskSchema = new mongoose.Schema({
    title:{type:String},
    description:{type:String,default:""},
    completed:{type:Boolean,default:false}
},{timestamps:true});
const Task = mongoose.model('Task',TaskSchema);

module.exports = Task;