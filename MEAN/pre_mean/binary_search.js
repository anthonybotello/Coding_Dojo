function binarySearch(list,val)
{
    var lo = 0;
    var hi = list.length;
    var mid;
    var iterations = 0;
    while (hi >= lo)
    {
        mid = lo + Math.floor((hi - lo) / 2);
        if (val < list[mid])
        {
            hi = mid - 1;
        }
        else if (val > list[mid])
        {
            lo = mid + 1;
        }
        else
        {
            // console.log("Iterations: " + iterations);
            return mid;
        }
        iterations++;
    }
    // console.log("Iterations: " + iterations);
    return -1;
}

console.log(binarySearch([1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94, 200], 93));
console.log(binarySearch([1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94], 15));

// binarySearch is O[nlog(n)]

function binarySearchR(list,val, lo=0,hi=list.length)
{
    if (hi >= lo)
    {
        var mid = lo + Math.floor((hi - lo)/2);
        if (val < list[mid])
        {
            hi = mid - 1;
        }
        else if (val > list[mid])
        {
            lo = mid + 1;
        }
        else 
        {
            return mid;
        }
        return binarySearchR(list,val,lo,hi);
    }
    return -1;    
}

console.log(binarySearchR([1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94, 200], 93));
console.log(binarySearchR([1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94], 15));
