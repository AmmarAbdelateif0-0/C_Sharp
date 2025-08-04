
* string here if i add any string to the first string compiler will store the whole string in new location in heap
```cs
string x = "Amgad"
x+= "gamal"
console.WrireLine(x); // Amgad gamal
```

* `StringBuilder` if i add a string , the manipulate happened in the same location .

```cs
StringBuilder x = new StringBuilder("Amgad");
x.Append("Gamal")
```

