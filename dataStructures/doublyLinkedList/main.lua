local Node = {}
Node.__index = Node

function Node.new(value)
  local self = setmetatable({}, Node)

  self.value = value
  self.previous = nil
  self.next = nil

  return self
end

local DoublyLinkedList = {}
DoublyLinkedList.__index = DoublyLinkedList

function DoublyLinkedList.new()
  local self = setmetatable({}, DoublyLinkedList)

  self.__head = nil
  self.__tail = nil
  self.__count = 0

  return self
end

-- T - O(1)
function DoublyLinkedList:getHead()
  return self.__head
end

-- T - O(1)
function DoublyLinkedList:getTail()
  return self.__tail
end

-- T - O(1)
function DoublyLinkedList:count()
  return self.__count
end

-- T - O(1)
function DoublyLinkedList:isEmpty()
  return self.__count == 0
end

-- T - O(1)
function DoublyLinkedList:clear()
  self.__head = nil
  self.__tail = nil
  self.__count = 0
end

-- T - O(1)
function DoublyLinkedList:peek()
  return self.__head.value
end

-- T - O(1)
function DoublyLinkedList:removeFront()
  if self.__count == 0 then
    io.write("WARNING: Can't pop an empty Doubly Linked List\n")
    return nil
  end

  if self.__count == 1 then
    local data = self.__head.value
    self.__head = nil
    self.__tail = nil
    self.__count = self.__count - 1
    return data
  end

  local oldHead = self.__head
  self.__head.next.previous = nil
  self.__head = self.__head.next
  oldHead.next = nil
  self.__count = self.__count - 1
  return oldHead.value
end

-- T O(1)
function DoublyLinkedList:removeBack()
  if self.__count == 0 then
    io.write("WARNING: Can't remove from an empty Doubly Linked List")
    return nil
  end

  if self.__count == 1 then
    local data = self.__tail.value
    self.__tail = nil
    self.__head = nil
    self.__count = self.__count - 1
    return data
  end

  local oldTail = self.__tail
  self.__tail.previous.next = nil
  self.__tail = self.__tail.previous
  oldTail.previous = nil
  self.__count = self.__count - 1
  return oldTail.value
end

-- T O(n), where n is the number of nodes in doubly linked list
function DoublyLinkedList:removeValue(value)
  if self.__count == 0 then
    return false
  end

  local current = self.__head
  local sentinel = Node.new(0)
  sentinel.next = self.__head
  while current ~= nil do
    if(current.value == value) then
      if current == self.__head then
        self.__head = current.next
      elseif current == self.__tail then
        self.__tail = current.previous
      end
      local deletedNode = current
      sentinel.next = current.next
      current = sentinel.next
      deletedNode.next = nil
      deletedNode.previous = nil
      self.__count = self.__count - 1
      return true
    end

    sentinel = current
    current = current.next
  end

  return false
end

-- T O(n), where n is the number of nodes in the Doubly Linked List
function DoublyLinkedList:removeAllValue(value)
  if self.__count == 0 then
    return false
  end

  local didRemoveAValue = false
  local current = self.__head
  local sentinel = Node.new(0)
  sentinel.next = self.__head
  while current ~= nil do
    if current.value == value then
      if current == self.__head then
        self.__head = current.next
      elseif current == self.__tail then
        self.__tail = current.previous
      else
        didRemoveAValue = true
        local deletedNode = current
        sentinel.next = current.next
        current = sentinel.next
        deletedNode.next = nil
        deletedNode.previous = nil
        self.__count = self.__count - 1
      end
    else
      sentinel = current
      current = current.next
    end
  end

  return didRemoveAValue
end

-- T - O(1)
function DoublyLinkedList:addFront(value)
  local newHead = Node.new(value)

  if self.__head == nil then
    self.__head = newHead
    if self.__tail == nil then
      self.__tail = newHead
    end

    self.__count = self.__count + 1
    return
  end

  newHead.next = self.__head
  self.__head.previous = newHead
  self.__head = newHead

  if self.__count == 0 then
    self.__tail = newHead
  end

  self.__count = self.__count + 1
end

-- T - O(1)
function DoublyLinkedList:addBack(value)
  local newTail = Node.new(value)

  if self.__tail == nil then
    self.__tail = newTail
    if self.__head == nil then
      self.__head = newTail
    end

    self.__count = self.__count + 1
  end

  newTail.previous = self.__tail
  self.__tail.next = newTail
  self.__tail = newTail

  if self.__count == 0 then
    self.__head = newTail
  end

  self.__count = self.__count + 1
