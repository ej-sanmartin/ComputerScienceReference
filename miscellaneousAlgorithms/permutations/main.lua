function arrayPermutations(arr)
  local output = {}
  local arrLength = getCount(arr)
  arrayPermutationsHelper(arr, 1, arrLength, output)
  return output
end

function arrayPermutationsHelper(arr, start, arrLength, results)
  if start == arrLength then
    local currentPermutation = shallowCopy(arr, arrLength)
    table.insert(results, currentPermutation)
  else
    for i = start, arrLength do
      swap(i, start, arr)
      arrayPermutationsHelper(arr, start + 1, arrLength, results)
      swap(i, start, arr)
    end
  end
end

function stringPermutations(s)
  local output = {}
  stringPermutationsHelper("", s, output)
  return output
end

function stringPermutationsHelper(prefix, suffix, list)
  if #suffix == 0 then
    table.insert(list, prefix)
  else
    for i = 1, #suffix do
      local newPrefix = prefix .. string.sub(suffix, i, i)
      local newSuffix = string.sub(suffix, 1, i - 1) .. string.sub(suffix, i + 1, #suffix)
      stringPermutationsHelper(newPrefix, newSuffix, list)
    end
  end
end

function shallowCopy(arr, arrLength)
  local newArr = {}

  for i = 1, arrLength do
    newArr[i] = arr[i]
  end

  return newArr
end

function swap(a, b, arr)
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
