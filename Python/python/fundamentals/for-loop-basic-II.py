#Biggie Size
def biggie_size(list):
    for val in list:
        if val > 0:
            list[list.index(val)] = "big"
    return list
print(biggie_size([-1,3,5,-5]))


#Count Positives
def count_positives(list):
    count = 0
    for val in list:
        if val > 0:
            count += 1
    list[len(list) - 1] = count
    return list
print(count_positives([-1,1,1,1]))
print(count_positives([1,6,-4,-2,-7,-2]))


#Sum Total
def sum_total(list):
    sum = 0
    for val in list:
        sum += val
    return sum
print(sum_total([1,2,3,4]))
print(sum_total([6,3,-2]))


#Average
def average(list):
    avg = 0
    for val in list:
        avg += val/len(list)
    return avg
print(average([1,2,3,4]))


#Length
def length(list):
    length = 0
    for val in list:
        length += 1
    return length
print(length([37,2,1,-9]))
print(length([]))


#Minimum
def minimum(list):
    if len(list) == 0:
        return False
    min = 0
    for val in list:
        if val < min:
            min = val
    return min
print(minimum([37,2,1,-9]))
print(minimum([]))


#Maximum
def maximum(list):
    if len(list) == 0:
        return False
    max = 0
    for val in list:
        if val > max:
            max = val
    return max
print(maximum([37,2,1,-9]))
print(maximum([]))


#Ultimate Analysis
def ultimate_analysis(list):
    return {'sumTotal' : sum_total(list), 'average' : average(list), 'minimum' : minimum(list), 'maximum' : maximum(list), 'length' : length(list)}
print(ultimate_analysis([37,2,1,-9]))


#Reverse List
def reverse_list(list):
    temp = 0
    for i in range (int(len(list)/2)):
        temp = list[i]
        list[i] = list[len(list) - 1 - i]
        list[len(list) - 1 - i] = temp
    return list
print(reverse_list([37,2,1,-9]))
