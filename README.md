# IndexDictionarySharp
Because the order of the keys in the Dictionary<TKey,TValue>.KeyCollection is unspecified[1], so I modify Dictionary to perform the order of the keys is order by insertion index.
[Explaination on Medium](https://medium.com/@lag945/c-dictionary-keys%E6%8E%92%E5%BA%8F%E6%B7%BA%E8%AB%87-58bfa45631d9)

# Comparison of HashMap's order of keys
| Class | Language | Order|
| :--- | :--- | :--- |
| std::map | C++ | key |
| std::unordered_map | C++ | unspecified |
| CMap | C++ | not predictable |
| Dictionary | C# | [unspecified](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.keys) |
| SortedDictionary | C# | key |
| IndexDictionary | C# | insertion index |


# Time Complexity
| Method | Dictionary | SortedDictionary| IndexDictionary|
| :--- | :--- | :--- |:--- |
| Add | O(1) | O(log n) | O(1) |
| Remove | O(1) | O(log n) | O(n) |
| Keys | O(1) | O(1) | O(1) |
| TryGetValue | O(1) | O(log n) | O(1) |
| TryGetValue | O(1) | O(log n) | O(1) |
| TryGetValueByIndex | N/A | N/A | O(1) |

```
Dictionary.Add(1);
Dictionary.Add(2);
Dictionary.Remove(1);
Dictionary.Add(3);
Dictionary.Keys = 3,2

IndexDictionary.Add(1);
IndexDictionary.Add(2);
IndexDictionary.Remove(1);
IndexDictionary.Add(3);
IndexDictionary.Keys = 2,3
```

## Reference
1. [dictionary keys](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.keys)
1. [dictionary source](https://github.com/microsoft/referencesource/blob/master/mscorlib/system/collections/generic/dictionary.cs)
1. [Collision Resolution in the Dictionary Class](https://docs.microsoft.com/en-us/previous-versions/ms379571(v=vs.80))
