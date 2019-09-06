function maxMinAvg(arr)
{
    var max = arr[0];
    var min = arr[0];
    var avg = 0;
    for (var i = 0; i < arr.length; i++)
    {
        if (arr[i] > max)
        {
            max = arr[i];
        }
        if (arr[i] < min)
        {
            min = arr[i];
        }
        avg += arr[i]/arr.length;
    }
    return "Max: " + max + ", Min: " + min + ", Avg: " + avg;
}

console.log(maxMinAvg([1,-2,9,4]));
