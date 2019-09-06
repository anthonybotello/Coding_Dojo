#Countdown
def countdown(num_start):
    countdown = []
    for i in range(num_start + 1):
        countdown.append(num_start - i)
    return countdown
print(countdown(5))


#Print and Return
def print_and_return(list):
    print(list[0])
    return(list[1])
print(print_and_return([1,2]))


#First Plus Length
def first_plus_length(list):
    return list[0] + len(list)
print(first_plus_length([1,2,3,4,5]))


#Values Greater than Second
def values_greater_than_second(list):
    count = 0
    new_list = []
    if len(list) < 2:
        return False
    for val in list:
        if val > list[1]:
            new_list.append(val)
            count += 1
    print(count)
    return new_list
print(values_greater_than_second([5,2,3,2,1,4]))
print(values_greater_than_second([3]))


#This Length, That Value
def length_and_value(size,value):
    if type(size) != int and type(value) != int:
        return False
    new_list = []
    for i in range (size):
        new_list.append(value)
    return new_list
print(length_and_value(4,7))
print(length_and_value(6,2))

