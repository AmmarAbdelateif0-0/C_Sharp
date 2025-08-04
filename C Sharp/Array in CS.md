
* Declaration
```cs
int[] Arr = new int[3];
// length is static
```

* initialization
```cs
int[] Arr = new int[3] {1,2,3};
int[] Arr2 = {10,20,30,40,50,60}
```

```cs
Arr ={1,2,3};
```

* initialization with for loop
```cs
for(int i = 0 ; i < 3 ; i++){
	Arr[i] = int.parse(console.ReadLine());
}
```

* display element
```cs
for(int i = 0 ; i < 3 ; i++){
	console.WriteLine(Arr[i]);
}

for(int i =0 ; i < Arr2.length ; i++){
	console.WriteLine(Arr2[i]);
}
```

### Methods
all method in Array class.

* `Array.Clear()` delete all element
```cs
int[] arr = {1,2,3,4,5,5};
Array.Clear(arr);
```

* `Array.Copy(source ,Dest , length)` copy array in another array
```cs
int[] arr = {1,2,3,4,5,5};
int[] arr2;

Array.Copy(arr , arr2 , arr.length);
```

* `Array.reverse()` → reverse array element.
```cs
int[] arr = {1,2,3,4,5,5};
Array.reverse(arr); // 5,5,4,3,2,1
```

* `Array.Sort()` sort array element `asc`
```cs
int[] Arr = { 1 ,5,9,7,6,16,15,18,99 };
Array.Sort(Arr);
```