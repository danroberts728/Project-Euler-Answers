d1,d10,d100,d1000,d10000,d100000,d1000000 = '','','','','','',''
number=''
m=0 # The current decimal number (1, 2, 3, ..., 10, 11, 12
while True:
    m += 1
    number += str(m)
    if len(number) >= 1000000:
        d1000000    = number[999999]
        print("d1000000 is " + d1000000)
        d100000     = number[99999]
        print("d100000 is " + d100000)
        d10000      = number[9999]
        print("d10000 is " + d10000)
        d1000       = number[999]
        print("d1000 is " + d1000)
        d100        = number[99]
        print("d100 is " + d100)
        d10         = number[9]
        print("d10 is " + d10)
        d1          = number[0]
        print("d1 is " + d1)
        break
    if m%1000 == 0:
        print("At " + str(m) + " with " + str(len(number)) + " digits")

print(str(int(d1)*int(d10)*int(d100)*int(d1000)*int(d10000)*int(d100000)*int(d1000000)))
    
    
    
