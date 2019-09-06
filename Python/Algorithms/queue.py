from singly_linked_list import Node, SList

class Queue:
	def __init__(self):
		self.SLlist = SList()
	
	def enqueue(self,val):
		self.SLlist.addtoBack(val)
		return self
	
	def dequeue(self):
		first_val = self.SLlist.removeFront()
		return first_val

	def peek(self):
		print(self.SLlist.head.value)
		return self