def binarySearch(val,list):
    hi = len(list)
    lo = 0

## Edge Cases ##

    if list[hi-1] < val or list[lo] > val:
        return False
    if hi < 1:
        return False
    if type(val) != int:
        return False

## End Edge Cases ##

    while hi >= lo:
        mid = int(lo + (hi-lo)/2)
        if list[mid] == val:
            return mid
        elif list[mid] > val:
            hi = mid - 1
        elif list[mid] < val:
            lo = mid + 1
    
    return False

## Test Cases ##

list=[1,4,23,56,66,71,79,84,92]
print(binarySearch(99,list))
print(binarySearch(0,list))
print(binarySearch(4.3,list))
print(binarySearch(53,list))

for val in list:
    print(f'Index: {binarySearch(val,list)}')

## End Test Cases ##