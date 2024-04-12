arr = [1, 2, 3, 4, 5, 10, -10, 100]

#Összegzés
def sum(arr):
    sum = 0
    for num in arr:
        sum += num
    return sum
print("Összegzés: ", sum(arr))

def isEven(num):
    return True if num % 2 == 0 else False

#Megszámlálás
def count(arr, funct):
    count = 0
    for num in arr:
        if funct(num):
            count += 1
    return count
print("Megszámlálás: ", count(arr, isEven))

#Kiválogatás
def filter(arr, funct):
    result = []
    for num in arr:
        if funct(num):
            result.append(num)
    return result
print("Kiválogatás: ", filter(arr, isEven))

#Minimális érték kiválasztása
def getMin(arr):
    min = arr[0]
    for i in range(1, len(arr)):
        if arr[i] < min:
            min = arr[i]
    return min
print("Minimális érték kiválasztása: ", getMin(arr))

#Minimális értékű elem előfordulási helyének meghatározása
def getMinIndex(arr):
    minIndex = 0
    for i in range(1, len(arr)):
        if arr[i] < arr[minIndex]:
            minIndex = i
    return minIndex
print("Minimális értékű elem előfordulási helye: ", getMinIndex(arr))

#Lineáris keresés
def linearSearch(arr, value):
    for num in arr:
        if num == value:
            return num
    return False
print("Lineáris keresés: ", linearSearch(arr, -10))

#Lineáris keresés rendezett sorozatban
sortedArr = sorted(arr)
print("sortedArr: ", sortedArr)
def sortedLinearSearch(sortedArr, value):
    i = 0
    while i < len(sortedArr) and sortedArr[i] < value:
        i += 1
    return i if i < len(sortedArr) and sortedArr[i] == value else False
print("Lineáris keresés rendezett sorozatban: ", sortedLinearSearch(sortedArr, -10))

#Bináris keresés
def binarySearch(arr, value):
    low = 0
    high = len(arr) - 1
    mid = high // 2
    while low <= high and arr[mid] != value:
        if value < arr[mid]:
            high = mid - 1
        else:
            low = mid + 1
        mid = (low + high) // 2
    return low <= high
print("Bináris keresés: ", binarySearch(sortedArr, -100))


