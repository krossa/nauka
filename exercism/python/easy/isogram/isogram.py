def is_isogram(message):
    message = message.lower().replace('-','').replace(' ','')
    return len(message) == len(set(message))

