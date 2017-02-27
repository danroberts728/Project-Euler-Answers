def prime_factors(n):
    i = 2
    factors = []
    while i * i <= n:
        if n % i:
            i += 1
        else:
            n //= i
            factors.append(i)
    if n > 1:
        factors.append(n)
    return factors
first = 644
while True:
    first = first+1
    second = first+1
    third = first+2
    fourth = first+3
    if len(set(prime_factors(first))) == 4 \
       and len(set(prime_factors(second))) == 4 \
       and len(set(prime_factors(third))) == 4 \
       and len(set(prime_factors(fourth))) == 4:
        print(str(first) + ': ' + str(prime_factors(first)))
        print(str(second) + ': ' + str(prime_factors(second)))
        print(str(third) + ': ' + str(prime_factors(third)))
        print(str(fourth) + ': ' + str(prime_factors(fourth)))
        break
