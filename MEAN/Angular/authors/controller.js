const Author = require('./models').Author;
const Quote = require('./models').Quote;

module.exports = {
    author: {
        getAll: (req,res) => {
        Author.find().sort({name:1})
            .then(authors => {res.json(authors)})
            .catch(errors => res.json(errors.errors));
        },
        getOne: (req,res) => {
            Author.findOne({_id:req.params.id})
                .then(author => res.json(author))
                .catch(errors => res.json(errors.errors));
        },
        new: (req,res) => {
            Author.create(req.body)
            .then(() => res.json({success:"Successfully added author."}))
            .catch(errors => res.json(errors.errors));
        },
        update: (req,res) => {
            Author.findOne({_id:req.params.id})
            .then(author => {
                author.name = req.body.name;
                return author.save();
            })
            .then(() => res.json({success:"Successfully updated author."}))
            .catch(errors => res.json(errors.errors));
        },
        delete: (req,res) => {
            Author.remove({_id:req.params.id})
                .then(() => res.json({success:"Successfully deleted author."}))
                .catch(errors => res.json(errors.errors));
        }
    },
    quote:{
        new: (req,res) => {
            Quote.create(req.body)
                .then(quote => {
                    Author.findOneAndUpdate({_id: req.params.id},{$push:{quotes:quote}})
                    .then(() => res.json({success:"Successfully added quote."}))
                    .catch(errors => res.json(errors.errors));
                })
                .catch(errors => res.json(errors.errors));
        }
    }
}