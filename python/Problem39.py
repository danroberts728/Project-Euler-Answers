import math

def IsTriangle(a, b, c):
    return a+b > c and a+c > b and b+c > a

    
def IsRightTriangle(a, b, c):
    potentialHypotenuse = max(a,b,c)
    sides = []
    if potentialHypotenuse == a:
        sides = [b,c]
    if potentialHypotenuse == b:
        sides = [a,c]
    if potentialHypotenuse == c:
        sides = [a,b]

    return math.sqrt(sides[0]*sides[0] + sides[1]*sides[1]) == potentialHypotenuse

rightTrianglePerimeters = {}

for a in range(1, 1000):
    for b in range(a,1000):
        if a+b > 1000:
            break
        for c in range(b, 1000):
            if a+b+c <= 1000:
                if IsTriangle(a,b,c) and IsRightTriangle(a,b,c):
                    print("Right Triangle Found: " + str(a) + "," + str(b) + "," + str(c) + ": Perimeter = " + str(a+b+c))
                    if a+b+c not in rightTrianglePerimeters:
                        rightTrianglePerimeters[a+b+c] = 1
                    else:
                        rightTrianglePerimeters[a+b+c] += 1

for key in rightTrianglePerimeters:
    print(str(key) + ": " + str(rightTrianglePerimeters[key]))
