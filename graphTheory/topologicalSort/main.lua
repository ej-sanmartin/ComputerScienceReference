local stack = require("stack")
local graph = require("graph")
local AdjacencyList = graph.AdjacencyListGraph

-- T - O(V + E)
-- S - O(|V|)
function TopologicalSort(graph)
  local vertices = graph:count()
  local path = stack.new()
  local visited = {}

  for vertex = 1, vertices do
    visited[vertex] = false
  end

  for vertex = 1, vertices do
    if visited[vertex] == false then
      TopologicalSortHelper(vertex, vertices, visited, path, graph)
    end
  end

  -- at this point, path stack has topologically sorted graph
  while path:peek() ~= nil do
    print(path:pop())
  end
end

function TopologicalSortHelper(vertex, vertices, visited, path, graph)
  visited[vertex] = true

  local adjacent = graph:getGraph()[vertex]:getHead()
  while adjacent ~= nil do
    if visited[adjacent.value] == false then
      TopologicalSortHelper(adjacent.value, vertices, visited, path, graph)
    end

    adjacent = adjacent.nextNode
  end

  path:push(vertex)
end

-- Test out your code in the Main function below!
local function Main()

end

Main()
