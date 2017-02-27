def IsPandigital(n):
    n_str = str(n)
    if not len(n_str) == 9:
        return False
    else:
        for x in range(1,10):
            if not str(x) in n_str:
                return False
        return True

def IntegerGenerator():
    n = 1
    while True:
        yield n
        n += 1


largestPandigital = 123456789

a = 1
while True:
    a = a + 1
    concatenatedNumber = 0
    integers = IntegerGenerator()
    if int(str(a) + str(a*2)) > 987654321:
        break
    
    while concatenatedNumber <= 987654321:
        max_n = next(integers)+1
        products = []
        for n in range(1, max_n):
            products.append(a * n)
        cn = ''
        for p in products:
            cn += str(p)
        concatenatedNumber = int(cn)
        if concatenatedNumber <= 987654321 \
           and concatenatedNumber > largestPandigital \
           and IsPandigital(concatenatedNumber):
            largestPandigital = concatenatedNumber
    
print(largestPandigital)
