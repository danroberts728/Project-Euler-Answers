def isPrime(n):
    for i in range(2,int(n**0.5)+1):
        if n%i==0:
            return False

    return True

def permutations(string, step = 0):
    # if we've gotten to the end, print the permutation
    if step == len(string) and isPrime(int("".join(string))):
        print("".join(string))

    # everything to the right of step has not been swapped yet
    for i in range(step, len(string)):

        # copy the string (store as array)
        string_copy = [character for character in string]

        # swap the current index with the step
        string_copy[step], string_copy[i] = string_copy[i], string_copy[step]

        # recurse on the portion of the string that has not been swapped yet (now it's index will begin with step + 1)
        permutations(string_copy, step + 1)
         
largePandigital = 987654321
while True:
    permutations(str(largePandigital))
    largePandigital = int(str(largePandigital)[1:])
##while True:
##    for pandigital_str in permutations(str(largePandigital)):
##        pandigital_num = int(pandigital_str)
##        if isPrime(pandigital_num):
##            print(str(pandigital_num))
##        else:
##            print(str(pandigital_num))
