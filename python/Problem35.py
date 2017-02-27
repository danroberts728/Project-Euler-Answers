UpperBoundary = 1000000

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

def IsCircularPrime(a):
    if not IsPrime(a):
        return False
    aStr = str(a)
    for i in range(1,len(aStr)):
        rotation = aStr[i:] + aStr[:i]
        if not IsPrime(int(rotation)):
            return False
    else:
        print(a,end=' ')
        return True

confirmed = 0
for candidate in range(1,UpperBoundary):
    if IsCircularPrime(candidate):
        confirmed += 1


print("\n %d confirmed circular primes below %d" % (confirmed, UpperBoundary))
    
