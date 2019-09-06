def insertionSort(list):
    if len(list) < 2:
        return False
    for i in range(1,len(list)):
        if list[i] < list[i-1]:
            temp = list.pop(i)
            for j in range(len(list)):
                if list[j] > temp:
                    list.insert(j,temp)
                    break
    return list

print(insertionSort([6,5,3,1,8,7,2,4]))
print(insertionSort([-1,4,-5,7,0,3,-5,6,-2]))