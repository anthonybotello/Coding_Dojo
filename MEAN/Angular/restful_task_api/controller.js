const Task = require('./models');

module.exports = {
    tasks: (req,res) => {
        Task.find()
            .then(tasks => res.json(tasks))
            .catch(err => res.json(err));
    },
    taskInfo: (req,res) => {
        Task.findOne({_id:req.params.id})
            .then(task => res.json(task))
            .catch(err => res.json(err));
    },
    create: (req,res) => {
        Task.create(req.body)
            .then(() => res.redirect('/'))
            .catch(err => res.json(err));
    },
    update: (req,res) => {
        Task.findOne({_id:req.params.id})
            .then(task => {
                task.title = req.body.title;
                task.description = req.body.description;
                task.completed = req.body.completed;
                task.save();
                res.redirect('/');
            })
            .catch(err => res.json(err));
    },
    delete: (req,res) => {
        console.log("Well, here we are...",req.params.id);
        Task.remove({_id:req.params.id})
            .then(() => res.redirect('/'))
            .catch(err => res.json(err));
    }
}