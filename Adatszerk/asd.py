list = [2, 6, 11, 43, 23, 10, 5, 8, 91]
# A rendezendő elemek az „s” sorozat elemei. A első menetben kiválasztjuk a sorozat legkisebb
# elemét úgy, hogy a sorozat „nulladik” elemét, „s[0]”-át összehasonlítjuk a sorozat soron következő
# elemeivel (s[1], s[2], ... s[n])-el). Ha az s[0]-ál kisebb elemet találunk, akkor felcseréljük őket,
# vagyis ezt a kisebb elemet tesszük „s[0]”-ba. A menet végére „s[0]” a sorozat legkisebb elemét
# tartalmazza. Az „s[0]”-át leválasztva - mivel már a helyére került - az eljárást „s[1]”-el folytatjuk,
# ezt hasonlítjuk össze az (s[2], ... s[n]) elemekkel. Az eljárást folytatva - menetenként a soron
# következő legkisebb elem kiválasztásával - n-1 menet után a sorozat rendezetté válik.
#
#
# A közvetlen kiválasztással történő rendezés során sokszor feleslegesen végzünk cserét. A felesleges
# cserék kiküszöbölése érdekében két segédváltozót – „érték”, „index” vezetünk be. Az „érték” nevű
# változó tartalmazza az adott menetben addig megtalált legkisebb elemet, az „index” pedig annak
# sorozatbeli sorszámát, indexét. Minden menetben az „s” sorozat elemeit az „érték” nevű változóval
# hasonlítjuk össze, s ha az „érték”-nél kisebb elemet találunk, akkor azt betesszük az „érték” nevű
# változóba, s az „index”-ben megjegyezzük a szóban forgó elem indexét. A menet végére az „érték”
# a sorozat soron következő legkisebb elemét tartalmazza, az „index” pedig azt a sorszámot, ahol ezt
# az elemet találtuk. Cserére csak a menet utolsó lépésében van szükségünk, amikor az „érték”-ben
# levő legkisebb elemet a helyére tesszük.

def kozvetlen(lista):
    for i in range(0, len(lista) - 1):
        minidx = i
        for j in range(i + 1, len(lista)):
            if lista[j] < lista[minidx]:
                minidx = j

        if minidx != i:
            temp = lista[minidx]  # csere
            lista[minidx] = lista[i]
            lista[i] = temp

    return lista
print(kozvetlen(list))

def kozvetlen2(lista):
    for i in range(0, len(lista) - 1):
        minidx = i
        for j in range(i + 1, len(lista)):
            if lista[j] > lista[minidx]:
                minidx = j

        if minidx != i:
            temp = lista[minidx]  # csere
            lista[minidx] = lista[i]
            lista[i] = temp

    return lista
print(kozvetlen2(list))

# A buborékos rendezés alapelve a szomszédos elemek cseréje. Az első menetben a rendezendő
# sorozat végéről elindulva minden elemet összehasonlítunk az előtte levővel. Ha rossz sorrendben
# vannak, akkor felcseréljük őket. Az első menet végére a legkisebb elem a helyére kerül. Minden
# további menetben ismét a sorozat végéről indulunk, de egyre kevesebb összehasonlításra van
# szükségünk, ugyanis a sorozat eleje fokozatosan rendezetté válik.
def buborek(lista):
    for i in range(len(lista)-1, 0, -1):
        for j in range(0, i):
            if lista[j+1] < lista[j]:
                temp = lista[j]
                lista[j] = lista[j+1]
                lista[j+1] = temp
    return lista
print(buborek(list))

# A koktélrendezés (cocktail sort) algoritmus egy tömb elemeinek sorba rendezésére.
# A buborékrendezés tökéletesített változata, mely két irányból megy végig a tömbön.
# Minimálisan bonyolultabb a buborékrendezésnél, de stabil marad, ugyanakkor
# kiküszöböli annak egyik problémáját, miszerint a nagy elemek gyorsan felemelkednek a helyükre
# (innen a „buborék” név), de a rossz helyen lévő kicsi elemek csak lassan süllyednek a helyükre.
def koktél(lista):  
    lenn = len(lista)
    start = 0
    vég = lenn - 1

    for i in range(0, lenn):

        for j in range(start, vég):
            if lista[j] > lista[j + 1]:
                temp = lista[j]
                lista[j] = lista[j + 1]
                lista[j + 1] = temp
        vég -= 1

        for k in range(vég, start, -1):
            if lista[k] < lista[k - 1]:
                temp = lista[k]
                lista[k] = lista[k - 1]
                lista[k - 1] = temp
        start += 1
    return lista
print(koktél(list))

# A Shell módszer nem foglalkozik egyszerre minden rendezendő elemmel, hanem csak az egymástól
# adott távolságra levőkkel. A rendezés több menetben történik. Minden menet elején meghatározunk
# egy lépésközt „d”, amely azt jelenti, hogy az adott menetben a sorozat egymástól „d” távolságra
# levő elemeit rendezzük. Az utolsó menetben „d=1” esetén a sorozat rendezetté válik.
# A Shell rendezés előnye, hogy viszonylag kevés művelettel az eredeti sorozat „nagyjából”
# rendezetté válik. Az elemek körülbelül egyszerre haladnak végleges helyük felé. A lépésköz
# csökkentésével ebben a nagyjából rendezett sorozatban már csak kisebb korrekciókat kell
# végrahajtanunk. Egy adott meneten belül a beszúró rendezést használjuk.

