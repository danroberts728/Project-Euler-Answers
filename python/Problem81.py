grid = []
for line in open('p081_matrix.txt'):
    line_list_str = line.split(',',80)
    line_list_int = [int(i) for i in line_list_str]
    grid.append(line_list_int)

horizontal = 0
vertical = 0
runningSum = grid[0][0]
minSum = 548877

def Move(grid, right, down):
    

count = 1
while True:
    



    
    print('[' + str(horizontal) + ',' + str(vertical) + '] = ' + str(grid[horizontal][vertical]))
    if vertical == 79 or grid[horizontal+1][vertical] < grid[horizontal][vertical+1]:
        horizontal = horizontal + 1
    else:
        vertical = vertical + 1
    runningSum += grid[horizontal][vertical]
    count = count + 1
    if horizontal == 79 and vertical == 79:
        break
print('[' + str(horizontal) + ',' + str(vertical) + '] = ' + str(grid[horizontal][vertical]))    
print(runningSum)
print (count)
