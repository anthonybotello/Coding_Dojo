from singly_linked_list import Node, SList

class Stack:
	def __init__(self):
		self.SLlist = SList()
	
	def push(self,val):
		self.SLlist.addtoFront(val)
		return self

	def pop(self):
		if self.SLlist.head == None:
			return False
		top_val = self.SLlist.head.value
		self.SLlist.head = self.SLlist.head.next
		return top_val
	
	def peek(self):
		return self.SLlist.head.value
