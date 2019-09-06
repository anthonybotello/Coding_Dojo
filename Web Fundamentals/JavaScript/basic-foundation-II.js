//Biggie Size
function makeItBig(arr){
    for (var i=0;i<arr.length;i++){
        if (arr[i]>0){
            arr[i] = 'big';
        }
    }
    return arr;
}
console.log(makeItBig([-1,3,5,-5]));


//Print Low, Return High
function printLowReturnHigh(arr){
    var low = 0;
    var high = 0;
    for (var i = 0; i < arr.length; i++){
        if (arr[i] < low){
            low = arr[i];
        }
        if (arr[i] > high){
            high = arr[i];
        }
    }
    console.log(low);
    return high;
}
console.log(printLowReturnHigh([-6,6,7,-1,0]));

//Print One, Return Another
function printOneReturnAnother(arr){
    console.log(arr[arr.length-2]);
    for (var i = 0; i < arr.length; i++){
        if (arr[i] % 2 == 1){
            return arr[i];
        }
    }
}
console.log(printOneReturnAnother([-6,6,7,-1,0]));


//Double Vision
function double(arr){
    var newarr = [];
    for (var i = 0; i < arr.length; i++){
        newarr[i] = 2*arr[i];
    }
    return newarr;
}
var test = [1,2,3];
console.log(double(test));
console.log(test);


//Count Positives
function countPositives(arr){
    var count = 0;
    for (var i = 0; i < arr.length; i++){
        if (arr[i] > 0){
            count++;
        }
    }
    arr[arr.length-1] = count;
    return arr;
}
console.log(countPositives([-1,1,1,1]));


//Evens and Odds
function evensOdds(arr){
    for (var i = 0; i < arr.length-2; i++){
        if (Math.abs(arr[i]%2) == 1 && Math.abs(arr[i+1]%2) == 1 && Math.abs(arr[i+2]%2) == 1){
            console.log("That's odd!");
        }
        if (arr[i]%2 == 0 && arr[i+1]%2 == 0 && arr[i+2]%2 == 0){
            console.log("Even more so!");
        }
    }
}
evensOdds([1,3,7,4,6,8,1,2,3,7,5,2,6,8,10]);


//Increment the Seconds
function everyOtherPlus1(arr){
    for (var i = 0; i < arr.length; i++){
        if (i % 2 == 1){
            arr[i] += 1;
        }
        console.log(arr[i]);
    }
    return arr;
}
console.log(everyOtherPlus1([1,5,2,7,6,9]));


//Previous Lengths
function previousStringLength(arr){
    for (var i = arr.length - 1; i > 0; i--){
        arr[i] = arr[i - 1].length;
    }
    return arr;
}
console.log(previousStringLength(["hello", "dojo", "awesome"]));


//Add Seven
function addSeven(arr){
    var newarr = [];
    for (var i = 0; i < arr.length; i++){
        newarr[i] = arr[i] + 7;
    }
    return newarr;
}
var test = [1,2,3];
console.log(addSeven(test));
console.log(test);


//Reverse Array
function reverseArray(arr){
    for (var i = 0; i < arr.length/2; i++){
        var temp = arr[i];
        arr[i] = arr[arr.length - 1 - i];
        arr[arr.length - 1 - i] = temp;
    }
    return arr;
}
console.log(reverseArray([3,1,6,4,2]));


//Outlook: Negative
function allNegative(arr){
    for (var i = 0; i < arr.length; i++){
        if (arr[i] > 0){
            arr[i] *= -1;
        }
    }
    return arr;
}
console.log(allNegative([1,-3,5]));


//Always Hungry
function alwaysHungry(arr){
    for (var i = 0; i < arr.length; i++){
        if (arr[i] == "food"){
            console.log("yummy");
            return;
        }
    }
    console.log("I'm hungry");
}
alwaysHungry([1,5,"not food", "a bucket of erasers"]);
alwaysHungry([1,5,"food", "a bucket of erasers"]);


//Swap Toward the Center
function swapTowardCenter(arr){
    for (var i = 0; i < arr.length/4; i++){
        temp = arr[2*i];
        arr[2*i] = arr[arr.length - 1 - 2*i];
        arr[arr.length - 1 - 2*i] = temp;
    }
    return arr;
}
console.log(swapTowardCenter([true, 42, "stray cat", "Ada", 2, 9, "pizza"]));


//Scale the Array
function scaleArray(arr, num){
    for (var i = 0; i < arr.length; i++){
        arr[i] *= num;
    }
    return arr;
}
console.log(scaleArray([1,2,3],3));