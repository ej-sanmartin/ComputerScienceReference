local UnionFindGraph = {}
UnionFindGraph.__index = UnionFindGraph

function UnionFindGraph.new(vertices, edges)
  local self = setmetatable({}, UnionFindGraph)

  self.vertices = vertices
  self.edges = edges
  self.edge = {}

  for i = 1, edges do
    edge[i] = Edge.new()
  end

  return self
end

function UnionFindGraph:getVertices()
  return self.vertices
end

function UnionFindGraph:getEdges()
  return self.edges
end

function UnionFindGraph:getEdgeList()
  return self.edge
end

local Edge = {}
Edge.__index = Edge

function Edge.new()
  local self = setmetatable({}, Edge)

  self.source = nil
  self.destination = nil

  return self
end

local Subset = {}
Subset.__index = Subset

function Subset.new()
  local self = setmetatable({}, Subset)

  self.parent = nil
  self.rank = nil

  return self
end

function find(subsets, index)
  if subsets[index].parent ~= index then
    subsets[index].parent = find(subsets, subsets[index].parent)
  end

  return subsets[index].parent
end

function union(subsets, x, y)
  local xRoot = find(subsets, x)
  local yRoot = find(subsets, y)

  if subsets[xRoot].rank < subsets[yRoot].rank then
    subsets[xRoot].parent = yRoot
  elseif subsets[xRoot].rank > subsets[yRoot].rank then
    subsets[yRoot].parent = xRoot
  else
    subsets[xRoot].parent = yRoot
    subsets[yRoot].rank = subsets[yRoot].rank + 1
  end
end

function isCycle(graph)
  local vertices = graph:getVertices()
  local edges = graph:getEdges()
  local list = graph:getEdgeList()
  local subsets = {}

  for vertex = 1, vertices do
    subsets[vertex] = Subset.new()
    subsets[vertex].parent = vertex
    subsets[vertex].rank = 0
  end

  for edge = 1, edges do
    local x = find(subsets, list[edge].source)
    local y = find(subsets, list[edge].destination)

    if x == y then
      return true
    end

    union(subsets, x, y)
  end

  return false
end

-- Test out your code in the Main function below
local function Main()

end
