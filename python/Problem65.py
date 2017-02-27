from fractions import Fraction

def GetListOfTerms(max):
    result = [1]
    evenNumber = 2
    iteration = 3
    while iteration < max+2:
        if (iteration % 3) == 0:
            result.append(evenNumber)
            evenNumber = evenNumber + 2
        else:
            result.append(1)
        iteration += 1
    return result
    
        
terms = GetListOfTerms(99)
terms.reverse()
lastFraction = Fraction(1,terms[0])
n = 0
for t in terms[1:]:
    n = Fraction(1,lastFraction + t)
    lastFraction = n

n = 2 + n
numerator_str = str(n.numerator)
sumOfDigits = 0
for d in numerator_str:
    sumOfDigits += int(d)
print(sumOfDigits)
