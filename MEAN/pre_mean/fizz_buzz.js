function fizzBuzz(n)
{
    var out = "";
    if (typeof n != "number" || n < 0)
    {
        return null;
    }
    for (var i = 1; i <= n; i++)
    {
        if (i % 5 === 0)
        {
            if (i % 3 === 0)
            {
                out = out + "FizzBuzz";
            }
            else
            {
                out = out + "Buzz";
            }
        }
        else if (i % 3 === 0 && i % 5 != 0)
        {
            out = out + "Fizz";
        }
        else
        {
            out = out + i;
        }
        if (i === n)
        {
            out += ".";
        }
        else
        {
            if (i === n-1)
            {
                out += ", and ";
            }
            else
            {
                out += ", ";
            }
        }
    }
    console.log(out);
}

fizzBuzz(15);
fizzBuzz("Fifteen");
fizzBuzz(-2);