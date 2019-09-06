def bubbleSort(list):
    sorted_list = True
    for i in range(len(list)-1):
        if list[i] > list[i+1]:
            temp = list[i+1]
            list[i+1] = list[i]
            list[i] = temp
            sorted_list = False
    if sorted_list:
        return list
    else:
        return bubbleSort(list)

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