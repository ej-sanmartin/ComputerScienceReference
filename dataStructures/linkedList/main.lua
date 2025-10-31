--[[
LinkedList.lua
Implements a singly linked list data structure following Roblox Lua Style Guide.
]]

local Node = {}
Node.__index = Node

--- Creates a new Node with the given value
-- @param value The value to store in the node
-- @return A new Node instance
function Node.new(value)
	local self = setmetatable({}, Node)

	self.value = value
	self.nextNode = nil

	return self
end

local LinkedList = {}
LinkedList.__index = LinkedList

--- Creates a new LinkedList
-- @return A new LinkedList instance
function LinkedList.new()
	local self = setmetatable({}, LinkedList)

	self.__head = nil
	self.__size = 0

	return self
end

--- Checks if the linked list is empty
-- @return boolean True if empty, false otherwise
-- T - O(1)
function LinkedList:IsEmpty()
	return self.__size == 0
end

--- Clears all elements from the linked list
-- T - O(1)
function LinkedList:Clear()
	self.__head = nil
	self.__size = 0
end

--- Gets the size of the linked list
-- @return number The number of elements in the list
-- T - O(1)
function LinkedList:GetSize()
	return self.__size
end

--- Gets the head node of the linked list
-- @return Node The head node, or nil if empty
-- T - O(1)
function LinkedList:GetHead()
	return self.__head
end

--- Peeks at the value of the head node without removing it
-- @return The value at the head, or nil if empty
-- T - O(1)
function LinkedList:Peek()
	return self.__head and self.__head.value or nil
end

--- Adds a new element to the front of the linked list
-- @param value The value to add
-- T - O(1)
function LinkedList:AddFront(value)
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

--- Adds a new element to the end of the linked list
-- @param value The value to add
-- T - O(n)
function LinkedList:AddLast(value)
	if self:IsEmpty() then
		self:AddFront(value)
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
        sentinel.nextNode = current.nextNode
        current = sentinel.nextNode
      end

      self.__size = self.__size - 1
      return true
    end

    sentinel = current
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
  if self:isEmpty() then
    io.write("WARNING: cannot remove last node of an empty linked list\n\n")
    return
  end

  if self.__head.nextNode == nil then
    self.__head = nil
    self.__size = self.__size - 1
    return
  end

  local current = self.__head
  while current.nextNode.nextNode ~= nil do
    current = current.nextNode
  end

  current.nextNode = nil
  self.__size = self.__size - 1
end

-- T - O(n)
function LinkedList:contains(value)
  if self:isEmpty() then
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
  if self:isEmpty() then
    io.write("List empty; could not find any cycles")
    return false
  end

  local slow = self.__head
  local fast = self.__head

  while fast ~= nil and fast.nextNode ~= nil  do
    slow = slow.nextNode
    fast = fast.nextNode.nextNode

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

-- T - O(n)
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

-- Test out your code in the Main function below!
local function Main()
  local ll = LinkedList.new()

end

Main()

return LinkedList
