-- Non-Balancing, Binary Search Tree
--[[
  Time and Space Complexity of common data strcuture
  methods - Insert, Find, and Delete, are O(h), where
  h is the height of the tree.
  
  In the case where the tree is unbalanced, worst case
  can devolved to O(n) time as the tree could be heavily
  skewed.

  In the case where the tree is balanced, then the time
  complexity of these methods will be O(logn).

  In other files we will implement different techniques
  to ensure that the tree is on average balanced.
]]

local Node = {}
Node.__index = Node

function Node.new(value)
  local self = setmetatable({}, Node)

  self.value = value
  self.left = nil
  self.right = nil

  return self
end

local BinarySearchTree = {}
BinarySearchTree.__index = BinarySearchTree

function BinarySearchTree.new()
  local self = setmetatable({}, BinarySearchTree)

  self.__root = nil
  self.__count = 0

  return self
end

function BinarySearchTree:getRoot()
  return self.__root
end

function BinarySearchTree:count()
  return self.__count
end

function BinarySearchTree:clear()
  self.__root = nil
  self.__count = 0
end

function BinarySearchTree:findTreeMin()
  return BinarySearchTree:findNodeMin(self.__root)
end

function BinarySearchTree:findNodeMin(node)
  if node.left == nil then
    return node
  end

  return BinarySearchTree:findNodeMin(node.left)
end

function BinarySearchTree:findTreeMax()
  return BinarySearchTree:findNodeMax(self.__root)
end

function BinarySearchTree:findNodeMax(node)
  if node.right == nil then
    return node
  end

  return BinarySearchTree:findNodeMax(node.right)
end

function BinarySearchTree:insert(value)
  if self:contains(value) then
    io.write(string.format("Sorry, %d is already in tree.\nTree Cannot contain duplicates\n\n", value))
    return
  end

  self.__root = BinarySearchTree:insertHelper(self.__root, value)
  self.__count = self.__count + 1
end

function BinarySearchTree:insertHelper(root, value)
  if root == nil then
    root = Node.new(value)
    return root
  end

  if root.value > value then
    root.left = BinarySearchTree:insertHelper(root.left, value)
  else
    root.right = BinarySearchTree:insertHelper(root.right, value)
  end

  return root
end 

function BinarySearchTree:contains(value)
  return BinarySearchTree:containsHelper(self.__root, value)
end

function BinarySearchTree:containsHelper(root, value)
  if root == nil then
    return false
  end

  if root.value == value then
    return true
  elseif root.value > value then
    return BinarySearchTree:containsHelper(root.left, value)
  else
    return BinarySearchTree:containsHelper(root.right, value)
  end
end

function BinarySearchTree:remove(value)
  local beforeRemoval = self:contains(value)
  self.__root = BinarySearchTree:removeHelper(self.__root, value)
  local afterRemoval = self:contains(value)
  
  --[[
    If contains outputs are different before and after this method,
    indicates change in tree which we can infer was from deletion.
    If the outputs are the same, then we can infer that deletion did
    not happen because the node was not even there to begind with.
  
    Need to know this to accurately update count of tree
  ]]
  if beforeRemoval ~= afterRemoval then
    self.__count = self.__count - 1
  end
end

function BinarySearchTree:removeHelper(root, value)
  if root == nil then
    return nil
  elseif root.value > value then
    root.left = BinarySearchTree:removeHelper(root.left, value)
  elseif root.value < value then
    root.right = BinarySearchTree:removeHelper(root.right, value)
  else
    if root.left == nil and root.right == nil then
      root = nil
    elseif root.left == nil then
      root = root.right
    elseif root.right == nil then
      root = root.left
    else
      local minimumNodeOnRight = BinarySearchTree:findNodeMin(root.right)
      root.value = minimumNodeOnRight.value
      root.right = BinarySearchTree:removeHelper(root.right, root.value)
    end
  end

  return root
end

-- T - O(n), where n is the number of nodes in the tree.
-- S - O(h), where space is dependent on height which effects
--           the recursive call stack
function BinarySearchTree:inorderTraversal()
  BinarySearchTree:inorderTraversalHelper(self.__root)
  io.write("\n")
end

function BinarySearchTree:inorderTraversalHelper(root)
  if root == nil then
    return
  end
  BinarySearchTree:inorderTraversalHelper(root.left)
  io.write(root.value .. " ")
  BinarySearchTree:inorderTraversalHelper(root.right)
end

-- T - O(n), where n is the number of nodes in the tree.
-- S - O(h), where space is dependent on height which effects
--           the recursive call stack
function BinarySearchTree:preorderTraversal()
  BinarySearchTree:preorderTraversalHelper(self.__root)
  io.write("\n")
end

function BinarySearchTree:preorderTraversalHelper(root)
  if root == nil then
    return
  end

  io.write(root.value .. " ")
  BinarySearchTree:preorderTraversalHelper(root.left)
  BinarySearchTree:preorderTraversalHelper(root.right)
end

-- T - O(n), where n is the number of nodes in the tree.
-- S - O(h), where space is dependent on height which effects
--           the recursive call stack
function BinarySearchTree:postorderTraversal()
  BinarySearchTree:postorderTraversalHelper(self.__root)
  io.write("\n")
end

function BinarySearchTree:postorderTraversalHelper(root)
  if root == nil then
    return
  end

  BinarySearchTree:postorderTraversalHelper(root.left)
  BinarySearchTree:postorderTraversalHelper(root.right)
  io.write(root.value .. " ")
end

-- O(n), where n is the number of nodes in the tree
function BinarySearchTree:printTree()
  BinarySearchTree:printTreeHelper("", self.__root)
end

function BinarySearchTree:printTreeHelper(prefix, root)
  if root == nil then
    return
  end

  BinarySearchTree:printTreeHelper(prefix .. "\t\t", root.right)
  print(string.format("%s %d", prefix .. "|--", root.value))
  BinarySearchTree:printTreeHelper(prefix .. "\t\t", root.left)
end

-- Test out your code in the main function below!
local function Main()
  local tree = BinarySearchTree.new()
  
end

Main()
