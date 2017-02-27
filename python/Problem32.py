import itertools
decimalDigitsStr = ['1','2','3','4','5','6','7','8','9']
lowerBound = 1234
upperBound = 98765

# Given number a, return all digits 1-9 not included as a list
def GetOtherDigits(a):
    result = []
    digits = str(a)
    for n in decimalDigitsStr:
        if digits.count(n) < 1:
            result.append(int(n))
    return result

# Determine if a number has nonzero, unique digits
def HasUniqueDigits(a):
    digits = str(a)
    if '0' in digits:
        return False
    for n in digits:
        if not digits.count(n) == 1:
            return False
    return True

# List of digits to a number
def ListToNumber(l):
    str_digits = ''
    for item in l:
        str_digits += str(item)
    return int(str_digits)

SumOfPandigitalProducts = 0
for product in range(lowerBound,upperBound+1):
    #If its not unique digits, don't bother
    if not HasUniqueDigits(product):
        continue

    #Get the digits that aren't in there already
    digits = GetOtherDigits(product)

    #Try every permutation of these extra 1-9 digits possible.
    perms = list(itertools.permutations(digits))

    foundOne = False
    for ordering in perms:
        if foundOne:
            break
        orderedNumbers = ListToNumber(ordering)
        for firstNumberLength in range(1,len(ordering)):
            multiplicand = int(str(orderedNumbers)[:firstNumberLength])
            multiplier = int(str(orderedNumbers)[firstNumberLength:])
            if (multiplicand * multiplier == product):
                SumOfPandigitalProducts += product
                foundOne = True
                break
                
            
print(SumOfPandigitalProducts)


