//Get 1 to 255
function array1to255(){
    arr = [];
    for (var i=1;i<=255;i++){
        arr.push(i);
    }
    return arr;
}
console.log(array1to255());


//Get even 1000
function sumEven1to1000(){
    var sum = 0;
    for (i=1;i<=500;i++){
        sum = sum + 2*i;
    }
    return sum;
}
console.log(sumEven1to1000());


//Sum odd 5000
function sumOdd1to5000(){
    var sum = 0;
    for (i=0;i<2500;i++){
        sum = sum + 2*i+1;
    }
    return sum;
}
console.log(sumOdd1to5000());


//Iterate an array
function sumArray(arr){
    var sum = 0;
    for (var i=0;i<arr.length;i++){
        sum += arr[i];
    }
    return sum;
}
console.log(sumArray([1,2,5]));


//Find max
function maxOfArray(arr){
    var max = 0;
    for (var i=0;i<arr.length;i++){
        if (arr[i]>max){
            max = arr[i];
        }
    }
    return max;
}
console.log(maxOfArray([-3,3,5,7]));


//Find average
function avgOfArray(arr){
    var sum = 0;
    for (var i=0; i<arr.length; i++){
        sum += arr[i];
    }
    return sum/arr.length;
}
console.log(avgOfArray([1,3,5,7,20]));


//Array odd
function arrayOdd1to50(){
    var arrOdd =[];
    for (var i=0; i<25;i++){
        arrOdd.push(2*i+1);
    }
    return arrOdd;
}
console.log(arrayOdd1to50());


//Greater than Y
function greaterThanY(arr,Y){
    var count = 0;
    for (var i=0; i<arr.length;i++){
        if (arr[i]>Y){
            count++;
        }
    }
    return count;
}
console.log(greaterThanY([1,3,5,7],3));


//Squares
function squareArray(arr){
    for (var i=0;i<arr.length;i++){
        arr[i] *= arr[i];
    }
    return arr;
}
console.log(squareArray([1,5,10,-2]));


//Negatives
function zeroNegatives(arr){
    for (var i=0;i<arr.length;i++){
        if (arr[i]<0){
            arr[i]=0;
        }
    }
    return arr;
}
console.log(zeroNegatives([1,5,10,-1]));


//Max/Min/Avg
function maxMinAvg(arr){
    var newarr = [0,0,0];
    for (var i=0;i<arr.length;i++){
        if (arr[i]>newarr[0]){
            newarr[0] = arr[i];
        }
        if (arr[i]<newarr[1]){
            newarr[1] = arr[i];
        }
        newarr[2] += arr[i]/arr.length;
    }
    return newarr;
}
console.log(maxMinAvg([1,5,10,-2]));


//Swap Values
function swapValues(arr){
    var temp = arr[0];
    arr[0] = arr[arr.length-1];
    arr[arr.length-1] = temp;
    return arr;
}
console.log(swapValues([1,5,10,-2]));


//Number to String
function numToString(arr){
    for (var i=0;i<arr.length;i++){
        if (arr[i]<0){
            arr[i] = 'Dojo';
        }
    }
    return arr;
}
console.log(numToString([-1,-3,2]));