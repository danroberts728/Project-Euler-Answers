from fractions import Fraction

def IsCancellingDigitFraction(numerator, denominator):
    #Do they share a digit in both numerator and denominator?
    f = Fraction(numerator, denominator)
    numeratorStr = str(numerator)
    denominatorStr = str(denominator)
    for nd in str(numeratorStr):
        if nd in denominatorStr:
            if denominatorStr.replace(nd,'',1) == '0':
                continue
            reducedFraction = Fraction(int(numeratorStr.replace(nd,'',1)), \
                                       int(denominatorStr.replace(nd,'',1)))
            if reducedFraction == f:
                return True
    return False

product = Fraction(1)
for numerator in range(10,100):
    for denominator in range(numerator+1, 100):
        if (numerator % 10 == 0 and denominator % 10 == 0):
            continue
        if(IsCancellingDigitFraction(numerator, denominator)):
            print ("%d / %d" % (numerator,denominator))
            product *= Fraction(numerator,denominator)

print(product.denominator)
        
            
