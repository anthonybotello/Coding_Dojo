def selectionSort(list):
    if len(list) < 1:
        return False
    for j in range(len(list)-1):
        min = list[j]
        min_idx = j
        for i in range(j,len(list)):
            if list[i] < min:
                min = list[i]
                min_idx = i
        list[min_idx] = list[j]
        list[j] = min
    return list
    

print(selectionSort([8,5,2,6,9,3,1,4,0,7]))