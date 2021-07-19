local queue = require("queue")
local binarySearchTree = require("binarysearchtree")
local graph = require("graph")
local adjacencyList = graph.AdjacencyListGraph
local adjacencyMatrix = graph.AdjacencyMatrixGraph

-- BFS on a tree
-- T - O(n)
function printLevelOrderTree(tree)
  if tree == nil then
    io.write("WARNING: Tree passed is null\n")
    return
  end

  local q = queue.new()
  q:enqueue(tree)

  while q:count() ~= 0 do
    local current = q:dequeue()
    io.write(string.format("%d ", current.value))

    if current.left ~= nil then
      q:enqueue(current.left)
    end

    if current.right ~= nil then
      q:enqueue(current.right)
    end
  end
end

-- BFS on a tree, returns list of size levels
function treeToLevelOrderList(tree)
  local list = {}
  if tree == nil then
    return list
  end

  local q = queue.new()
  local level = 0
  local levelSize = 0
  local current
  q:enqueue(tree)

  while q:count() ~= 0 do
    level = level + 1
    levelSize = q:count()
    local currentLevel = {}
    io.write(string.format("Level: %d\n", level))

    for i = 1, levelSize do
      current = q:dequeue()
      currentLevel[i] = current.value
      io.write(string.format("%d ", current.value))

      if current.left ~= nil then
        q:enqueue(current.left)
      end

      if current.right ~= nil then
        q:enqueue(current.right)
      end
    end

    io.write("\n\n")
    list[level] = currentLevel
  end

  return list
end

-- BFS on a Graph represented as an adjacency list
-- T - O(|V| + |E|)
function printBFSOnAdjacencyList(graph, start)
  if start > graph:count() then
    io.write("WARNING: Start Vertex does not exist\n\n")
    return
  end

  local q = queue.new()
  local visited = {}
  for i = 1, graph:count() do
    visited[graph:getVertices()[i]] = false
  end

  local vertex
  local current
  visited[start] = true
  q:enqueue(start)

  while q:count() ~= 0 do
    vertex = q:dequeue()
    io.write(string.format("%d ", vertex))
    current = graph:getGraph()[vertex]:getHead()
    while current ~= nil do
      if visited[current.value] == false then
        visited[current.value] = true
        q:enqueue(current.value)
      end

      current = current.nextNode
    end
  end

  io.write("\n\n")
end

-- BFS on a graph represented as an adjacency matrix
-- T - O(V^2)
function printBFSOnAdjacencyMatrix(graph, start)
  if start > graph:count() then
    io.write("WARNING: Start vertex does not exist\n\n")
  end

  local vertices = graph:count()
  local matrix = graph:getGraph()
  local q = queue.new()
  local visited = {}
  for i = 1, vertices do
    visited[i] = false
  end

  local vertex
  visited[start] = true
  q:enqueue(start)

  while q:count() ~= 0 do
    vertex = q:dequeue()
    io.write(string.format("%d ", vertex))

    for i = 1, vertices do
      if
        matrix[vertex][i] == 1
        and visited[i] == false
      then
        visited[i] = true
        q:enqueue(i)
      end
    end
  end

  io.write("\n\n")
end

-- Test your code in the Main function below!
local function Main()
  local graph = adjacencyList.new()
  local matrix = adjacencyMatrix.new(3)
  local tree = binarySearchTree.new()

end

Main()
