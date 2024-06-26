numArr = [1, 2, 3, 6, 5, 4, 10, 0, -2]
arr = [2, 6, 11, 43, 23, 10, 5, 8, 91]

# ***** KÖZVETLEN KIVÁLASZTÁS *****
# Sorba rendezi a sorozatot, oly módon, hogy megkeresi a legkisebb értéket a sorozatban, és azt a sorozat elejére, vagy végére cseréli.
# Ha ez megvan, akkor veszi a következő legkisebb elemet, a helyére cseréli, és így tovább.
def kozvetlen(arr):
    for i in range(0, len(arr) - 1):
        minIndex = i
        for j in range(i + 1, len(arr)):
            if arr[j] < arr[minIndex]:
                minIndex = j

        if minIndex != i:
            arr[minIndex], arr[i] = arr[i], arr[minIndex]
    return arr
print("Közvetlen (cs): ", kozvetlen(arr))

def kozvetlen2(arr):
    for i in range(0, len(arr) - 1):
        minIndex = i
        for j in range(i + 1, len(arr)):
            if arr[j] > arr[minIndex]:
                minIndex = j

        if minIndex != i:
            arr[minIndex], arr[i] = arr[i], arr[minIndex]
    return arr
print("Közvetlen (n): \t", kozvetlen2(arr))

# ***** BUBORÉK RENDEZÉS *****
# Sorba rendezi a sorozatot az egymással szomszédos elemek cseréjével.
# A sorozat végéről indul, és minden lépésben felcseréli a rossz sorredben levő szomszédokat.
def bubble_sort(arr):
    for i in range(len(arr)-1, 0, -1):
        for j in range(0, i):
            if arr[j+1] < arr[j]:
                arr[j], arr[j+1] = arr[j+1], arr[j]
    return arr
print("Buborék: \t", bubble_sort(arr))

# ***** KOKTÉL RENDEZÉS *****
# Sorba rendezi a sorozatot. A buborék rendezés tökéletesített változata.
# Két irányból kezdi el cserélgetni az egymással szomszédos, rossz sorrendben levő elemeket.
def cocktail_sort(arr):  
    arrLength = len(arr)
    lowI = 0
    highI = arrLength - 1

    for i in range(0, arrLength):        
        for j in range(lowI, highI):
            if arr[j] > arr[j + 1]:
                arr[j], arr[j+1] = arr[j+1], arr[j]
        highI -= 1

        for k in range(highI, lowI, -1):
            if arr[k] < arr[k - 1]:
                arr[j], arr[j+1] = arr[j+1], arr[j]
        lowI += 1
    return arr
print("Koktél: \t", cocktail_sort(arr))

# ***** SHELL RENDEZÉS *****
# Sorba rendez egy sorozatot, de nem foglalkozik egyszerre az összes elemmel, csak az egymástól bizonyos távolságra levőkkel.
def shell_sort(arr, n):
    half = n // 2
    while half > 0:
        for i in range(half, n):
            temp = arr[i]
            j = i
            while j >= half and arr[j-half] > temp:
                arr[j] = arr[j-half]
                j -= half
            arr[j] = temp
        half //= 2
    return arr
print("Shell: \t\t", shell_sort(arr, 4))

# ***** GYORS RENDEZÉS *****
# Sorba rendez egy sorozatot oly módon, hogy részekre bontja a sorozatot, és ezeket rendezi.
def gyors_rendezes(arr):
    arrLength = len(arr)
    if arrLength <= 1:
        return arr
    smalls = []
    equals = []
    bigs = []
    lastElement = arr[arrLength - 1]
    for num in arr:
        if num < lastElement:
            smalls.append(num)
        if num == lastElement:
            equals.append(num)
        if num > lastElement:
            bigs.append(num)
    return gyors_rendezes(smalls) + equals + gyors_rendezes(bigs)
print("Gyors: \t\t", gyors_rendezes(arr))

# ***** INSERTION SORT *****
# Sorba rendez egy sorozatot, oly módon, hogy az elemeket mindig a tűlük balra levő elemhez viszonyítja,
# és kicseréli őket, ha szükséges.
def insertion_sort(arr):
    for i in range(1, len(arr)):
        curr = arr[i]
        j = i - 1
        while j >= 0 and curr < arr[j]:
            arr[j+1] = arr[j]
            j -= 1
        arr[j+1] = curr
    return arr
print("Insertion: \t", insertion_sort(arr))

# ***** ÖSSZEFUTTATÁS TÉTELE (MERGE SORT) *****
# Hatékonyan sorba rendez egy sorozatot a sorozat felosztása, rekurzió és a részek összefuttatásának segítségével.
def merge_sort(arr):
    if len(arr) > 1:
        mid = len(arr) // 2
        leftHalf = arr[:mid]
        rightHalf = arr[mid:]

        merge_sort(leftHalf)
        merge_sort(rightHalf)

        i = j = k = 0

        while i < len(leftHalf) and j < len(rightHalf):
            if leftHalf[i] < rightHalf[j]:
                arr[k] = leftHalf[i]
                i += 1
            else:
                arr[k] = rightHalf[j]
                j += 1
            k += 1

        while i < len(leftHalf):
            arr[k] = leftHalf[i]
            i += 1
            k += 1

        while j < len(rightHalf):
            arr[k] = rightHalf[j]
            j += 1
            k += 1
    return arr
print("Merge: \t\t", merge_sort(arr))