local Node = {}
Node.__index = Node

function Node.new(value)
  local self = setmetatable({}, Node)

  self.value = value
  self.nextNode = nill

  return self
end

local LinkedList = {}
LinkedList.__index = LinkedList

function LinkedList.new()
  local self = setmetatable({}, LinkedList)

  self.__head = nil
  self.__size = 0

  return self
end

-- T - O(1)
function LinkedList:isEmpty()
  return self.__size == 0
end

-- T - O(1)
function LinkedList:clear()
  self.__head = nil
  self.__size = 0
end

-- T - O(1)
function LinkedList:getSize()
  return self.__size
end

-- T - O(1)
function LinkedList:getHead()
  return self.__head
end

-- T - O(1)
function LinkedList:peak()
  return self.__head.value
end

-- T - O(1)
function LinkedList:addFront(value)
  local newNode = Node.new(value)

  if self.__head == nil then
    self.__head = newNode
    self.__size = self.__size + 1
    return
  end

  newNode.nextNode = self.__head
  self.__head = newNode
  self.__size = self.__size + 1
end

-- T - O(n)
function LinkedList:addLast(value)
  if LinkedList:isEmpty() then
    LinkedList:addFront(value)
    return
  end

  local current = self.__head

  while current.nextNode ~= nil do
    current = current.nextNode
  end

  current.nextNode = Node.new(value)
  self.__size = self.__size + 1
end

-- T - O(1)
function LinkedList:pop()
  local data = self:getHead().value
  self.__head = self.__head.nextNode
  self.__size = self.__size - 1
  return data
end

-- T - O(n)
function LinkedList:removeAValue(value)
  local current = self.__head
  local sentinel = Node.new(0)
  sentinel.nextNode = self.__head

  while current ~= nil do
    if current.value == value then
      if(current == self.__head) then
        self.__head = current.nextNode
      else
        seninel.nextNode = current.nextNode
        current = sentinel.nextNode
      end

      self.__size = self.__size - 1
      return true
    end

    seninel = current
    current = current.nextNode
  end

  return false
end

-- T - O(n)
function LinkedList:removeAllValue(value)
  local current = self.__head
  local sentinel = Node.new(0)
  sentinel.nextNode = self.__head

  while current ~= nil do
    if current.value == value then
      if current == self.__head then
        self.__head = current.nextNode
      end
      sentinel.nextNode = current.nextNode
      current = sentinel.nextNode
      self.__size = self.__size - 1
    else
      sentinel = current
      current = current.nextNode
    end
  end
end

-- T - O(n)
function LinkedList:removeLast()
  local current = self.__head

  while current ~= nil do
    if current.nextNode == nil then
      if current == self.__head then
        self.__head = nil
      else
        current = nil
      end

      self.__size = self.__size - 1
      return
    end

    current = current.nextNode
  end

  io.write("WARNING: cannot remove last node of an empty linked list\n\n")
end

-- T - O(n)
function LinkedList:contains(value)
  if LinkedList:isEmpty() then
    return false
  end

  local current = self.__head

  while current ~= nil do
    if current.value == value then
      return true
    end

    current = current.nextNode
  end

  return false
end

--[[
  T - O(n)
  Not really functional in this class because of how the
  LinkedList is constructed.
  Would be the lua implementation of this algorithm though.
]]
function LinkedList:containsCycle()
  if LinkedList:isEmpty() then
    io.write("List empty; could not find any cycles")
    return false
  end

  local slow = self.__head
  local fast = self.__head

  while fast ~= nil and fast.nextNode ~= nil  do
    slow = slow.nextNode
    fast = fast.nextNode.newNode

    if slow == fast then
      return true
    end
  end

  return false
end

-- T - O(n)
function LinkedList:reverse()
  local previous = nil
  local current = self.__head
  local after = nil

  while current ~= nil do
    after = current.nextNode
    current.nextNode = previous
    previous = current
    current = after
  end

  self.__head = previous
end

-- T O(n)
function LinkedList:printLinkedList()
  local current = self.__head

  while current ~= nil do
    io.write(string.format("(%d)->", current.value))
    current = current.nextNode
  end
  
  io.write("nil")
end

-- T - O(n)
function LinkedList:toArray()
  local arr = {}
  local index = 1
  local current = self.__head

  while current ~= nil do
    arr[index] = current.value
    index = index + 1
    current = current.nextNode
  end

  return arr
end

-- Test out your code within Main function
local function Main()
  local linkedList = LinkedList:new()
end

Main()
