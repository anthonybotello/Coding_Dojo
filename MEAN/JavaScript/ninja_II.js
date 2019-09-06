function Ninja(name){
    var self = this;
    this.name = name;
    this.health = 100;
    var speed = 3;
    var strength = 3;

    this.sayName = function(){
        console.log(this.name);
    }
    this.showStats = function(){
        console.log("Name: " + this.name + ", Health: " + this.health + ", Speed: " + speed + ", Strength: " + strength);
    }

    this.punch = function(enemy){
        if (enemy instanceof Ninja)
        {
            enemy.health -= 5;
            console.log(this.name + " punched " + enemy.name + " for 5 damage.");
            return self;
        }
        else
        {
            console.log("Needs a ninja.");
        }
    }

    this.kick = function(enemy){
        if (enemy instanceof Ninja)
        {
            enemy.health -= strength*15;
            console.log(this.name + " kicked " + enemy.name + " for 45 damage.");
            return self;
        }
        else
        {
            console.log("Needs a ninja.");
        }
    }
}

var murosaki = new Ninja("Murosaki");
var ninjuh = new Ninja("Nin-juh");
murosaki.punch(ninjuh).kick(ninjuh).kick(ninjuh).punch(ninjuh);
ninjuh.showStats();
var notNinja;
murosaki.kick(notNinja);
murosaki.punch(notNinja);
