class Node:
    def __init__(self,val):
        self.value = val
        self.next = None

class SList:
    def __init__(self):
        self.head = None

    def addtoFront(self,val): #adds value to front of list
        new_node = Node(val)
        new_node.next = self.head
        self.head = new_node
        return self
    
    def addtoBack(self,val): #adds value to end of list
        loop_var = self.head
        new_node = Node(val)
        if self.head == None:
            self.head = new_node
            return self
        else:
            while loop_var.next != None:
                loop_var = loop_var.next
            loop_var.next = new_node
            return self

    def printValues(self): #prints values of list in sequential order
        if self.head == None:
            return False
        loop_var = self.head
        while loop_var != None:
            print(loop_var.value)
            loop_var = loop_var.next
        return self

    def removeFront(self): #removes first element from list
        if self.head == None:
            return False
        first_node_val = self.head.value
        self.head = self.head.next
        return first_node_val

    def removeBack(self): #removes last element from list
        if self.head == None:
            return False
        loop_var = self.head
        while loop_var.next.next != None:
            loop_var = loop_var.next
        last_node_val = loop_var.next.value
        loop_var.next = None
        return last_node_val

    def removeVal(self,val): #removes first instance of val
        if self.head == None:
            return False
        if self.head.value == val:
            self.removeFront()
            return self
        loop_var = self.head
        while loop_var.next != None:
            if loop_var.next.value == val:
                loop_var.next = loop_var.next.next
                break
            loop_var = loop_var.next
        return self

    def insertAt(self,val,n): #inserts val at list position n
        if self.head == None and n != 1:
            return False
        if n == 1:
            self.addtoFront(val)
            return self
        loop_var = self.head
        count = 2
        while loop_var.next != None:
            if count == n:
                temp = loop_var.next
                loop_var.next = Node(val)
                loop_var.next.next = temp
                return self
            count += 1
            loop_var = loop_var.next
        if count == n:
            self.addtoBack(val)
            return self
        if count < n:
            return False




my_list = SList()
my_list.addtoFront('are').addtoFront('Linked lists').addtoBack('fun!').printValues()
print('\n')

new_list = SList().addtoBack(1).addtoBack(2).addtoBack(3).addtoBack(4).addtoBack(5)
new_list.removeFront()
new_list.removeBack()
new_list.printValues()
print('\n')

new_list = SList().addtoBack(1).addtoBack(2).addtoBack(3).addtoBack(4).addtoBack(5)
new_list.removeVal(3).removeVal(1).removeVal(5).printValues()
print('\n')

new_list = SList().addtoBack(1).addtoBack(2).addtoBack(3).addtoBack(4).addtoBack(5)
new_list.insertAt("six",6).insertAt("one",1).insertAt(True,4).printValues()
print(new_list.insertAt("nope",11))