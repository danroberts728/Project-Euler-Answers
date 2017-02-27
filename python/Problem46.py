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

def IsGoldbachComposite(n):
    primes = gen_primes()
    # ans = P + 2 * A**2
    ans = 0
    A = 0
    P = 0
    while P < n:
        P = next(primes)
        for A in range(0,n):
            A += 1
            ans = P + 2 * A**2
            if ans == n:
                return True
            if ans > n:
                break
    else:
        return False
        

n = 1
while True:
    n = n + 2
    if not IsPrime(n) and not IsGoldbachComposite(n):
        print(str(n) + ': Not Goldbach composite.')
        break
