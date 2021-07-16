local Node = {}
Node.__index = Node

function Node.new(value)
  local self = setmetatable({}, Node)

  self.value = value
  self.next = nil

  return self
end

local Stack = {}
Stack.__index = Stack

function Stack.new(value)
  local self = setmetatable({}, Stack)

  self.__head = nil
  self.__size = 0

  return self
end

function Stack:count()
  return self.__size
end

function Stack:isEmpty()
  return self.__size == 0
end

function Stack:peek()
  if self.__head == nil then
    io.write("WARNING: Stack is empty. Cannot run 'peek' method\n")
    return nil
  end

  return self.__head.value
end

function Stack:pop()
  if self.__head == nil then
    io.write("WARNING: Stack is empty. Cannot return a value from 'pop' method\n")
    return nil
  end

  local data = self.__head.value
  self.__head = self.__head.next
  self.__size = self.__size - 1
  return data
end

function Stack:push(value)
  local newNode = Node.new(value)
  newNode.next = self.__head
  self.__head = newNode
  self.__size = self.__size + 1
end

function Stack:toArray()
  local arr = {}
  local i = 1
  local current = self.__head
  while current ~= nil do
    arr[i] = current.value
    current = current.next
    i = i + 1
  end

  return arr
end

-- Test out your code in the main function below!
function Main()
  local stack = Stack.new()

end

Main()
