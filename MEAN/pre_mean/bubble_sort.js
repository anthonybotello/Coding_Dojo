function bubbleSort(arr)
{
    var sorted = false;
    var j = arr.length;
    while (j > 1 && !sorted)
    {
        sorted = true;
        for (var i = 0; i < j - 1; i++)
        {
            if (arr[i] > arr[i+1])
            {
                sorted = false;
                var temp = arr[i];
                arr[i] = arr[i+1];
                arr[i+1] = temp;
            }
        }
        j -= 1;
    }
    console.log("Iterations: " + (arr.length - j));
    return arr;
}

console.log(bubbleSort([6,5,3,1,8,7,2,4]));
console.log(bubbleSort([1,2,3,4,5,6,7,8,9]));


// printArray() is O(n)
// findNth() is O(1)
// halving() is O[log(n)]
// identityMatrix() is O(n^2)