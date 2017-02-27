def isPrime(x):
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

def arePermutations(x,y,z):
    x_sorted = ''.join(sorted(str(x)))
    y_sorted = ''.join(sorted(str(y)))
    z_sorted = ''.join(sorted(str(z)))
    return x_sorted == y_sorted == z_sorted

for i in range(1000,10000):
    for j in range(1, 5000):
        if isPrime(i) and isPrime(i+j) and isPrime(i+j+j):
            if(arePermutations(i,i+j,i+j+j)):
                print(str(i) + "," + str(i+j) + "," + str(i+j+j))
