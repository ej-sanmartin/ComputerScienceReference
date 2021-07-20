local stack = require("stack")
local bst = require("binarysearchtree")
local graph = require("graph")
local adjacencyList = graph.AdjacencyListGraph
local adjacencyMatrix = graph.AdjacencyMatrixGraph

-- specifically, iterative inorder traversal
-- T - O(n)
-- S - (h), depends on if the binary tree is balanced
function iterativeDFSOnBinaryTree(root)
  if root:count() < 1 then
    io.write("ERROR: cannot run iterative DFS on an empty tree\n\n")
    return
  end

  local s = stack.new()
  local current = root:getRoot()

  while s:count() > 0 or current ~= nil do
    if current ~= nil then
      s:push(current)
      current = current.left
    else
      current = s:pop()
      io.write(string.format("%d ", current.value))
      current = current.right
    end
  end
end

-- T - O(|V| + |E|)
-- S - O(|V|)
function iterativeDFSOnAdjacencyList(graph, start)
  local vertices = graph:count()
  if vertices == 0 then
    io.write("ERROR: cannot run iterative DFS on an empty adjacency list\n\n")
    return
  end

  if graph:getGraph()[start] == nil then
    io.write("ERROR: start vertex does not exist in adjacency list\n\n")
    return
  end

  local s = stack.new()
  local seen = {}
  for i = 1, vertices do
    seen[i] = false
  end

  local vertex
  local current
  s:push(start)

  while s:count() ~= 0 do
    vertex = s:pop()
    if seen[vertex] == false then
      seen[vertex] = true
      io.write(string.format("%d ", vertex))
    end

    current = graph:getGraph()[vertex]:getHead()

    while current ~= nil do
      if seen[current.value] == false then
        s:push(current.value)
      end

      current = current.nextNode
    end
  end
end

-- T - O(|V| + |E|)
-- S - O(h)
function recursiveDFSOnAdjacencyList(graph, start)
  local vertices = graph:count()

  if vertices == 0 then
    io.write("ERROR: cannot run iterative DFS on an empty adjacency list\n\n")
    return
  end

  if graph:getGraph()[start] == nil then
    io.write("ERROR: start vertex does not exist in adjacency list\n\n")
    return
  end

  local graphList = graph:getGraph()
  local visited = {}
  for i = 1, vertices do
    visited[i] = false
  end
  recursiveDFSOnAdjacencyListHelper(start, visited, graphList)
end

function recursiveDFSOnAdjacencyListHelper(vertex, visited, graph)
  visited[vertex] = true
  io.write(string.format("%d ", vertex))

  local current = graph[vertex]:getHead()
  while current ~= nil do
    if visited[current.value] == false then
      recursiveDFSOnAdjacencyListHelper(current.value, visited, graph)
    end

    current = current.nextNode
  end
end

-- T - O(|V|^2)
-- S - O(|V|^2)
function iterativeDFSOnAdjacencyMatrix(graph, start)
  local vertices = graph:count()
  if start > vertices then
    io.write("ERROR: Start vertex does not exist in this graph\n\n")
    return
  end

  local matrix = graph:getGraph()
  local s = stack.new()
  local visited = {}
  for i = 1, vertices do
    visited[i] = false
  end

  local vertex
  s:push(start)

  while s:count() ~= 0 do
    vertex = s:pop()
    if visited[vertex] == false then
      visited[vertex] = true
      io.write(string.format("%d ", vertex))
    end

    for i = 1, vertices do
      if
        matrix[vertex][i] == 1
        and visited[i] == false
      then
        s:push(i)
      end
    end
  end
end

-- T - O(|V|^2)
-- T - O(h)
function recursiveDFSOnAdjacencyMatrix(graph, start)
  local vertices = graph:count()
  if start > vertices then
    io.write("ERROR: Start vertex does not exist in this matrix\n\n")
    return
  end

  local matrix = graph:getGraph()
  local visited = {}
  for i = 1, vertices do
    visited[i] = false
  end
  
  recursiveDFSOnAdjacencyMatrixHelper(matrix, start, visited, vertices)
  io.write("\n\n")
end

function recursiveDFSOnAdjacencyMatrixHelper(matrix, vertex, visited, vertices)
  io.write(string.format("%d ", vertex))
  visited[vertex] = true
  for i = 1, vertices do
    if
      matrix[vertex][i] == 1
      and visited[i] == false
    then
      recursiveDFSOnAdjacencyMatrixHelper(matrix, i, visited, vertices)
    end
  end
end

-- Test your code in the Main function below!
local function Main()
  local tree = bst:new()
  local matrix = adjacencyMatrix.new(4)
  local graphList = adjacencyList.new()
  
end

Main()
