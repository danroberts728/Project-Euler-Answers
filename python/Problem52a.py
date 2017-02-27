import time
start_time = time.time()
n=100000
while True:
    n = n+1
    
    str_n_sorted = sorted(str(n))
    len_n = len(str_n_sorted)

    str_6n = str(6*n)

    if len_n != len(str_6n):
        # We can skip every number from this to the next order or magnitude
        new_str_n = ''
        for i in range(len_n):
            new_str_n += '9'
        n = int(new_str_n)
    
    else:
        if str_n_sorted == sorted(str_6n):
        #if len(n) == len(6n), then we can stop testing lengths
            if str_n_sorted == sorted(str(5*n)):
                if str_n_sorted == sorted(str(4*n)):
                    if str_n_sorted == sorted(str(3*n)):
                        if str_n_sorted == sorted(str(2*n)):
                            print(str(n))
                            break

print("--- %s seconds ---" % (time.time() - start_time))
