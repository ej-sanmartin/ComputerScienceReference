--[[
  Time Complexity
  -------------------------------
  Build Heap: O(n)
  GetMin / GetMax / Peek: O(1)
  Heapify: O(logn)
  Insert: O(logn)
  Contains: O(n)
  Increase/ Decrease Key: O(logn)
]]

local Vertex = {}
Vertex.__index = Vertex

function Vertex.new(value, weight)
  local self = setmetatable({}, Vertex)

  self.value = value
  self.weight = weight

  return self
end

-- can modify, but these will be specific for use with weighted graphs
local MinPriorityQueue = {}
MinPriorityQueue.__index = MinPriorityQueue

function MinPriorityQueue.new()
  local self = setmetatable({}, MinPriorityQueue)

  self.__size = 0
  self.__heap = {}
  self.__itemIndexes = {}

  return self
end

function MinPriorityQueue:count()
  return self.__size
end

function MinPriorityQueue:isEmpty()
  return self.__size == 0
end

function MinPriorityQueue:clear()
  self.__size = 0;
  self.__heap = {}
  self.__itemIndexes = {}
end

function MinPriorityQueue:swap(a, b)
  local temp = self.__heap[a]
  self.__heap[a] = self.__heap[b]
  self.__heap[b] = temp
  self.__itemIndexes[self.__heap[a].value] = a
  self.__itemIndexes[self.__heap[b].value] = b
end

function MinPriorityQueue:heapify(index)
  local left = self:leftChildIndex(index)
  local right = self:rightChildIndex(index)
  local smallest = index

  if
    left <= self.__size
    and self.__heap[left].weight < self.__heap[smallest].weight
  then
    smallest = left
  end

  if
    right <= self.__size
    and self.__heap[right].weight < self.__heap[smallest].weight
  then
    smallest = right
  end

  if smallest ~= index then
    self:swap(index, smallest)
    self:heapify(smallest)
  end
end

function MinPriorityQueue:parentIndex(index)
  return math.floor(index / 2)
end

function MinPriorityQueue:leftChildIndex(index)
  return index * 2
end

function MinPriorityQueue:rightChildIndex(index)
  return index * 2 + 1
end

function MinPriorityQueue:peek()
  return self.__heap[1]
end

function MinPriorityQueue:pop()
  if self.__size == 0 then
    io.write("Priority Queue is empty, returning nil\n")
    return nil
  end

  self.__itemIndexes[self.__heap[1].value] = nil
  local data = self.__heap[1]
  self.__heap[1] = self.__heap[self.__size]
  self.__itemIndexes[self.__heap[1].value] = 1
  self:heapify(1)
  self.__heap[self.__size] = nil
  self.__size = self.__size - 1
  return data
end

function MinPriorityQueue:push(item)
  if self:contains(item) then
    self:changeKeyValue(item.value, item.weight)
    return
  end

  self.__size = self.__size + 1
  local current = self.__size
  self.__heap[current] = item
  self.__itemIndexes[item.value] = current

  while
    current ~= 1
    and self.__heap[current].weight < self.__heap[self:parentIndex(current)].weight
  do
    self:swap(current, self:parentIndex(current))
    current = self:parentIndex(current)
  end
end

-- where 'key' in this context is the weight
function MinPriorityQueue:increaseKey(index, newKey)
  self.__heap[index].weight = newKey
  self:heapify(index)
end

function MinPriorityQueue:decreaseKey(index, newKey)
  self.__heap[index].weight = newKey
  while
    index ~= 1
    and self.__heap[index].weight < self.__heap[self:parentIndex(index)].weight
  do
    self:swap(index, self:parentIndex(index))
    index = self:parentIndex(index)
  end
end

function MinPriorityQueue:changeKeyValue(item, newKey)
  local index = self.__itemIndexes[item]
  if index == nil then
    io.write("Item not found in heap\n")
    return
  end

  if self.__heap[index].weight == newKey then
    return
  elseif self.__heap[index].weight < newKey then
    self:increaseKey(index, newKey)
  else
    self:decreaseKey(index, newKey)
  end
end

