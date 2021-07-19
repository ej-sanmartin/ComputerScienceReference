local MinHeap = {}
MinHeap.__index = MinHeap

function MinHeap.new()
  local self = setmetatable({}, MinHeap)

  self.__heap = {}
  self.__size = 0

  return self
end

function MinHeap:leftChildIndex(parentIndex)
  return parentIndex * 2
end

function MinHeap:rightChildIndex(parentIndex)
  return parentIndex * 2 + 1
end

function MinHeap:parentIndex(childIndex)
  return math.floor((childIndex) / 2)
end

function MinHeap:hasLeftChild(parentIndex)
  return self:leftChildIndex(parentIndex) < self.__size
end

function MinHeap:hasRightChild(parentIndex)
  return self:rightChildIndex(parentIndex) < self.__size
end

function MinHeap:hasParent(childIndex)
  return self:parentIndex(childIndex) >= 1
end

function MinHeap:getLeftChild(parentIndex)
  return self.__heap[MinHeap:leftChildIndex(parentIndex)]
end

function MinHeap:getRightChild(parentIndex)
  return self.__heap[MinHeap:rightChildIndex(parentIndex)]
end

function MinHeap:getParent(childIndex)
  return self.__heap[self:parentIndex(childIndex)]
end

function MinHeap:isEmpty()
  return self.__size == 0
end

-- T - O(n), where n is the size of heap
function MinHeap:printMinHeapArray()
  if self.__size == 0 then
    io.write("WARNING: MinHeap is empty. Cannot print.")
    return
  end

  for i = 1, self.__size do
    if i == self.__size then
      io.write(string.format("%d\n", self.__heap[i]))
    else
      io.write(string.format("%d, ", self.__heap[i]))
    end
  end
end

function MinHeap:swap(a, b)
  local temp = self.__heap[a]
  self.__heap[a] = self.__heap[b]
  self.__heap[b] = temp
end

-- for adding into the heap, bubbling up the value
function MinHeap:heapifyUp()
  local index = self.__size

  while 
    self:hasParent(index)
    and self:getParent(index) > self.__heap[index]
  do
    local pIndex = self:parentIndex(index)
    self:swap(pIndex, index)
    index = pIndex
  end
end

-- for removing from the heap, bubbling down the value
function MinHeap:heapifyDown()
  local index = 1

  while self:hasLeftChild(index) do
    local smallestChildIndex = self:leftChildIndex(index)

    if
      self:hasRightChild(index)
      and self:getRightChild(index) < self:getLeftChild(index)
    then
      smallestChildIndex = self:rightChildIndex(index)
    end

    if self.__heap[index] < self.__heap[smallestChildIndex] then
      break
    end

    self:swap(smallestChildIndex, index)
    index = smallestChildIndex
  end
end

-- T - O(1), as it is easy to access first element of array
function MinHeap:getMin()
  return self.__heap[1]
end

-- T - O(logn), as heapifyDown traverses through half of heap
function MinHeap:extractMin()
  if self.__size == 0 then
    io.write("WARNING: Can't extract from empty heap")
    return
  end

  local value = self.__heap[1]
  self.__heap[1] = self.__heap[self.__size]
  self.__size = self.__size - 1
  self:heapifyDown()
  return value
end

-- T - O(logn), as heapifyUp traverses through half of heap
function MinHeap:insert(value)
  self.__size = self.__size + 1
  self.__heap[self.__size] = value
  self:heapifyUp()
end

-- Test out your code in the main function below!
function Main()
  local pq = MinHeap.new()
  pq:insert(5)
  print(pq:extractMin())
end

Main()

return MinHeap
