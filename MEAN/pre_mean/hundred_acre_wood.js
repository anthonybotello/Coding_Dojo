function Character(character,north=null,east=null,south=null,west=null)
{
    this.Character = character;
    this.North = north;
    this.East = east;
    this.South = south;
    this.West = west;
}

var pooh = new Character("Winnie the Pooh");
var tigger = new Character("Tigger");
var piglet = new Character("Piglet");
var bees = new Character("Bees");
var owl = new Character("Owl");
var chris = new Character("Christopher Robin");
var rabbit = new Character("Rabbit");
var gopher = new Character("Gopher");
var kanga = new Character("Kanga");
var eeyore = new Character("Eeyore");
var heffas = new Character("Heffalumps");

tigger.North = pooh;

pooh.North = chris;
pooh.East = bees;
pooh.South = tigger;
pooh.West = piglet;

piglet.North = owl;
piglet.East = pooh;

bees.North = rabbit;
bees.West = pooh;

chris.North = kanga;
chris.East = rabbit;
chris.South = pooh;
chris.West = owl;

owl.East = chris;
owl.South = piglet;

rabbit.East = gopher;
rabbit.South = bees;
rabbit.West = chris;

gopher.West = rabbit;

kanga.North = eeyore;
kanga.South = chris;

eeyore.East = heffas;
eeyore.South = kanga;

heffas.West = eeyore;

// var residents = [tigger,pooh,piglet,bees,owl,chris,rabbit,gopher,kanga,eeyore,heffas];

// residents.forEach(resident => {
//     var neighbors = [];
//     if (resident.North != null)
//     {
//         neighbors.push(resident.North.Character);
//     }
//     if (resident.East != null)
//     {
//         neighbors.push(resident.East.Character);
//     }
//     if (resident.South != null)
//     {
//         neighbors.push(resident.South.Character);
//     }
//     if (resident.West != null)
//     {
//         neighbors.push(resident.West.Character);
//     }
//     console.log("Character: " + resident.Character + ", Neighbors: " + neighbors);
// })

function Player(location)
{
    this.Location = location;
}

var player = new Player(tigger);

console.log(player.Location.Character);