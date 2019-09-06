// // var foo = "bar";
// // function magic(){
// //     foo = "hello world";
// //     console.log(foo);
// //     var foo;
// // }
// // magic();
// // console.log(foo);

// // //THE CODES ABOVE AND BELOW ARE EQUIVALENT DUE TO HOISTING

// // var foo;
// // function magic()
// // {
// //     var foo;
// //     foo = "hello world";
// //     console.log(foo);
// // }
// // foo = "bar";
// // magic();
// // console.log(foo);

// // Callbacks
// // console.log("NOW: ");
// // console.log("Declaring and assigning variable 'ninja'.");
// // var ninja = 'Libby';
// // setTimeout( function myCallbackFunction(){
// //   console.log("LATER: ")
// //   console.log(ninja, "LATER"); }, 2000
// // );
// // console.log("Printing ninja value.");
// // console.log(ninja, "NOW");

// console.log("***************************************")
// // function doSomething(possibleCallback) {
// //     if (typeof(possibleCallback) === 'function'){
// //       console.log(`${possibleCallback} is a callback!`);
// //       possibleCallback(); //we can invoke the callback!
// //     }
// //     else {
// //       console.log('possibleCallback: ', possibleCallback, ' is not a callback function.');
// //     }
// //   }
// //   doSomething(function myCallback(){ console.log('yes, I am a callback!') });
// //   doSomething('string');

// function makePasta(pasta, makeSauce) {
//     console.log("Boiling water");
//     console.log("Putting " + pasta + " pasta in the water");
//     // create a variable for sauce!
//     var sauce = makeSauce();          // invoke makeSauce, our callback
//     console.log("Mixing sauce");
//     console.log("Pasta is done!");
//     return pasta + " Pasta with " + sauce + " sauce! Voila!";
//   }
//   function makePesto() {
//     console.log("Making Pesto");
//     return "pesto";
//   }
//   function makeAlfredo() {
//     console.log("Making Alfredo");
//     return "alfredo";
//   }
//   // we pass the whole makePesto recipe to makePasta!
//   console.log(makePasta("Penne", makePesto));
//   // notice lack of parentheses after makePesto.
//   // Remember: we want to pass the function, not execute it and pass a return value.
//   console.log(makePasta("Farfalle", makeAlfredo));
  
// function Person(name,age)
// {
//   var self = this;
//   var privateVariable = "this variable is private";
//   var privateMethod = function(){
//     console.log("private method for " + self.name);
//     console.log(self);
//   }
//   this.name = name;
//   this.age = age;
//   this.greet = function(){
//     console.log("beep beep" + " " + this.name + " " + this.age);
//     console.log("welp: " + privateVariable);
//     privateMethod();
//   }
// }

// var me = new Person("myself",27);
// me.greet();

// class Dot{
//     constructor(x,y){
//       this.x = x;
//       this.y = y;
//       console.log("New dot.");
//     }
// }

// const dot1 = new Dot(10,10);


var values = {"Ace":1,"Two":2,"Three":3,"Four":4,"Five":5,"Six":6,"Seven":7,"Eight":8,"Nine":9,"Ten":10,"Jack":11,"Queen":12,"King":13};
            for (x in values){
                console.log(`Type: ${x}, Value: ${values[x]}`);
        }