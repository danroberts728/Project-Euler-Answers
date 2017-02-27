a_min = 2
a_max = 100
b_min = 2
b_max = 100
uniqueTerms = []

for a in range(a_min, a_max+1):
    for b in range(b_min, b_max+1):
        term = a**b
        if term not in uniqueTerms:
            uniqueTerms.append(term)
print(len(uniqueTerms))
