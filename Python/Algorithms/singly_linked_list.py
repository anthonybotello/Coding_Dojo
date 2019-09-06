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

    def hasLoop(self):
        if self.head == None:
            return False
        runner = self.head
        run_next = self.head.next
        while run_next != None:
            if run_next.next == runner:
                return True
            runner = runner.next
            run_next = run_next.next
        return False