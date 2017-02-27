import operator

def TriangleNumber(n):
    return n*(n+1)/2

def PentagonalNumber(n):
    return n*(3*n-1)/2

def HexagonalNumber(n):
    return n*(2*n-1)

pentagonalNumbersCache = {1:1}
hexagonalNumbersCache = {1:1}

def IsPentagonalNumber(value):
    if(value in pentagonalNumbersCache.values()):
        return True
    n = max(pentagonalNumbersCache.keys())
    p_n = pentagonalNumbersCache[n]
    while p_n < value:
        n = n+1
        p_n = PentagonalNumber(n)
        if p_n == value:
            return True
        pentagonalNumbersCache[n] = p_n
    return False

n = 285
while True:
    n = n+2
    t_n = TriangleNumber(n)
    if IsPentagonalNumber(t_n):
        print(t_n)
        break
    if n%1000 == 1:
        print("Passing n=" + str(n) + ", t_n=" + str(t_n))
    
