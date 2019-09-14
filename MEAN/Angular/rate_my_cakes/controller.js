const Cake = require('./models').Cake;
const Rating = require('./models').Rating;

module.exports = {
    cakes:{
        all: (req,res) => {
            Cake.find()
                .then(cakes => res.json(cakes))
                .catch(err => res.json(err.errors));
        },
        create: (req,res) => {
            Cake.create(req.body)
                .then(() => res.json({success:"Successfully added cake."}))
                .catch(err => res.json(err.errors));
        },
        info: (req,res) => {
            Cake.findOne({_id:req.params.id})
                .then(cake => res.json(cake))
                .catch(err => res.json(err.errors));
        }
    },
    ratings:{
        create: (req,res) => {
            Rating.create(req.body)
                .then(rating => {
                    Cake.findOneAndUpdate({_id:req.body.cakeid},{$push:{ratings:rating}})
                    .then(() => res.json({success:"Successfully added rating."}))
                    .catch(err => res.json(err.errors));
                })
                .catch(err => res.json(err.errors));
        }
    }
}