def shellSort(array, n):
    interval = n // 2
    while interval > 0:
        for i in range(interval, n):
            temp = array[i]
            j = i
            while j >= interval and array[j - interval] > temp:
                array[j] = array[j - interval]
                j -= interval

            array[j] = temp
        interval //= 2

# A gyors rendezés során a rendezendő sorozatunkat részekre bontjuk. Kiválasztjuk a sorozat egyik
# tetszõleges elemét (ezt alapnak vagy strázsának nevezzük), és ehhez az elemhez fogjuk hasonlítani
# a többi elemet.
# A sorozatban elõször balról, azaz a sorozat elejérõl indulva lépegetünk egészen addig, amíg a
# strázsánál kisebb elemet találunk. Ha egy elem nagyobb vegy egyenlõ mint a strázsa, akkor ott
# megállunk, és a sorozat jobb oldaláról, azaz a végérõl lépegetünk egészen addig, amíg a strázsánál
# nagyobb elemet találunk. Ha egy elem kisebb vagy egyenlõ mint a strázsa, akkor ott megállunk, és
# felcseréljük azt a két elemet, ahol megálltunk a lépegetések során. A lépegetést, keresést, cserét a
# következõ nagyobb illetve kisebb indexü elemnél folytatjuk egészen addig, amíg a két index össze
# nem ér (találkozik, vagy helyet cserél). Az eljárást, felosztási módszert egészen addig folytatjuk,
# amíg a felosztandó rész hossza 1 nem lesz.

def gyorsrendezes(lista):
    meret = len(lista)
    if meret <= 1:
        return lista
    kicsik = []
    egyenlo = []
    nagyok = []
    pivot = lista[meret - 1]
    for num in lista:
        if num < pivot:
            kicsik.append(num)
        if num == pivot:
            egyenlo.append(num)
        if num > pivot:
            nagyok.append(num)
    return gyorsrendezes(kicsik) + egyenlo + gyorsrendezes(nagyok)


print(gyorsrendezes(list))
# Balról veszem a második elemet és haladok jobbra. Ez lesz az aktuális elem. Mindig az aktuális elemtől balra lévő elemhez hasonlítok.
# Ha a balra lévő nagyobb, cserélek.
# Ha cseréltem a csere kisebb elemét megint a baloldalihoz hasonlítom.
# Ha nem cserélek tovább balra haladva, akkor visszamegyek az aktuális elemhez, és ott újra kezdem.
def insertion_sort(arr):
    # Végigiterálunk a tömb elemein
    for i in range(1, len(arr)):
        # Kiválasztjuk az aktuális elemet, amelyet beszúrunk a megfelelő helyre
        key = arr[i]
        # Az index, amelyen a key elemet beszúrjuk
        j = i - 1
        # Addig csúsztatjuk a nagyobb elemeket, amíg a helyét meg nem találjuk
        while j >= 0 and key < arr[j]:
            arr[j + 1] = arr[j]
            j -= 1
        # A helyre került elem beszúrása
        arr[j + 1] = key
    return arr
print(insertion_sort(list))

# Az összefuttatás tétel (Merge Sort) egy hatékony rendezési algoritmus, amely a "feloszt-és-uralkodj" elvet alkalmazza.
# A tétel lépései a következők:
# Felosztás: A rendezendő listát felosztjuk két egyenlő vagy közel egyenlő részre.
# Rekurzív rendezés: Mindkét részre rekurzívan alkalmazzuk ugyanezt a rendezési algoritmust,
# amíg az egyes részek mérete 1 vagy kevesebb nem lesz.
# Összefuttatás: Az egyes részleteket összefuttatjuk egy új listába, úgy hogy mindig a két rész kezdeténél lévő
# elemek közül a kisebbet másoljuk az új listába, majd léptetjük a mutatót az adott részen.
# Maradék összefűzése: Ha az egyik rész véget ér, akkor a másik rész maradék
# elemeit is egyszerűen hozzáadjuk az új listához.

def merge_sort(arr):
    if len(arr) > 1:
        mid = len(arr) // 2
        left_half = arr[:mid]
        right_half = arr[mid:]

        merge_sort(left_half)
        merge_sort(right_half)

        i = j = k = 0

        while i < len(left_half) and j < len(right_half):
            if left_half[i] < right_half[j]:
                arr[k] = left_half[i]
                i += 1
            else:
                arr[k] = right_half[j]
                j += 1
            k += 1

        while i < len(left_half):
            arr[k] = left_half[i]
            i += 1
            k += 1

        while j < len(right_half):
            arr[k] = right_half[j]
            j += 1
            k += 1

    return arr
print(merge_sort(list))