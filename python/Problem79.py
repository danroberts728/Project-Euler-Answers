def ComesBefore(n, lines):
    result = []
    s = str(n)
    for line in lines:
        position = line.find(s)
        if position > 0:
            for d in range(0,position):
                c = int(line[d])
                if c not in result:
                    result.append(c)
    result.sort()
    return result

def ComesAfter(n, lines):
    result = []
    s = str(n)
    for line in lines:
        position = line.find(s)
        if position < 2 and position > -1:
            for d in range(position+1,3):
                c = int(line[d])
                if c not in result:
                    result.append(c)
    result.sort()
    return result         
        
        

keylogFile = open('p079_keylog.txt', 'r')
keys = keylogFile.readlines()
# Remove duplicates
uniqueKeys = []
for key in keys:
    if key not in uniqueKeys:
        uniqueKeys.append(key)

for i in range(0,10):
    print("Comes before %d" % (i), end=": ")
    print(ComesBefore(i, keys))
for i in range(0,10):
    print("Comes after %d" % (i), end=": ")
    print(ComesAfter(i, keys))

print (len(uniqueKeys))

keylogFile.close()
