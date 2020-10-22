# def convert(number):
#     raindrop = ''
#     if number % 3 ==  0: raindrop += 'Pling'
#     if number % 5 == 0: raindrop += 'Plang'
#     if number % 7 == 0: raindrop += 'Plong' 
#     # return str(number) if not raindrop else raindrop
#     return raindrop or str(number)

# def convert(number):
#     conditions = {
#         3: 'Pling',
#         5: 'Plang',
#         7: 'Plong',
#     }
#     sound = ''.join([v for k, v in conditions.items() if number % k == 0])

#     return sound or str(number)

def convert(n):
    return "".join(s for mod, s in [(3, "Pling"), (5, "Plang"), (7, "Plong")]
                   if n % mod == 0) or str(n)