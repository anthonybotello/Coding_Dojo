const Person = require('./models');

module.exports = {
    index: (req,res) => {
        Person.find()
            .then(people => res.json(people))
            .catch(err => res.json(err));
    },
    new: (req,res) => {
        console.log(req.params.name);
        const newP = new Person();
        newP.name = req.params.name;
        newP.save() 
            .then(() => res.redirect('/'))
            .catch(err => res.json(err))
    },
    remove: (req,res) => {
        Person.findOneAndRemove({name:req.params.name})
            .then(() => res.redirect('/'))
            .catch(err => res.json(err));
    },
    info: (req,res) => {
        Person.findOne({name:req.params.name})
            .then(person => res.json(person))
            .catch(err => res.json(err));
    }
}