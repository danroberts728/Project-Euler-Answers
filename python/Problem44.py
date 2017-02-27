knownPentagonals = []

def GetPentagonal(n):
    return n*(3*n-1)/2
def IsPentagonal(number, start_n):
    n = start_n
    pentagonal = GetPentagonal(n)
    while pentagonal <= number:
        pentagonal = GetPentagonal(n)
        if pentagonal == number:
            return True
        n = n+1
    return False


for k in range(1,10000):
    p_k = GetPentagonal(k)
    knownPentagonals.append(p_k)
    for p_j in knownPentagonals:
        difference = p_k - p_j
        if difference in knownPentagonals:
            summation = p_k + p_j
            if IsPentagonal(summation, k):
                print("D = " + str(p_k) + " - " + str(p_j) + " = " + str(difference) + " (p" + str(k) + " - p" + str(knownPentagonals.index(int(p_j))+1) + " = p" + str(knownPentagonals.index(int(difference))+1) + ")")
        
