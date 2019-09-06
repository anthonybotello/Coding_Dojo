# Basic
for i in range(151):
    print(i)


#Multiples of Five
for i in range(5,1001,5):
    print(i)


#Counting, the Dojo Way
for i in range (1,101):
    if i % 5 == 0 and i % 10 != 0:
        print('Coding')
    elif i % 10 == 0:
        print('Coding Dojo')
    else:
        print(i)


#Whoa. That Sucker's Huge
sum = 0
for i in range(0,500000):
    if i % 2 == 1:
        sum += i
print(sum)


#Countdown by Fours
for i in range(2018,0,-4):
    print(i)


#Flexible Counter
def flexCount(lowNum,highNum,mult):
    for i in range (lowNum,highNum + 1):
        if i % mult ==0:
            print(i)
flexCount(2,9,3)
