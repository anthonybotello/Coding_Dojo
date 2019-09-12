const Gator = require('./models');

module.exports = {
    index:(req,res) => {
        Gator.find()
            .then(gators => {
                console.log(gators);
                res.render('index',{gators:gators});
            })
            .catch(err => res.json(err));
    },
    new:(req,res) => {
        res.render('new');
    },
    info:(req,res) => {
        Gator.findOne({_id:req.params.id})
            .then(gator => {
                res.render('info',{gator:gator});
            })
            .catch(err => res.json(err));
    },
    create:(req,res) => {
        Gator.create(req.body)
            .then(newGator => {
                const id = newGator._id;
                res.redirect(`/gators/${id}`);
            })
            .catch(err => {
                for (var key in err.errors){
                    req.flash(key,err.errors[key].message);
                }
                res.redirect('/gators/new');
            });
    },
    edit:(req,res) => {
        Gator.findOne({_id:req.params.id})
            .then(gator => {
                res.render('edit',{gator:gator});
            })
            .catch(err => res.json(err));
    },
    update:(req,res) => {
        Gator.findOne({_id:req.params.id})
            .then(gator => {
                gator.name = req.body.name;
                gator.age = req.body.age;
                gator.length = req.body.length;
                gator.weight= req.body.weight;
                return gator.save();
            })
            .then(savedGator => {
                const id = savedGator._id;
                res.redirect(`/gators/${id}`);
            })
            .catch(err => {
                for (var key in err.errors){
                    req.flash(key,err.errors[key].message);
                }
                res.redirect(`/gators/edit/${req.params.id}`);
            });
    },
    destroy:(req,res) => {
        Gator.remove({_id:req.params.id})
            .then(() => {
                res.redirect('/');
            })
            .catch(err => res.json(err));
    }
}