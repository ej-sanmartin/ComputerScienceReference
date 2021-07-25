local Graphs = require("graph")
local PriorityQueue = require("priorityQueue")
local AdjacencyList = Graphs.WeightedDirectedAdjacencyList
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
  
  if graph:getGraph()[source] == nil then
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

local function Main()
  local graph = AdjacencyList.new(6)

end

Main()
