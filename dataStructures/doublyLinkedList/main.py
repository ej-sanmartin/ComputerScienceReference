"""Doubly Linked List implementation in Python."""

from typing import Any, Optional


class Node:
    """Represents a node in a doubly linked list."""

    def __init__(self, data: Any) -> None:
        """Initialize a new node with the given data.

        Args:
            data: The data to store in the node.
        """
        self.data = data
        self.next: Optional[Node] = None
        self.prev: Optional[Node] = None


class DoublyLinkedList:
    """A doubly linked list data structure."""

    def __init__(self) -> None:
        """Initialize an empty doubly linked list."""
        self.head: Optional[Node] = None

  def append(self, data):
    if self.head is None:
      new_node = Node(data)
      self.head = new_node
    else:
      new_node = Node(data)
      cur = self.head
      while cur.next:
        cur = cur.next
      cur.next = new_node
      new_node.prev = cur

  def prepend(self, data):
    if self.head is None:
      new_node = Node(data)
      self.head = new_node
    else:
      new_node = Node(data)
      self.head.prev = new_node
      new_node.next = self.head
      self.head = new_node

  def print_list(self):
    cur = self.head
    while cur:
      print(cur.data)
      cur = cur.next

  def add_after_node(self, key, data):
    cur = self.head
    while cur:
      if cur.next is None and cur.data == key:
          self.append(data)
          return 
      elif cur.data == key:
          new_node = Node(data)
          nxt = cur.next
          cur.next = new_node
          new_node.next = nxt
          new_node.prev = cur
          nxt.prev = new_node
          return
      cur = cur.next

  def add_before_node(self, key, data):
    cur = self.head
    while cur:
      if cur.prev is None and cur.data == key:
        self.prepend(data)
        return
      elif cur.data == key:
        new_node = Node(data)
        prev = cur.prev
        prev.next = new_node
        cur.prev = new_node
        new_node.next = cur
        new_node.prev = prev
        return
      cur = cur.next

  def delete(self, key):
    cur = self.head
    while cur:
      if cur.data == key and cur == self.head:
        # Case 1:
        if not cur.next:
          cur = None 
          self.head = None
          return

        # Case 2:
        else:
          nxt = cur.next
          cur.next = None 
          nxt.prev = None
          cur = None
          self.head = nxt
          return 

      elif cur.data == key:
          # Case 3:
        if cur.next:
            nxt = cur.next 
            prev = cur.prev
            prev.next = nxt
            nxt.prev = prev
            cur.next = None 
            cur.prev = None
            cur = None
            return

          # Case 4:
        else:
            prev = cur.prev 
            prev.next = None 
            cur.prev = None 
            cur = None 
            return 
      cur = cur.next

  def reverse(self):
    tmp = None
    cur = self.head
    while cur:
      tmp = cur.prev
      cur.prev = cur.next
      cur.next = tmp
      cur = cur.prev
    if tmp:
      self.head = tmp.prev
