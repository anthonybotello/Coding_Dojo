"use strict";
class Bike {
    constructor(_price, _speed) {
        this.miles = 0;
        this.price = _price;
        this.max_speed = _speed;
    }
    displayInfo() {
        console.log(`Price: ${this.price}, Max speed: ${this.max_speed}, Miles: ${this.miles}`);
        return this;
    }
    ride() {
        console.log("Riding...");
        this.miles += 10;
        return this;
    }
    reverse() {
        if (this.miles - 5 >= 0) {
            console.log("Reversing...");
            this.miles -= 5;
        }
        return this;
    }
}
const bike1 = new Bike(200, "20mph");
const bike2 = new Bike(500, "25mph");
const bike3 = new Bike(1000, "35mph");
bike1.ride().ride().ride().reverse().displayInfo();
bike2.ride().ride().reverse().reverse().displayInfo();
bike3.reverse().reverse().reverse().displayInfo();