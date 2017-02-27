import time
start_time = time.time()

import itertools

def HasProperty(numberAsStr):
    return  int(numberAsStr[7:10])%17 == 0  \
            and int(numberAsStr[6:9])%13 == 0 \
            and int(numberAsStr[5:8])%11 == 0 \
            and int(numberAsStr[4:7])%7 == 0 \
            and int(numberAsStr[3:6])%5 == 0 \
            and int(numberAsStr[2:5])%3 == 0 \
            and int(numberAsStr[1:4])%2 == 0

sum = 0
pandigital = "1234567890"
for permutation in itertools.permutations(pandigital):
    permutationStr = ''.join(permutation)
    if int(permutation[3])%2 == 0 and HasProperty(permutationStr):
        sum += int(permutationStr)
print(sum)
##while True:
##        numberAsStr = str(1406357289)
##        if(HasProperty(numberAsStr)):
##           print("TRUE")
   
print("--- %s seconds ---" % (time.time() - start_time))
