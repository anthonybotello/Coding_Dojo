//Sigma
function sigma(num){
    var sum = 0;
    if (num > 0){
        for (var i = 0; i <= num; i++){
            sum += i;  
        }
    }
    return sum;
}
console.log(sigma(3));
console.log(sigma(5));


//Factorial
function factorial(num){
    var product = 1;
    if (num > 0){
        for (var i = 1; i <= num; i++){
            product *= i;
        }
    }
    return product;
}
console.log(factorial(3));
console.log(factorial(5));


//Fibonacci (no recursion, method 1)
function fibonacci(n){
    var prev_1 = 1;
    var prev_2 = 0;
    var fib_n = prev_1 + prev_2;
    if (n == 0 || n == 1){
        return n;
    }
    else {
        for (var i = 0; i < n-1; i++){
        fib_n = prev_1 + prev_2;
        prev_2 = prev_1;
        prev_1 = fib_n;
        }
        return fib_n
    }
}
var fibarr=[];
for(var i = 0; i < 10; i++){
fibarr[i] = fibonacci(i);
}
console.log(fibarr);

//Fibonacci (no recursion, method 2)
function fibonacci(n){
    var fib = [0,1];
    for (var i = 0; i <= n - 2; i++){
        fib[i + 2] = fib [i + 1] + fib[i];
    }
    return fib[n];
}
var fibarr=[];
for(var i = 0; i < 10; i++){
fibarr[i] = fibonacci(i);
}
console.log(fibarr);


//Array: Second-to-Last
function secondToLast(arr){
    if (arr.length < 2){
        return null;
    }
    else {
        return arr[arr.length - 2];
    }
}
console.log(secondToLast([42]));
console.log(secondToLast([42,true,4,"Liam",7]));


//Array: Nth-to-Last
function nthToLast(arr,n){
    if (arr.length < n){
        return null;
    }
    else {
        return arr[arr.length - n];
    }
}
console.log(nthToLast([5,2,3,6,4,9,7],3));


//Array: Second-Largest
function secondLargest(arr){
    largest = 0;
    second_largest = 0;
    for (var i = 0; i < arr.length; i++){
        if (largest < arr[i]){
            largest = arr[i];
        }
        if (second_largest < arr[i] < largest){
            second_largest = arr[i];
        }
    }
    return second_largest;
}
console.log(secondLargest([42,1,4,3.14,7]));


//Double Trouble
function doubleTrouble(arr){
    var sup = arr.length;
    for (var i = sup; i > 0; i--){
        arr[2*i-1] = arr[i-1];
        arr[2*i-2] = arr[i-1];
    }
    return arr;
}
console.log(doubleTrouble([3,2,1]));

//Fibonacci (with recursion)
function fibonacci(n){
    if (n == 0 || n == 1){
        return n;
    }
    return fibonacci(n-1) + fibonacci(n-2);
}
var fibarr=[];
for(var i = 0; i < 10; i++){
fibarr[i] = fibonacci(i);
}
console.log(fibarr);

