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
  return self:findNodeMin(self.__root)
end

function BinarySearchTree:findNodeMin(node)
  if node.left == nil then
    return node
  end

  return self:findNodeMin(node.left)
end

function BinarySearchTree:findTreeMax()
  return self:findNodeMax(self.__root)
end

function BinarySearchTree:findNodeMax(node)
  if node.right == nil then
    return node
  end

  return self:findNodeMax(node.right)
end

function BinarySearchTree:insert(value)
  if self:contains(value) then
    io.write(string.format("Sorry, %d is already in tree.\nTree Cannot contain duplicates\n\n", value))
    return
  end

  self.__root = self:insertHelper(self.__root, value)
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
  return self:containsHelper(self.__root, value)
end

function BinarySearchTree:containsHelper(root, value)
  if root == nil then
    return false
  end

  if root.value == value then
    return true
  elseif root.value > value then
    return self:containsHelper(root.left, value)
  else
    return self:containsHelper(root.right, value)
  end
end

function BinarySearchTree:remove(value)
  local beforeRemoval = self:contains(value)
  self.__root = self:removeHelper(self.__root, value)
  local afterRemoval = self:contains(value)
  
  --[[
    If contains function are different before and after,
    indicates change in tree which we can infer was from deletion.
    If they are the same, then that means that deletion did
    not happen because the node was not even there to begind with.
  ]]
  if beforeRemoval ~= afterRemoval then
    self.__count = self.__count - 1
  end
end

function BinarySearchTree:removeHelper(root, value)
  if root == nil then
    return nil
  elseif root.value > value then
    root.left = self:removeHelper(root.left, value)
  elseif root.value < value then
    root.right = self:removeHelper(root.right, value)
  else
    if root.left == nil and root.right == nil then
      root = nil
    elseif root.left == nil then
      root = root.right
    elseif root.right == nil then
      root = root.left
    else
      local minimumNodeOnRight = self:findNodeMin(root.right)
      root.value = minimumNodeOnRight.value
      root.right = self:removeHelper(root.right, root.value)
    end
  end

  return root
end

-- T - O(n), where n is the number of nodes in the tree.
-- S - O(h), where space is dependent on height which effects
--           the recursive call stack
function BinarySearchTree:inorderTraversal()
  self:inorderTraversalHelper(self.__root)
  io.write("\n")
end

function BinarySearchTree:inorderTraversalHelper(root)
  if root == nil then
    return
  end
  self:inorderTraversalHelper(root.left)
  io.write(root.value .. " ")
  self:inorderTraversalHelper(root.right)
end

-- T - O(n), where n is the number of nodes in the tree.
-- S - O(h), where space is dependent on height which effects
--           the recursive call stack
function BinarySearchTree:preorderTraversal()
  self:preorderTraversalHelper(self.__root)
  io.write("\n")
end

function BinarySearchTree:preorderTraversalHelper(root)
  if root == nil then
    return
  end

  io.write(root.value .. " ")
  self:preorderTraversalHelper(root.left)
  self:preorderTraversalHelper(root.right)
end

-- T - O(n), where n is the number of nodes in the tree.
-- S - O(h), where space is dependent on height which effects
--           the recursive call stack
function BinarySearchTree:postorderTraversal()
  self:postorderTraversalHelper(self.__root)
  io.write("\n")
end

function BinarySearchTree:postorderTraversalHelper(root)
  if root == nil then
    return
  end

  self:postorderTraversalHelper(root.left)
  self:postorderTraversalHelper(root.right)
  io.write(root.value .. " ")
end

-- O(n), where n is the number of nodes in the tree
function BinarySearchTree:printTree()
  self:printTreeHelper("", self.__root)
end

function BinarySearchTree:printTreeHelper(prefix, root, isLeft)
  if root == nil then
    return
  end

  self:printTreeHelper(prefix .. "\t\t", root.right)
  print(string.format("%s %d", prefix .. "|--", root.value))
  self:printTreeHelper(prefix .. "\t\t", root.left)
end

-- Test out your code in the main function below!
local function Main()
  local tree = BinarySearchTree.new()

end

Main()

return BinarySearchTree
