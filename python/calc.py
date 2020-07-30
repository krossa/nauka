num1 = input("Please enter first number: ")
num2 = input("Please enter second number: ")
if not num1.isdigit() or not num2.isdigit():
    print("Parameters are not numbers")
    quit()
sum = int(num1) + int(num2)
print(sum)