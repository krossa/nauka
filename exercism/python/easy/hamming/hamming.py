# def distance(strand_a, strand_b):
#     if len(strand_a) != len(strand_b):
#         raise ValueError('.+')
#     hamming_distance = 0
#     for a, b in zip(strand_a, strand_b):
#         if a != b:
#             hamming_distance += 1
#     return hamming_distance

# def distance(strand_a, strand_b):
#     if len(strand_a) != len(strand_b):
#         raise ValueError('.+')
#     return sum(i != j for i, j in zip(strand_a, strand_b))

# from operator import ne

# def distance(s,t):
#     if len(s) != len(t):
#             raise ValueError('.+')
#     return sum(map(ne,s,t))

def distance(strand_a, strand_b):
    if len(strand_a) != len(strand_b):
        raise ValueError('.+')
    return sum(map(lambda a, b: a != b, strand_a, strand_b))
