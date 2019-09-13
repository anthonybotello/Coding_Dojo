const Game = require('./models');

module.exports = {
    new: (req,res) => {
        Game.create(req.body)
            .then(game => res.json(game))
            .catch(err => res.json(err));
    },
    update: (req,res) => {
        console.log(req.body);
        Game.findOne({_id:req.body.id})
            .then(oldGame => {
                oldGame.gold += req.body.gold;
                oldGame.activities.push(req.body.activity);
                return oldGame.save();
            })
            .then(newGame => res.json(newGame))
            .catch(err => res.json(err));
    }
}