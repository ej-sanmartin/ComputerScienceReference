--[[
  keep in mind that building a Trie is O(l * w), where we must run the
  insert function w amount of times, w being the number of words to insert
]]

local Node = {}
Node.__index = Node

function Node.new()
  local self = setmetatable({}, Node)

  self.children = {}
  self.isEndWord = false

  return self
end

local Trie = {}
Trie.__index = Trie

function Trie.new()
  local self = setmetatable({}, Trie)

  self.__root = Node.new()

  return self
end

-- T - O(l), where l is the length of the word to be inserted
function Trie:insert(word)
  word = string.lower(word)
  self:insertHelper(self.__root, word, 1)
end

function Trie:insertHelper(root, word, index)
  if index == #word + 1 then
    root.isEndWord = true
    return
  end

  local c = string.sub(word, index, index)
  if root.children[c] == nil then
    node = Node.new()
    root.children[c] = node
  end

  self:insertHelper(root.children[c], word, index + 1)
end

-- T - O(l), where l is the length of the word to be searched
function Trie:find(word)
  word = string.lower(word)
  return self:findHelper(self.__root, word, 1)
end

function Trie:findHelper(root, word, index)
  if index == #word + 1 then
    return root.isEndWord
  end

  local c = string.sub(word, index, index)
  if root.children[c] == nil then
    return false
  end

  return self:findHelper(root.children[c], word, index + 1)
end

-- T - O(l), where l is the length of the word to be deleted
function Trie:delete(word)
  word = string.lower(word)
  self:deleteHelper(self.__root, word, 1)
end

function Trie:deleteHelper(root, word, index)
  if index == #word + 1 then
    if root.isEndWord == false then
      return false
    end

    root.isEndWord = false
    local count = Trie:childrenCount(root.children)
    return count == 0
  end

  local c = string.sub(word, index, index)
  if root.children[c] == nil then
    return false
  end

  local shouldDeleteCurrentWord = self:deleteHelper(root.children[c], word, index + 1)

  if shouldDeleteCurrentWord then
    table.remove(root.children, c)
    local count = Trie.childrenCount(root.children)
    return count == 0;
  end

  return false
end

-- helper function to count how many KVP entries in children
function Trie:childrenCount(children)
  local count

  for _ in pairs(children) do
    count = count + 1
  end

  return count
end

-- Test out your code in the main function below!
function Main()
  local trie = Trie.new()

end

Main()