end

-- T - O(n)
function DoublyLinkedList:addAfter(node, value)
  if node == nil then
    io.write("Passed node is nil, can not determine where to add new node")
    return
  end

  if self.__count == 1 or node == self.__tail then
    self:addBack(value)
    return
  end

  if self:contains(node.value) == false then
    io.write("Sorry, node not found in linked list")
    return
  end

  local current = self.__tail.previous
  local sentinel = Node.new(0)
  sentinel = self.__tail
  while current ~= nill do
    if current.value == node.value then
      if
        current.next.value == node.next.value
        and current.previous.value == node.previous.value
      then
        local newNode = Node.new(value)
        newNode.next = sentinel
        sentinel.previous = newNode
        current.next = newNode
        newNode.previous = current
        self.__count = self.__count + 1
        return
      end
    end

    sentintel = current
    current = current.previous
  end
end

-- T - O(n)
function DoublyLinkedList:addBefore(node, value)
  if node == nil then
    io.write("Passed node is nil, can not determine where to add new node")
    return
  end

  if self.__count == 1 or node == self.__head then
    self:addFront(value)
    return
  end

  if self:contains(node.value) == false then
    io.write("Sorry, node not found in linked list")
    return
  end

  local current = self.__head
  local sentinel = Node.new(0)
  sentinel.next = self.__head
  while current ~= nil do
    if current.value == node.value then
      if
        current.next.value == node.next.value
        and current.previous.value == node.previous.value
      then
        local newNode = Node.new(value)
        newNode.previous = sentinel
        current.previous = newNode
        sentinel.next = newNode
        newNode.next = current
        self.__count = self.__count + 1
        return
      end
    end

    sentinel = current
    current = current.next
  end
end

-- T - O(n), where n is the number of nodes in the Doubly Linked List
function DoublyLinkedList:removeDuplicates()
  if self.__count == 0 then
    return false
  end

  local hashset = {}
  local didRemoveNodes = false
  local current = self.__head
  local sentinel = Node.new(0)
  sentinel.next = self.__head
  while(current ~= nil) do
    if hashset[current.value] ~= nil then
      if current == self.__head then
        self.__head = current.next
      elseif current == self.__tail then
        self.__tail = current.previous
      end
      local deletedNode = current
      sentinel.next = current.next
      current = sentinel.next
      deletedNode.next = nil
      deletedNode.previous = nil
      didRemoveNodes = true
      self.__count = self.__count - 1
    else
      hashset[current.value] = current.value
      sentinel = current
      current = current.next
    end
  end

  return didRemoveNodes
end

-- T - O(n), where n is the number of nodes in the Doubly Linkded List
function DoublyLinkedList:contains(value)
  local currentFront = self.__head
  local currentBack = self.__tail

  while
    currentFront ~= nil
    and currentBack ~= nil
    and currentFront.previous ~= currentBack
    and currentBack.next ~= currentFront
  do
    if
      currentFront.value == value
      or currentBack.value == value
    then
      return true
    end

    currentFront = currentFront.next
    currentBack = currentBack.previous
  end

  return false
end

-- T - O(n), where n is the number of nodes in the Doubly Linked List
function DoublyLinkedList:reverse()
  if self.__count == 0 then
    io.write("WARNING: Cannot reverse an empty Doubly Linked List")
    return
  end

  local temp = nil
  local current = self.__head
  local oldHead = self.__head

  while current ~= nil do
    temp = current.previous
    current.previous = current.next
    current.next = temp
    current = current.previous
  end

  self.__head = temp.previous
  self.__tail = oldHead
end

-- T - O(n), where n is the number of nodes in the Doubly Linked List
function DoublyLinkedList:printList()
  local current = self.__head
  io.write("nil<-")
  while current ~= nil do
    if current.next == nil then
      io.write(string.format("%d->", current.value))
    else
      io.write(string.format("%d=", current.value))
    end

    current = current.next
  end

  io.write("nil\n")
end

-- T - O(n), where n is the number of nodes in the Doubly Linked List
function DoublyLinkedList:toArray()
  local arr = {}
  local current = self.__head
  local i = 1
  while current ~= nil do
    arr[i] = current.value
    current = current.next
    i = i + 1
  end

  return arr
end

-- Test out your code in the main function below!
local function Main()
  local dll = DoublyLinkedList.new()

end

Main()

return DoublyLinkedList
