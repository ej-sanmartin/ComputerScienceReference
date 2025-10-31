--[[
Permutations.lua
Implements permutation generation algorithms for arrays and strings following Roblox Lua Style Guide.
]]

--- Generates all permutations of an array using backtracking
-- @param arr The input array to generate permutations for
-- @return A table containing all permutations of the input array
function ArrayPermutations(arr)
	local output = {}
	local arrLength = GetCount(arr)
	ArrayPermutationsHelper(arr, 1, arrLength, output)
	return output
end

--- Helper function for generating array permutations recursively
-- @param arr The array being permuted
-- @param start The starting index for this recursive call
-- @param arrLength The total length of the array
-- @param results The table to store results in
function ArrayPermutationsHelper(arr, start, arrLength, results)
	if start == arrLength then
		local currentPermutation = ShallowCopy(arr, arrLength)
		table.insert(results, currentPermutation)
	else
		for i = start, arrLength do
			Swap(i, start, arr)
			ArrayPermutationsHelper(arr, start + 1, arrLength, results)
			Swap(i, start, arr)
		end
	end
end

--- Generates all permutations of a string
-- @param s The input string to generate permutations for
-- @return A table containing all string permutations
function StringPermutations(s)
	local output = {}
	StringPermutationsHelper("", s, output)
	return output
end

--- Helper function for generating string permutations recursively
-- @param prefix The current prefix of the permutation
-- @param suffix The remaining suffix to permute
-- @param list The table to store results in
function StringPermutationsHelper(prefix, suffix, list)
	if #suffix == 0 then
		table.insert(list, prefix)
	else
		for i = 1, #suffix do
			local newPrefix = prefix .. string.sub(suffix, i, i)
			local newSuffix = string.sub(suffix, 1, i - 1) .. string.sub(suffix, i + 1, #suffix)
			StringPermutationsHelper(newPrefix, newSuffix, list)
		end
	end
end

--- Creates a shallow copy of an array up to a specified length
-- @param arr The array to copy
-- @param arrLength The length to copy
-- @return A new array containing the copied elements
function ShallowCopy(arr, arrLength)
	local newArr = {}

	for i = 1, arrLength do
		newArr[i] = arr[i]
	end

	return newArr
end

--- Swaps two elements in an array
-- @param a The index of the first element
-- @param b The index of the second element
-- @param arr The array containing the elements to swap
function Swap(a, b, arr)
	local temp = arr[a]
  arr[a] = arr[b]
  arr[b] = temp
end

function getCount(arr)
  local count = 0

  for _ in pairs(arr) do
    count = count + 1
  end

  return count
end

-- Test your code in the Main function below!
local function Main()
  local testString = "abc"
  local stringResult = stringPermutations(testString)

  local testArr = {1, 2, 3}
  local arrayResult = arrayPermutations(testArr)

  for _k, v in pairs(stringResult) do
    print(v)
  end

  print()

  for _k, v in pairs(arrayResult) do
    for i = 1, #v do
      io.write(string.format("%d, ", v[i]))
    end
    print()
  end

end

Main()
