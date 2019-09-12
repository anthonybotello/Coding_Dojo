var myString: any;
// I can assign myString like this:
myString = "Bee stinger";
// Why is there a problem with this? What can I do to fix this?
// Because it was declared as a string and therefore you can't redefine it as a number
// Fix by declaring 'myString' as 'any' type
myString = 9;


function sayHello(name: any){
    return `Hello, ${name}!`;
 }
 // This is working great:
 console.log(sayHello("Kermit"));
 // Why isn't this working? I want it to return "Hello, 9!"
 // Same thing as before.
 console.log(sayHello(9));

 
 function fullName(firstName: string, lastName: string, middleName?: string){
    let fullName = `${firstName} ${middleName} ${lastName}`;
    return fullName;
 }
 // This works:
 console.log(fullName("Mary", "Moore", "Tyler"));
 // What do I do if someone doesn't have a middle name?
 // 'middleName' is not nullable.
 // Fix by making 'middleName' nullable by changing to 'middleName?'.
 console.log(fullName("Jimbo", "Jones"));

 
 interface Student {
    firstName: string;
    lastName: string;
    belts: number;
 }
 function graduate(ninja: Student){
    return `Congratulations, ${ninja.firstName} ${ninja.lastName}, you earned ${ninja.belts} belts!`;
 }
 const christine = {
    firstName: "Christine",
    lastName: "Yang",
    belts: 2
 }
 const jay = {
    firstName: "Jay",
    lastName: "Patel",
    belts: 4
 }
 // This seems to work fine:
 console.log(graduate(christine));
 // This one has problems:
 // 'jay' has attribute 'belt' while 'student' interface requires attritube 'belts'
 console.log(graduate(jay));


 class Ninja {
    fullName: string;
    constructor(
       public firstName: string,
       public lastName: string){
          this.fullName = `${firstName} ${lastName}`;
       }
    debug(){
       console.log("Console.log() is my friend.")
    }
 }
 // This is not making an instance of Ninja, for some reason:
 const shane = new Ninja('shane','');
 // Since I'm having trouble making an instance of Ninja, I decided to do this:
 const turing = new Ninja('alan','turing');
 // Now I'll make a study function, which is a lot like our graduate function from above:
 function study(programmer: Ninja){
    return `Ready to whiteboard an algorithm, ${programmer.fullName}?`
 }
 // Now this has problems:
 // 'study()' expects a 'Ninja' object. 'turing' is not a 'Ninja' object.
 // Attempt to create instance of 'Ninja' failed because you didn't supply the necessary parameters or include the 'new' keyword
 // Fix by making 'turing' a 'Ninja' by calling the 'Ninja()' constructor
 
 console.log(study(turing));

 
 var increment = x => x + 1;
 // This works great:
 console.log(increment(3));
 var square = x => { return x * x };
 // Since the function is in blocks, you need to return the value to the outer scope
 // This is not showing me what I want:
 console.log(square(4));
 // This is not working:
 // Need to group the parameters, I guess.
 var multiply = (x,y) => x * y;
 // Nor is this working:
 // Wrap it in braces {}
 var math = (x, y) => {
     let sum = x + y;
     let product = x * y;
     let difference = Math.abs(x-y);
     return [sum, product, difference];
 }


 class Elephant {
    age: number;
   constructor(public _age: number){
       this.age = _age;
   }
   birthday = () => this.age++;
}
const babar = new Elephant(8);
setTimeout(babar.birthday, 1000)
setTimeout(function(){
   console.log(`Babar's age is ${babar.age}.`)
   }, 2000)
// Why didn't babar's age change? Fix this by using an arrow function in the Elephant class.


 