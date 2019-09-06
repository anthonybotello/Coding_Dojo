def coinChange_i(x,cost): #iterative
    coins = {
        '0.25':0,
        '0.10':0,
        '0.05':0,
        '0.01':0
    }
    change = x-cost
    for coin in coins:
        coins[coin] = int(change/float(coin))
        change = change % float(coin)
    return coins


def coinChange_r(x,cost,coins=[0.01,0.05,0.10,0.25],num_coins={}): #recursive
    coin_val = coins.pop()
    change = x - cost 
    count = int(change/coin_val)
    num_coins[f'{coin_val}'] = count
    if len(coins) > 0:
        return coinChange_r(change,coin_val*count,coins,num_coins)
    else:
        return num_coins