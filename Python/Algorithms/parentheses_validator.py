from stack import Stack

def isValid(braces):
    bracestack = Stack()
    open_brace = {'(':')','[':']','{':'}'}
    close_brace = {')':'(',']':'[','}':'{'}
    for char in braces:
        if char in open_brace:
            bracestack.push(char)
        if char in close_brace and close_brace[char] == bracestack.peek():
            bracestack.pop()
    if bracestack.SLlist.head != None:
        return False
    else:
        return True

