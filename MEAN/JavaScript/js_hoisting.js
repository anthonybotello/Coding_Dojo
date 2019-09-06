// 1
console.log("************************************")
var hello;
console.log(hello);
hello = 'world';

// console.log(hello);                                   
// var hello = 'world';                                 


// 2
console.log("************************************")
var needle;
function test()
{
    var needle;
    needle = 'magnet';
    console.log(needle);
}
needle = 'haystack';
test();

// var needle = 'haystack';
// test();
// function test(){
// 	var needle = 'magnet';
// 	console.log(needle);
// }


// 3
console.log("************************************")
var brendan;
function print()
{
    brendan = 'only okay';
    console.log(brendan);
}
brendan = 'super cool';
console.log(brendan);

// var brendan = 'super cool';
// function print(){
// 	brendan = 'only okay';
// 	console.log(brendan);
// }
// console.log(brendan);

// 4
console.log("************************************")
var food;
function eat()
{
    var food;
    food = 'half-chicken';
    console.log(food);
    food = 'gone';
}
food = 'chicken';
console.log(food);
eat();

// var food = 'chicken';
// console.log(food);
// eat();
// function eat(){
// 	food = 'half-chicken';
// 	console.log(food);
// 	var food = 'gone';
// }

// 5
// console.log("************************************")
// var mean;
// mean();
// console.log(food);
// mean = function()
// {
//     var food;
//     food = "chicken";
//     console.log(food);
//     food = "fish";
//     console.log(food);
// }
// console.log(food);

// mean();
// console.log(food);
// var mean = function() {
// 	food = "chicken";
// 	console.log(food);
// 	var food = "fish";
// 	console.log(food);
// }
// console.log(food);

// 6
console.log("************************************")
var genre;
function rewind()
{
    var genre;
    genre = "rock";
    console.log(genre);
    genre = "r&b";
    console.log(genre);
}
console.log(genre);
genre = "disco";
rewind();
console.log(genre);

// console.log(genre);
// var genre = "disco";
// rewind();
// function rewind() {
// 	genre = "rock";
// 	console.log(genre);
// 	var genre = "r&b";
// 	console.log(genre);
// }
// console.log(genre);

// 7
// NOTE THAT YOU DON'T NEED THE 'VAR' KEYWORD.
// DEFINING A VARIABLE WITHOUT 'VAR' SETS IT AS A PROPERTY ON THE GLOBAL SCOPE (I.E., AS A PROPERTY ON THE WINDOW OBJECT).
// IN THIS CASE THE CURRENT SCOPE OF 'DOJO' IS THE GLOBAL SCOPE, SO IT DOESN'T MATTER.
console.log("************************************")
function learn()
{
    var dojo;
    dojo = "seattle";
    console.log(dojo);
    dojo = "burbank";
    console.log(dojo);
}
dojo = "san jose";
console.log(dojo);
learn();
console.log(dojo);

// dojo = "san jose";
// console.log(dojo);
// learn();
// function learn() {
// 	dojo = "seattle";
// 	console.log(dojo);
// 	var dojo = "burbank";
// 	console.log(dojo);
// }
// console.log(dojo);

// 8
// NOTE: CONST OBJECTS (AND ARRAYS) CAN ADD OR CHANGE PROPERTIES, BUT CANNOT BE REASSIGNED
console.log("************************************")
function makeDojo(name, students)
{
    const dojo = {};
    dojo.name = name;
    dojo.students = students;
    if (dojo.students > 50)
    {
        dojo.hiring = true;
    }
    else if (dojo.students <= 0)
    {
        dojo = "closed for now";
    }
    return dojo;
}
console.log(makeDojo("Chicago",65));
console.log(makeDojo("Berkeley",0));

// console.log(makeDojo("Chicago", 65));
// console.log(makeDojo("Berkeley", 0));
// function makeDojo(name, students){
//         const dojo = {};
//         dojo.name = name;
//         dojo.students = students;
//         if(dojo.students > 50){
//             dojo.hiring = true;
//         }
//         else if(dojo.students <= 0){
//             dojo = "closed for now";
//         }
//         return dojo;
// }