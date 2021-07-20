--[[
  Edges kept tracked via Linked List. Refer to Linked List file
  for implementation details
]]
local linkedList = require("linkedlist")

-- Non weighted, undirected graph representation
-- To have weighted graph, need to update Node class to have weighted values
local AdjacencyListGraph = {}
AdjacencyListGraph.__index = AdjacencyListGraph

function AdjacencyListGraph.new()
  local self = setmetatable({}, AdjacencyListGraph)

  self.__vertexList = {}
  self.__adjacencyList = {}
  self.__count = 0

  return self
end

function AdjacencyListGraph:count()
  return self.__count
end

function AdjacencyListGraph:getVertices()
  return self.__vertexList
end

function AdjacencyListGraph:getGraph()
  return self.__adjacencyList
end

function AdjacencyListGraph:addVertex(value)
  self.__count = self.__count + 1
  local edges = linkedList.new()
  self.__vertexList[self.__count] = value
  self.__adjacencyList[value] = edges

  return edges
end

function AdjacencyListGraph:addEdge(start, destination)
  local startVertex = self.__adjacencyList[start]
  local destinationVertex = self.__adjacencyList[destination]

  if startVertex == nil then
    io.write("Cannot find starting vertex, cannot add to graph\n")
    return
  end

  if destinationVertex == nil then
    destinationVertex = self:addVertex(destination)
  end

  if
    startVertex:contains(destination)
    or destinationVertex:contains(start)
  then
    io.write("Edge already exists\n\n")
    return
  end

  startVertex:addFront(destination)
  destinationVertex:addFront(start) -- remove this line to make graph directed
end

function AdjacencyListGraph:removeEdge(start, destination)
  local startVertex = self.__adjacencyList[start]
  local destinationVertex = self.__adjacencyList[destination]

  if startVertex == nil then
    io.write("Cannot find starting vertex, cannot remove from graph\n")
    return
  end

  if destinationVertex == nil then
    io.write("Cannot find ending vertex, cannot remove from graph\n")
    return
  end

  if startVertex:removeAValue(destination) == false then
    io.write("Destination vertex not found in start vertex\n")
  end

  -- remove this if block to make graph directed
  if destinationVertex:removeAValue(start) == false then
    io.write("Start vertex not found in destination vertex\n")
  end
end

function AdjacencyListGraph:printGraph()
  for vertex = 1, self.__count do
    io.write(string.format("Edges of vertex %d\n", self.__vertexList[vertex]))
    local edges = self.__adjacencyList[self.__vertexList[vertex]]
    edges:printLinkedList()
    io.write("\n\n")
  end
  io.write("\n")
end

-- Non weighted, undirected graph implementation
local AdjacencyMatrixGraph = {}
AdjacencyMatrixGraph.__index = AdjacencyMatrixGraph

function AdjacencyMatrixGraph.new(vertices)
  if vertices <= 0 then
    io.write("Matrix cannot have 0 or negative vertices")
    return nil
  end

  local self = setmetatable({}, AdjacencyMatrixGraph)

  self.__vertices = vertices
  self.__adjacencyMatrix = {}
  for row = 1, vertices do
    self.__adjacencyMatrix[row] = {}
    for column = 1, vertices do
      self.__adjacencyMatrix[row][column] = 0
    end
  end

  return self
end

function AdjacencyMatrixGraph:count()
  return self.__vertices
end

function AdjacencyMatrixGraph:getGraph()
  return self.__adjacencyMatrix
end

function AdjacencyMatrixGraph:addEdge(start, destination)
  if 
    start > self.__vertices
    or destination > self.__vertices
  then
    io.write("ERROR: One or both vertices do not exist\n\n")
    return
  end

  self.__adjacencyMatrix[start][destination] = 1
  self.__adjacencyMatrix[destination][start] = 1 -- remove this line to make graph directed
end

function AdjacencyMatrixGraph:removeEdge(start, destination)
  if 
    start > self.__vertices
    or destination > self.__vertices
  then
    io.write("ERROR: One or both vertices do not exist\n\n")
    return
  end

  self.__adjacencyMatrix[start][destination] = 0
  self.__adjacencyMatrix[destination][start] = 0 -- remove this line to make graph directed
end

function AdjacencyMatrixGraph:printGraph()
  for row = 1, self.__vertices do
    for column = 1, self.__vertices do
      io.write(string.format("%d ", self.__adjacencyMatrix[row][column]))
    end
    io.write("\n")
  end
  io.write("\n")
end

-- Test out your code in the Main function below
local function Main()
  local graph = AdjacencyListGraph.new()
  --local matrix = AdjacencyMatrixGraph.new(--[[pass number of vertices here]])

end

Main()

return {
  AdjacencyListGraph = AdjacencyListGraph,
  AdjacencyMatrixGraph = AdjacencyMatrixGraph
}
