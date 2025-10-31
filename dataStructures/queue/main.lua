--[[
Queue.lua
Implements a queue data structure following Roblox Lua Style Guide.
]]

local Node = {}
Node.__index = Node

--- Creates a new Node with the given value
-- @param value The value to store in the node
-- @return A new Node instance
function Node.new(value)
	local self = setmetatable({}, Node)

	self.value = value
	self.next = nil

	return self
end

local Queue = {}
Queue.__index = Queue

--- Creates a new Queue
-- @return A new Queue instance
function Queue.new()
	local self = setmetatable({}, Queue)

	self.__head = nil
	self.__tail = nil
	self.__count = 0

	return self
end

--- Checks if the queue is empty
-- @return boolean True if empty, false otherwise
-- T - O(1)
function Queue:IsEmpty()
	return self.__count == 0
end

-- T - O(1)
function Queue:count()
  return self.__count
end

-- T - O(1)
function Queue:getHead()
  return self.__head
end

-- T - O(1)
function Queue:getTail()
  return self.__tail
end

-- T - O(1)
function Queue:peek()
  return self.__head.value
end

-- T - O(1), we are adding to tail in this Deque/ Queue
function Queue:enqueue(value)
  local newNode = Node.new(value)

  if self.__tail ~= nil then
    self.__tail.next = newNode
  end

  self.__tail = newNode

  if self.__count == 0 then
    self.__head = newNode
  end

  self.__count = self.__count + 1
end

-- T - O(1), we are removing from head in this Deque/ Queue
function Queue:dequeue()
  if self.__count == 0 or self.__head == nil then
    io.write("Sorry, queue is empty.\n")
    return nil
  end

  local data = self.__head.value
  self.__head = self.__head.next

  if self.__count == 1 then
    self.__tail = nil
  end

  self.__count = self.__count - 1
  return data
end

-- T - O(n)
function Queue:toArray()
  local arr = {}
  local i = 1
  local current = self.__head
  while current ~= nil do
    arr[i] = current.value
    i = i + 1
    current = current.next
  end

  return arr
end

-- Test out your code in the Main function below!
function Main()
  local queue = Queue.new()

end

Main()

return Queue
