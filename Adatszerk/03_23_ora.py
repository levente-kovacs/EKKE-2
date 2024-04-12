numArr = [4, 6, 2, 5, 7, 11, 1, 3]

# def smaller_than_3(value):
#     return value < 3

# print(smaller_than_3(7))

# def filter(arr1, arr2, function):
#     count = 0;
#     for i in range(0, len(arr1)):
#         if function(arr1[i]):
#             count += 1
#             arr2.append(arr1[i])
#         print(arr2)
#     return count

# print(filter(numArr, [], smaller_than_3))


# def filterEvenNumbers(arr):
#     resultArr = []
#     for i in range(0, len(arr)):
#         if (arr[i] % 2 == 0):
#             resultArr.append(arr[i])
#     return resultArr

# print(filterEvenNumbers(numArr))


# def getMin(arr):
#     min = arr[0]
#     for i in range(1, len(arr)):
#         if (arr[i] < min):
#             min = arr[i]
#     return min

# print(getMin(numArr))


# def getMax(arr):
#     max = arr[0]
#     for i in range(1, len(arr)):
#         if (arr[i] > max):
#             max = arr[i]
#     return max

# print(getMax(numArr))

# def getMinIndex(arr):
#     minIndex = 0
#     for i in range(1, len(arr)):
#         if (arr[i] < arr[minIndex]):
#             minIndex = i
#     return minIndex

# print(getMinIndex(numArr))


# def getMaxIndex(arr):
#     maxIndex = 0
#     for i in range(1, len(arr)):
#         if (arr[i] > arr[maxIndex]):
#             maxIndex = i
#     return maxIndex

# print(getMaxIndex(numArr))


# def linearSearch(arr, val):
#     arr = sorted(arr)
#     i = 0
#     while i < len(arr) and val > arr[i]:
#         i += 1
#     return i < len(arr) and val == arr[i]

# print(linearSearch(numArr, 4))

# myArr = [1, 2, 3, 4, 5]

# def binarySearch(arr, val):
#     arr = sorted(arr)
#     print(arr)
#     lowerLimit = 0
#     higherLimit = len(arr) - 1
#     actual = higherLimit // 2
#     # print(f"actual index: {actual}")
#     while lowerLimit <= higherLimit and arr[actual] != val:
#         print(lowerLimit, actual, higherLimit)
#         if val < arr[actual]:
#             higherLimit = actual - 1
#         else:
#             lowerLimit = actual + 1
#         actual = (lowerLimit + higherLimit) // 2
#     return actual <= higherLimit

# print(binarySearch(numArr, 100))


# def binaris_kereses(A, Adat):
#     A = sorted(A)
#     E = 0
#     # print("Az első elem indexe:",E)
#     U = len(A) -1
#     # print("Az utolsó elem indexe:", U)
#     K = (E + U) // 2
#     # print("A középső elem indexe:",K,"\n")
#     while E <= U and A[K] != Adat:
#         if Adat < A[K]:
#             U = K - 1
#         # print("Az első elem indexe:", E)
#         # print("Az utolsó elem indexe:", U)
#         else:
#             E = K + 1
#         # print("Az első elem indexe:", E)
#         # print("Az utolsó elem indexe:", U)
#         K = (E + U) // 2
#         # print("A középső elem indexe:",K,"\n")
#     Hely = K
#     print("A hely változó értéke:",Hely)
#     return E <= U
# print(binaris_kereses(numArr, 1))


arr1 = [5, 3, 6, 2, 1, 11, 8, 7, 9]
arr2 = [6, 2, 7, 8, 9, 1, 6, 3]
result = []
arr1Len = len(arr1)
arr2Len = len(arr2)

# for val in arr1:
#     i = 0
#     while i < arr2Len and val != arr2[i]:
#         i += 1
#     if i < arr2Len:
#         result.append(val)
# print(result)

# arr1Len = len(arr1)
# for i in range(0, arr1Len-1):
#     for j in range(i+1, arr1Len):
#         if arr1[i] > arr1[j]:
#             arr1[i], arr1[j] = arr1[j], arr1[i]
# print(arr1)

# def minSort(arr):
#     for j in range(0, len(arr) - 1):
#         minI = j
#         for i in range(j+1, len(arr)):
#             if arr[i] < arr[minI]:
#                 minI = i
#         if minI != j:
#             arr[minI], arr[j] = arr[j], arr[minI]
#             # tmp = arr[minI]
#             # arr[minI] = arr[j]
#             # arr[j] = tmp
#     return arr
# print(minSort(arr1))

# def maxSort(arr):
#     for j in range(0, len(arr) - 1):
#         maxI = j
#         for i in range(j+1, len(arr)):
#             if arr[i] > arr[maxI]:
#                 maxI = i
#         if maxI != j:
#             arr[maxI], arr[j] = arr[j], arr[maxI]
#     return arr
# print(maxSort(arr1))

for i in range(0, arr1Len):
    for j in range(0, i):
        if arr1[j] > arr1[j+1]:
            arr1[j], arr1[j+1] = arr1[j+1], arr1[j]
print(arr1)