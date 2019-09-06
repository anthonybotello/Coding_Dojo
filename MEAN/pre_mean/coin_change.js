function coinChange(money)
{
    var vals = {
        dollars: 100,
        quarters: 25,
        dimes: 10,
        nickles: 5,
        pennies: 1
    }
    var cents = 0;
    if (typeof money === 'object')
    {
        for (x in money)
        {
            cents += money[x]*vals[x];
        }
    }
    else if (typeof money === 'number')
    {
        cents += money;        
    }
    var sorted_coins = new Object();
    for (x in vals)
    {
        var num = Math.floor(cents / vals[x]);
        if (num > 0)
        {
            sorted_coins[x] = num;
            cents = cents % vals[x];
        }
    }
    return sorted_coins;
}

console.log(coinChange(312));
console.log(coinChange({dollars:2,dimes:15,pennies:5}));