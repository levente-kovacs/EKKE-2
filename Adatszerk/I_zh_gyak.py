numArr = [1, 2, 3, 6, 5, 4, 10, 0, -2]

# ***** ÖSSZEGZÉS TÉTELE *****
# Meghatározza egy sorozat elemeinek az összegét.
def calcSum(numArr):
    sum = 0
    for num in numArr:
        sum += num
    return sum
print(calcSum(numArr))

# ***** MEGSZÁMLÁLÁS TÉTELE *****
# Meghatározza, hogy egy sorozatban hány adott tulajdonságú elem szerepel.
def countEvens(numArr):
    count = 0
    for num in numArr:
        if num % 2 == 0:
            count += 1
    return count
print(countEvens(numArr))

# ***** KIVÁLOGATÁS TÉTELE *****
# Egy sorozatból kiválogatja az adott tulajdonságú elemeket.
def checkIfEven(num):
    if num % 2 == 0:
        return True
    return False

def filterArr(numArr, func):
    result = []
    for num in numArr:
        if func(num):
            result.append(num)
    return result
print(filterArr(numArr, checkIfEven))

# ***** MINIMÁLIS ÉRTÉK KIVÁLASZTÁSA TÉTEL *****
# Meghatározza egy sorozat legkisebb értékét (adott logika szerint).
def getMinValue(numArr):
    min = numArr[0]
    for i in range(1, len(numArr)):
        if numArr[i] < min:
            min = numArr[i]
    return min
print(getMinValue(numArr))

# ***** MINIMÁLIS ÉRTÉKŰ ELEM ELŐFORDULÁSI HELYÉNEK MEGHATÁROZÁSA *****
# Meghatározza egy sorozat legkisebb értékének az indexét (előfordulási helyét).
def getMinIndex(numArr):
    minIndex = 0
    for i in range(1, len(numArr)):
        if numArr[i] < numArr[minIndex]:
            minIndex = i
    return minIndex
print(getMinIndex(numArr))

# ***** LINEÁRIS KERESÉS *****
# Meghatározza, hogy egy sorozatban van-e adott tulajdonságú elem, és ha igen, akkor mi az indexe.
def linearSearch(numArr, func):
    for i in range(0, len(numArr)):
        if func(numArr[i]):
            return i
    return -1
print (linearSearch(numArr, checkIfEven))

# ***** LINEÁRIS KERESÉS RENDEZETT SOROZATBAN *****
sortedNumArr = sorted(numArr)
# # print(sortedNumArr)
def sortedLinearSearch(sortedNumArr, value):
    i = 0
    while i < len(sortedNumArr) and sortedNumArr[i] < value:
        i += 1
    return i if i < len(sortedNumArr) and sortedNumArr[i] == value else -1
print ("LINEÁRIS KERESÉS RENDEZETT SOROZATBAN: ", sortedLinearSearch(sortedNumArr, 10))
# --------- Python-ba hibára fut ---------

# --------- JS-be teljesen jó    ---------
# function sortedLS(sortedNumArr, value) {
#     i = 0;
#     while (sortedNumArr[i] < value && i < sortedNumArr.length) {
#         i++;
#     }
#     return sortedNumArr[i] == value ? i : -1;
# }
# sortedLS(sortedNumArr, 100)

# ***** BINÁRIS KERESÉS *****
# Megvizsgálja, hogy egy adott érték szerepel e egy sorba rendezett sorozatban.
def binarySearch(sortedNumArr, value):
    low = 0
    high = len(sortedNumArr) - 1
    mid = high // 2
    # print("A középső elem indexe:",mid,"\n")
    while low <= high and sortedNumArr[mid] != value:
        if value < sortedNumArr[mid]:
            high = mid - 1
            # print("Az első elem indexe:", low)
            # print("Az utolsó elem indexe:", high)
        else:
            low = mid + 1
        # print("Az első elem indexe:", low)
        # print("Az utolsó elem indexe:", high)
        mid = (low + high) // 2
        # print("A középső elem indexe:",mid,"\n")
    Hely = mid
    print("A hely változó értéke:",Hely)
    return low <= high
print(binarySearch(sortedNumArr, -2))


















# def linearis_kereses(A, fuggveny):
#     I = 0
#     while I < len(A) and not fuggveny(A[I]):
#         I += 1
#     Hely = I
#     return I < len(A)