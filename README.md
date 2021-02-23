# JList:
## Attributes:
- **int active**: Stores the index of the active element
- **List list**: Stores the actual Data, and can be also accessed. [Manual](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.list-1?view=net-5.0)

## Methods:
### Recommended:
- **void Add(T value)**: Appends the given value to the JList.
- **bool Contains(T value)**: Returns true, if the given value is in JList. Returns false otherwise.
- **T RemoveValueAt(int pos)**: Removes an value at the given position, and returns this value. The index of the following values will be updated.
- **T GetValue(int index)**: Returns the value at the given position.
- **int IndexOf(T value)**: Returns the first position of the given value. Returns -1, if value not found.
- **bool RemoveValue(T value)**: Finds the first positon of the given value in the List. If found this value will be cutted out from list, and function returns true. If not found, this function returns false.
- **void SetValue(int index, T value)**: Sets the Value at a given position.
- **T GetLast()**: Returns the last value.

***

- **JList Clone()**: Clones the whole List and returns it. Referenced Objects won't be cloned.
- **void Empty()**: Empties the List. Active get's -1.
- **T[] GetArray**: Returns an array of the JList. The array is just a copy. You can't change values in the JList over it.
- **int Length()**: Returns the length of the whole JList.
- **void PrintList()**: Prints the whole List. Can be very expensive at large Lists!
- **int Size()**: Same as Length.

***

- **void CutList(int indexStart, int indexEnd)**: Cuts the List to the range of the given indices. The indices are included.
- **void ExchangeValues(int indexA, indexB)**: Exchanges the values at the given positons.
- **JList GetValues(int indexStart, int indexEnd)**: Returns a new JList from position start to including end.
- **void InsertValueBefore(int index, T value)**: Inserts a value before the value at the given position. In the end the inserted value gets the given position. The position of all following values will be increased.
- **void SetDataToPosition(int index, T empty, T data)**: If the index is positive and out of range of the list, the missing positions will be filled until the given index with empty. The value at index will be data. If the index is in range of the List, this function just works as SetValue().

### Other:
- **void AppendElement(Object data)**
- **ListItem GetElementAt(int index)**: Returns a dummy ListItem. The data can be retrieved with *GetData()*
- **ListItem CutActiveElement()**: Returns the active Element in a dummy ListItem, and removes from in the List.  The index of the following elements will be updated.
- **ListItem CutElementAt(int index)**: Returns the Element at the given position in a dummy ListItem, and removes it from the List.  The index of the following elements will be updated.
- **void DeleteActiveElement()**
- **void InsertElementBeforeActive(T value)**
- **void GoToLastElement()**
- **bool Next()**: As long active element is not null, the active element get's the next one.
- **bool Prev()**: As long active element is not null, the active element get's the previous one.
- **void Rewind()**: Sets the active element to the first one.
- **bool SetActive(T value)**: Finds the first value in this List, and sets its element as active.
- **ListItem GetActiveElement()**: Returns a dummy ListItem. The data can be retrieved with *GetData()*
- **void SetActive(int index)**: Sets the element at the given index to the active one.

## Code Snippets:
### Creating JList:
`JList<double> l = new JList<double>();`

### Iterating through JList:

`i` is the index of the current value you can get with `l.GetValue(i)`, or set with `l.SetValue(i, newvalue)`.
```
for (int i = 0; i < l.Length(); i++) {
    // Body
}
```

***

Only  use this, if don't have to set any values to the JList:
```
foreach (T value in l.GetArray()) {
    // Body
}
```

### Using JList:
```
using Tools.JList;
```
