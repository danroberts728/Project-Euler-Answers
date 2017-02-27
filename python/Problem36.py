def IsPalindrome(s):
    return s == s[::-1]

summation = 0
for n in range(1,1000000):
    n_dec = str(n)
    if IsPalindrome(n_dec):
        n_bin = "{0:b}".format(n)
        if IsPalindrome (n_bin):
            summation += n
print(summation)
