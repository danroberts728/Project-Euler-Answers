from math import factorial

def SumOfFactorialsOfDigits(n):
    result = 0
    for d in str(n):
        result += factorial(int(d))
    return result

for i in range(3,1000000):
    if SumOfFactorialsOfDigits(i) == i:
        print(i)
