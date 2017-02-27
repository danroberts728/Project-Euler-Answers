import numpy
import math

N, S, W, E = (0,-1), (0,1), (-1,0), (1,0)
turn_left = {N: W, W: S, S: E, E: N}

def BuildSpiral(width, height):
    if width < 1 or height < 1:
        raise ValueError
    x,y = width // 2, height//2
    dx,dy = S
    matrix = [[None] * width for _ in range(height)]
    count = 0
    while True:
        count += 1
        matrix[y][x] = count
        new_dx, new_dy = turn_left[dx,dy]
        new_x, new_y = x + new_dx, y + new_dy
        if (0 <= new_x < width and 0 <= new_y < height and
            matrix[new_y][new_x] is None): # can turn right
            x, y = new_x, new_y
            dx, dy = new_dx, new_dy
        else: # try to move straight
            x, y = x + dx, y + dy
            if not (0 <= x < width and 0 <= y < height):
                return matrix # nowhere to go
primes_cache = [2]
def is_prime(a):
    if a in primes_cache:
        return True
    if a < 2:
        return False
    if a == 2:
        return True
    for i in range(2, int(a**0.5)+1):
        if a%i == 0:
            return False
    else:
        primes_cache.append(a)
        return True

sideLength = 3
totalDiagonalCount = (sideLength*2) - 1
topRight = 3
topLeft = 5
bottomLeft = 7
bottomRight = 9
totalPrimeCount = 0
while True:
    if(is_prime(topRight)):
        totalPrimeCount += 1
    if(is_prime(topLeft)):
        totalPrimeCount += 1
    if(is_prime(bottomLeft)):
        totalPrimeCount += 1
    if(is_prime(bottomRight)):
        totalPrimeCount += 1

    totalDiagonalCount = (sideLength*2) - 1
    ratio = totalPrimeCount/totalDiagonalCount

    if(ratio < 0.1):
        print(sideLength)
        break
    else:
        sideLength += 2
        topRight = bottomRight + sideLength - 1
        topLeft = topRight + sideLength - 1
        bottomLeft = topLeft + sideLength - 1
        bottomRight = bottomLeft + sideLength - 1

