import timeit
start_time = timeit.default_timer()
def GetWord(wordFile, start, length):
    wordFile.seek(start)
    fullEntry = wordFile.read(length)
    return fullEntry[1:-2]

def WordNumber(word):
    return sum([ord(char) - 96 for char in word.lower()])

wordNumbers = []
with open('p042_words.txt', 'r') as wordFile:
    startSpot = 0
    length = 0
    while True:
        char = wordFile.read(1)
        length += 1
        if char == ',' or char == '':
            newStartSpot = wordFile.tell()
            wordNumbers.append(WordNumber(GetWord(wordFile, startSpot, length)))
            length = 0
            startSpot = newStartSpot
            if char == '':
                break
numberTriangleWords = 0
n = 0
triangleNumber = 0
threshold = max(wordNumbers)
while triangleNumber <= threshold:
    n += 1
    triangleNumber = (1/2)*n*(n+1)
    matches = list(filter(lambda x: x == triangleNumber, wordNumbers))
    numberTriangleWords += len(matches)

elapsed = timeit.default_timer() - start_time
print(numberTriangleWords)
print(elapsed)
