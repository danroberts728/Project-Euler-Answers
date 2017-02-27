def IsDigitFourthNumber(n):
    summation = 0
    for digit in str(n):
        summation += int(digit)**4
    return summation == n

def IsDigitFifthNumber(n):
    summation = 0
    for digit in str(n):
        summation += int(digit)**5
    return summation == n

upperBound = 1000000
summation = 0
for number in range(2, upperBound):
    if IsDigitFifthNumber(number):
        summation += number

print(summation)
