#test for primality
def IsPrime(x):
    x = abs(int(x))
    if x < 2:
        return False
    if x == 2:
        return True
    if not x & 1:
        return False
    for y in range(3, int(x**0.5)+1, 2):
        if x % y == 0:
            return False
    return True

def QuadatricAnswer(a, b, n):
    return n**2 + a*n + b

def CountNumberOfPrimes(a, b):
    n = 0
    while IsPrime(QuadatricAnswer(a,b,n)):
        n = n+1
   # print("a=%d, b=%d has %d primes" % (a, b, n))
    return n

#boundary values
a_min = -999
a_max = 1000
b_min = -999
b_max = 1000
maxNumberOfPrimes = 0

for a in range(a_min, a_max):
    for b in range(b_min, b_max): #iterate through possible values
        numberOfPrimes = CountNumberOfPrimes(a,b)
        if numberOfPrimes > maxNumberOfPrimes:
            maxNumberOfPrimes = numberOfPrimes
            print('New Max # of %d primes!' % numberOfPrimes) 
            print('a=%d, b=%d' % (a, b))
            print('Product=%d' % (a * b))
        
        
