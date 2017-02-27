def DoesContainSameDigits(number):
    x = number
    xStr = str(number)
    twoX = number * 2
    twoXStr = str(twoX)
    threeX = number * 3
    threeXStr = str(threeX)
    fourX = number * 4
    fourXStr = str(fourX)
    fiveX = number * 5
    fiveXStr = str(fiveX)
    sixX = number * 6
    sixXStr = str(sixX)
    if (len(xStr) != len(sixXStr)):
        return False
    else:
        return sorted(xStr) == sorted(twoXStr) \
               and sorted(twoXStr) == sorted(threeXStr) \
               and sorted(threeXStr) == sorted(fourXStr) \
               and sorted(fourXStr) == sorted(fiveXStr) \
               and sorted(fiveXStr) == sorted(sixXStr)

import time
start_time = time.time()
n = 1
while True:
    if DoesContainSameDigits(n):
        print(str(n))
        break
    else:
        n = n+1
print("--- %s seconds ---" % (time.time() - start_time))
