class Node:
    def __init__(self,val):
        self.value = val
        self.next = None
        self.prev = None
    
class DList:
    def __init__(self):
        self.head = None

    def addFront(self,val):
        new_node = Node(val)
        self.head.prev = new_node
        new_node.next = self.head
        self.head = new_node
        return self
    
    def addBack(self,val):
        runner = self.head
        new_node = Node(val)
        if self.head == None:
            self.head = new_node
            return self
        else:
            while runner.next != None:
                runner = runner.next
            runner.next = new_node
            new_node.prev = runner
            return self

    def removeFront(self):
        if self.head == None:
            return False
        first_node_val = self.head.value
        self.head = self.head.next
        self.head.prev = None
        return first_node_val

    def removeBack(self):
        if self.head == None:
            return False
        runner = self.head
        while runner.next.next != None:
            runner = runner.next
        runner.next.prev = None
        runner.next = None
        return self

    def insertAt(self,val,idx): #add edge cases later
        new_node = Node(val)
        runner = self.head
        if idx == 0:
            new_node.next = self.head
            self.head.prev = new_node
            self.head = new_node
            return self
        count = 0
        while count < idx:
            runner = runner.next
            count += 1
        runner.prev.next = new_node
        new_node.prev = runner.prev.next
        new_node.next = runner
        runner.prev = new_node
        return self

    def printValues(self): #prints values of list in sequential order
        if self.head == None:
            return False
        loop_var = self.head
        while loop_var != None:
            print(loop_var.value)
            loop_var = loop_var.next
        return self

dlist = DList()
dlist.addBack(1).addBack(2).addBack(3).addBack(4).addBack(5)
# dlist.printValues()
# dlist.addFront(0).addFront(-1).addFront(-2).addFront(-3).addFront(-4).addFront(-5)
# dlist.printValues()
# dlist.removeFront()
# dlist.printValues()
# dlist.removeBack()
# dlist.printValues()
dlist.insertAt("3!",0)
dlist.printValues()
