import collections
import string


def count_words(text):
    print('22222222')
    processed_text = text.translate(str.maketrans(',', ' ', '')).lower()
    print(processed_text)
    processed_text = text.translate(str.maketrans(',_', '  ', '')).lower()
    print(processed_text)
    processed_text = text.translate(str.maketrans('', '', string.punctuation)).lower()
    print(processed_text)
    processed_text = text.translate(str.maketrans(',_', '  ', string.punctuation)).lower()
    print(processed_text)
    print('3333333')
    return collections.Counter(processed_text.split())
