# IndexDictionarySharp
Modify Dictionary to perform Keys order by insertion order.
[Explaination on Medium]()

| Method | Dictionary | IndexDictionary
| :--- | :--- | :--- |
| Add | O(1) | O(1) |
| Remove | O(1) | O(n) |
| Keys | O(1) | *O(1) |
| TryGetValue | O(1) | O(1) |

```
Dictionary.Add(1);
Dictionary.Add(2);
Dictionary.Remove(2);
Dictionary.Add(3);
Dictionary.Keys = 3,2

IndexDictionary.Add(1);
IndexDictionary.Add(2);
IndexDictionary.Remove(2);
IndexDictionary.Add(3);
IndexDictionary.Keys = 2,3
```
