local graphs = require("graph")
local AdjacencyList = graphs.WeightedDirectedAdjacencyList

-- T - O(VE)
-- S - O(|V|)
function bellmanFordAlgorithm(graph, source)
  local vertices = graph:count()
  local list = graph:getGraph()
  local distances = {}

  for vertex = 1, vertices do
    distances[vertex] = math.huge
  end

  distances[source] = 0

  for count = 1, vertices - 1 do
    local changed = false
    for vertex = 1, vertices do
      local current = list[vertex]:getHead()
      while current ~= nil do
        local start = current.start
        local destination = current.destination
        local cost =  current.weight
        if
          distances[start] ~= math.huge
          and distances[start] + cost < distances[destination]
        then
          distances[destination] = distances[start] + cost
          changed = true
        end

        current = current.next
      end
    end

    -- optimization, if we go through a loop without updating distances array,
    -- shortest paths and costs from source to all other vertices found
    if change == false then
      break
    end
  end

  -- we do one more loop on all edges, if a better path is found at this point
  -- then there is negatve weight cycle. Can return boolean at this point or break
  -- if you want to return the distances array with negative distances
  for vertex = 1, vertices do
    local current = list[vertex]:getHead()
    while current ~= nil do
      local start = current.start
      local destination = current.destination
      local cost = current.weight
      if
        distances[start] ~= math.huge
        and distances[start] + cost < distances[destination]
      then
        io.write("This graph has a negative weight cycle\n")
        break
      end

      current = current.next
    end
  end

  -- we can also do another loop in distances graph to check if not all
  -- vertices are visited like so
  --[[
    for vertex = 1, vertices do
      if distances[vertex] == math.huge then
        io.write("Not all vertices reached from source vertex\n")
      end
    end
  ]]

  return distances
end

-- Test out your code in the Main function below!
local function Main()
  local graph = AdjacencyList.new(6)

end

Main()
