def gen_primes():
    D = {}  
    q = 2  

    while True:
        if q not in D:
            yield q        
            D[q * q] = [q]
        else:
            for p in D[q]:
                D.setdefault(p + q, []).append(p)
            del D[q]
        q += 1

def IsPrime(a):
    if a < 2:
        return False
    if a == 2:
        return True
    for i in range(2, int(a**0.5)+1):
        if a%i == 0:
            return False
    else:
        return True

def IsTruncatablePrime(a):
    if a<10: # By Definition
        return False
    aStr = str(a)
    for i in range(0,len(aStr)): #Left to right
        if not IsPrime(int(aStr[i:])):
            return False
    for i in range(0,len(aStr)): #Right to left
        if not IsPrime(int(aStr[:len(aStr)-i])):
            return False
    return True

primes = gen_primes()
count = 0
summation = 0
while count < 11:
    p = next(primes)
    if IsTruncatablePrime(p):
        print(p)
        count += 1
        summation += p
print(summation)
        
