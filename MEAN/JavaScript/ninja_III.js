class Ninja{
    constructor(name){
        this.name = name;
        this._health = 100;
        this.strength = 3;
        this.speed = 3;
    }
    get health(){
        return this._health;
    }
    set health(hp){
        this._health = hp;
    }

    sayName() {
        console.log(this.name);
    }
    showStats() {
        console.log(`Name: ${this.name}, Health: ${this.health}, Strength: ${this.strength}, Speed: ${this.speed}.`);
    }
    drinkSake() {
        this.health += 10;
        return this;
    }
}

class Sensei extends Ninja{
    constructor(name){
        super(name);
        this.health = 200;
        this.strength = 10;
        this.speed = 10;
        this.wisdom = 10;
    }
    speakWisdom(){
        super.drinkSake();
        console.log("The grass is always greener.");
    }
}

const murosaki = new Ninja("Murosaki");
murosaki.sayName();
murosaki.showStats();
murosaki.drinkSake().drinkSake().showStats();

const sensei = new Sensei("Saitama");
sensei.sayName();
sensei.showStats();
sensei.speakWisdom();
sensei.showStats();