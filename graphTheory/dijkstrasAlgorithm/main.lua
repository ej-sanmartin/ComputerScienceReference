local Graphs = require("graph")
local PriorityQueue = require("priorityQueue")
local AdjacencyList = Graphs.WeightedDirectedAdjacencyList
local AdjacencyMatrix = Graphs.WeightedDirectedAdjacencyMatrix
local MinPriorityQueue = PriorityQueue.MinPriorityQueue
local Vertex = PriorityQueue.Vertex

-- Dijkstras Algorithm with an Adjacency List and Priority Queue
-- T - O(V + ElogV)
-- S - O(V)
function dijkstrasAlgorithm(graph, source)
  local vertices = graph:count()
  local settled = {}
  local distance = {}
  local parents = {}

  for i = 1, vertices do
    distance[i] = math.huge
  end
  
  if graph:getGraph()[source] == nil or source > vertices then
    io.write("Source vertex does not exist in graph\n\n")
    return nil
  end

  local pq = MinPriorityQueue.new()
  pq:push(Vertex.new(source, 0))
  distance[source] = 0
  parents[source] = 0

  while getArrayCount(settled) ~= vertices do
    if pq:isEmpty() then
      break
    end
    
    local minimumCostNode = pq:pop()
    settled[minimumCostNode.value] = value
    local currentEdge = graph:getGraph()[minimumCostNode.value]:getHead()
    while currentEdge ~= nil do
      if settled[currentEdge.destination] == nil then
        local edgeDistance = currentEdge.weight
        local newDistance = distance[minimumCostNode.value] + edgeDistance

        if newDistance < distance[currentEdge.destination] then
          distance[currentEdge.destination] = newDistance
          parents[currentEdge.destination] = minimumCostNode.value
        end

        pq:push(Vertex.new(currentEdge.destination, distance[currentEdge.destination]))
      end

      currentEdge = currentEdge.next
    end
  end

  return distance
end

function getArrayCount(arr)
  local count = 0

  for _ in pairs(arr) do
    count = count + 1
  end

  return 0
end

function printDistances(distances)
  if distances == nil then
    return
  end

  for _, v in pairs(distances) do
    print(v)
  end
end

-- Dijkstras Algorithm with Adjacency Matrix and priority queue
-- T - O(V^2 + ElogV)
-- S - O(|V|)
function dijkstrasAlgorithmAdjacencyMatrixOptimal(graph, source)
  local vertices = graph:count()
  local matrix = graph:getGraph()
  local distances = {}
  local visited = {}
  local pq = MinPriorityQueue.new()

  for i = 1, vertices do
    visited[i] = false
    distances[i] = math.huge
  end

  visited[source] = true
  distances[source] = 0

  for i = 1, vertices do
    if visited[i] == false and matrix[source][i] ~= 0 then
      pq:push(Vertex.new(i, matrix[source][i]))
    end
  end

  while pq:count() ~= 0 do
    local minimumCostNode = pq:pop()
    if visited[minimumCostNode.value] == false then
      visited[minimumCostNode.value] = true
      distances[minimumCostNode.value] = minimumCostNode.weight
      for vertex = 1, vertices do
        if matrix[minimumCostNode.value][vertex] ~= 0 then
          local currentEdgeCost = distances[minimumCostNode.value] + matrix[minimumCostNode.value][vertex]
          if
            visited[vertex] == false
            and distances[vertex] > currentEdgeCost
          then
            pq:push(Vertex.new(vertex, currentEdgeCost))
          end
        end
      end
    end
  end

  return distances
end

-- Dijkstras Algorithm with Adjacency List and no priority queue
-- T - O(V^2)
-- S - O(|V|)
function dijkstrasAlgorithmAdjacencyListSubOptimal(graph, source)
  local vertices = graph:count()
  local adjacencyList = graph:getGraph()
  local visited = {}
  local distances = {}

  for vertex = 1, vertices do
    distances[vertex] = math.huge
    visited[vertex] = false
  end

  distances[source] = 0

  for count = 1, vertices - 1 do
    local minimumCostNode = findMinDistance(distances, visited, vertices)
    visited[minimumCostNode] = true
    local currentEdge = adjacencyList[minimumCostNode]:getHead()
    while currentEdge ~= nil do
      local edgeDistance = currentEdge.weight
      local newDistance = distances[minimumCostNode] + edgeDistance
      if newDistance < distances[currentEdge.destination] then
        distances[currentEdge.destination] = newDistance
      end

      currentEdge = currentEdge.next
    end
  end

  return distances
end


-- Dijkstras Algorithm with Adjacency Matrix and no priority queue
-- T - O(V^2)
-- S - O(|V|)
function dijkstrasAlgorithmAdjacencyMatrixSubOptimal(graph, source)
  local vertices = graph:count()
  local matrix = graph:getGraph()
  local distances = {}
  local visited = {}

  for vertex = 1, vertices do
    distances[vertex] = math.huge
    visited[vertex] = false
  end

  distances[source] = 0

  for count = 1, vertices - 1 do
    local minimumCostNode = findMinDistance(distances, visited, vertices)
    visited[minimumCostNode] = true

    for vertex = 1, vertices do
      if
        visited[vertex] == false
        and matrix[minimumCostNode][vertex] ~= 0
        and distances[minimumCostNode] ~= math.huge
        and distances[vertex] > distances[minimumCostNode] + matrix[minimumCostNode][vertex]
      then
        distances[vertex] = distances[minimumCostNode] + matrix[minimumCostNode][vertex]
      end
    end
  end

  return distances
end

function findMinDistance(distances, visited, vertices)
  local minimumCost = math.huge
  local minIndex = -1

  for vertex = 1, vertices do
    if
      visited[vertex] == false
      and distances[vertex] <= minimumCost
    then
      minimumCost = distances[vertex]
      minIndex = vertex
    end
  end

  return minIndex
end

local function Main()
  local graph = AdjacencyList.new(6)

end

Main()
