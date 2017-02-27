def IsPositiveDirection(pointA, pointB):
    v1x = pointA[0]
    v1y = pointA[1]
    v2x = pointB[0]
    v2y = pointB[1]
    return v1x*v2y - v2x*v1y > 0

def IsOriginInTriangle(vertice1, vertice2, vertice3):
    v1v2 = IsPositiveDirection(vertice1, vertice2)
    v2v3 = IsPositiveDirection(vertice2, vertice3)
    v3v1 = IsPositiveDirection(vertice3, vertice1)
    return v1v2 == v2v3 and v2v3 == v3v1    

criteriaCount = 0
triangleFile = open('p102_triangles.txt', 'r')
for line in triangleFile:
    points = line.split(',')
    vertices = [(int(points[0]), int(points[1])),\
                (int(points[2]), int(points[3])), \
                (int(points[4]), int(points[5]))]
    if IsOriginInTriangle(vertices[0], vertices[1], vertices[2]):
        criteriaCount += 1
print(criteriaCount)