function MinPriorityQueue:contains(item)
  for k, v in pairs(self.__heap) do
    if v.value == item.value then
      return true
    end
  end

  return false
end

local MaxPriorityQueue = {}
MaxPriorityQueue.__index = MaxPriorityQueue

function MaxPriorityQueue.new()
  local self = setmetatable({}, MaxPriorityQueue)

  self.__size = 0
  self.__heap = {}
  self.__itemIndexes = {}

  return self
end

function MaxPriorityQueue:count()
  return self.__size
end

function MaxPriorityQueue:isEmpty()
  return self.__size == 0
end

function MaxPriorityQueue:clear()
  self.__size = 0;
  self.__heap = {}
  self.__itemIndexes = {}
end

function MaxPriorityQueue:swap(a, b)
  local temp = self.__heap[a]
  self.__heap[a] = self.__heap[b]
  self.__heap[b] = temp
  self.__itemIndexes[self.__heap[a].value] = a
  self.__itemIndexes[self.__heap[b].value] = b
end

function MaxPriorityQueue:heapify(index)
  local left = self:leftChildIndex(index)
  local right = self:rightChildIndex(index)
  local largest = index

  if
    left <= self.__size
    and self.__heap[left].weight > self.__heap[largest].weight
  then
    largest = left
  end

  if
    right <= self.__size
    and self.__heap[right].weight > self.__heap[largest].weight
  then
    largest = right
  end

  if largest ~= index then
    self:swap(index, largest)
    self:heapify(largest)
  end
end

function MaxPriorityQueue:parentIndex(index)
  return math.floor(index / 2)
end

function MaxPriorityQueue:leftChildIndex(index)
  return index * 2
end

function MaxPriorityQueue:rightChildIndex(index)
  return index * 2 + 1
end

function MaxPriorityQueue:peek()
  return self.__heap[1]
end

function MaxPriorityQueue:pop()
  if self.__size == 0 then
    io.write("Priority Queue is is empty, returning nil")
    return nil
  end

  self.__itemIndexes[self.__heap[1].value] = nil
  local data = self.__heap[1]
  self.__heap[1] = self.__heap[self.__size]
  self.__itemIndexes[self.__heap[1].value] = 1
  self:heapify(1)
  self.__heap[self.__size] = nil
  self.__size = self.__size - 1
  return data
end

function MaxPriorityQueue:push(item)
  if self:contains(item) then
    self:changeKeyValue(item.value, item.weight)
    return
  end

  self.__size = self.__size + 1
  local current = self.__size
  self.__heap[current] = item
  self.__itemIndexes[item.value] = current

  while
    current <= 1
    and self.__heap[current].weight < self.__heap[self:parentIndex(current)].weight
  do
    self:swap(current, self:parentIndex(current))
    current = self:parentIndex(current)
  end
end

-- where 'key' in this context is the weight
function MaxPriorityQueue:increaseKey(index, newKey)
  self.__heap[index].weight = newKey
  self:heapify(index)
end

function MaxPriorityQueue:decreaseKey(index, newKey)
  self.__heap[index].weight = newKey
  while
    index <= 1
    and self.__heap[index].weight > self.__heap[self:parentIndex(index)].weight
  do
    self:swap(index, self:parentIndex(index))
    index = self:parentIndex(index)
  end
end

function MaxPriorityQueue:changeKeyValue(item, newKey)
  local index = self.__itemIndexes[item]
  if index == nil then
    io.write("Item not found in heap")
    return
  end

  if self.__heap[index].weight == newKey then
    return
  elseif self.__heap[index].weight < newKey then
    self:increaseKey(index, newKey)
  else
    self:decreaseKey(index, newKey)
  end
end

function MaxPriorityQueue:contains(item)
  for k, v in pairs(self.__heap) do
    if v.value == item.value then
      return true
    end
  end

  return false
end

-- Try out your code in the Main function below!
local function Main()
  local minPQ = MinPriorityQueue.new()
  local maxPQ = MaxPriorityQueue.new()

end

Main()

return {
  Vertex = Vertex,
  MinPriorityQueue = MinPriorityQueue,
  MaxPriorityQueue = MaxPriorityQueue
}
