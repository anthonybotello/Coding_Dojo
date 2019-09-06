from stack import Stack

def postfixCalculator(list):
    stack = Stack()
    for item in list:
        if type(item) == int:
            stack.push(item)
        else:
            b = stack.pop()
            a = stack.pop()
            if item == '+':
                stack.push(a+b)
            if item == '-':
                stack.push(a-b)
            if item == '*':
                stack.push(a*b)
            if item == '/':
                stack.push(a/b) 
    return stack.pop()

print(postfixCalculator([4,5,7,2,'+','-','*']))
print(postfixCalculator([3,4,'+',2,'*',7,'/']))
print(postfixCalculator([5,7,'+',6,2,'-','*']))
print(postfixCalculator([4,2,3,5,1,'-','+','*','+']))
print(postfixCalculator([4,2,'+',3,5,1,'-','*','+']))