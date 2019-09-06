function bracesValid(str)
{
    braces = {
        ')':'(',
        ']':'[',
        '}':'{'
    };
    var arr = str.split("");
    for (var i = 0; i < arr.length; i++)
    {
        if (arr[i] in braces)
        {
            if (arr[i-1] === braces[arr[i]])
            {
                arr.splice(i-1,2);
                i = 0;
            }
            else
            {
                return false;
            }
        }
    }
    return true;
}

console.log(bracesValid('{{()}}[]'));
console.log(bracesValid('{(})'));
console.log(bracesValid('(()]()}}'));