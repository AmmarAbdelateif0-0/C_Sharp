
# EP : 03
### content :

![[Pasted image 20250728114353.png]]
### Variables

* Value types : 
	* store in stack
	* have a range of values .
		to know the minimum and maximum value (`datatype.MinValue` ,`datatype.MaxValue` ).
	* like primitive types( int , float , char , ...etc. ).

range for primitive datatype
![[Pasted image 20250728101853.png]]


like primitive types( int , float , char , ...etc. ).
string reference(address of heap) in stack and the data in heap.

```cs
int num = 5 ;
int oneMillion = 1_000_000;
// num store in stack
// oneMillion store in stack
string s = "ammar";
// s as reference(heap address) in stack
// "ammar" in heap

```

==`alt + 26` create an arrow==

------------------------------------------
### string
→ regular concatenation ( plus sign )

```cs
string s1 = "MR."
string s2 = "Ammar"
string s3 = s1 + " " + s2;
```

→ string interpolation 

```cs
stirng s4 = $"{s1} {s2}"
```

---------------

### var  (vs) dynamic keyword

* var Keyword :
The literal suffix indicates the data type to be assigned to the variable.
```cs
var s1 = "aaa"; // s1 is a string

var i = 12; // i is intger 
var u = 12u; // u is an unsigned integer

var l = 23l; // l is a long
var ul= 23ul; // ul is an unsigned long

var f = 0f; // f is a float
var d = 0d; // d is a double

var m = 0m; // m is a desimal
```

```cs
var n = 6; //n is a intger
n = "qwqw" // ❌❌❌❌


var x = null; // ❌❌❌❌
// we can't use null with var in initialization
```

* dynamic keyword
	* not resolve at compile time
	* resolve at runtime
	* we can change data type
	* ==dynamic is an object==
```cs
dynamic result = 300; // result is a intger
result = "Ammar"; // result is a string
result = 1f; // result is a float
```

--------------------------------------------- 
# --------------------------

# EP : 04

### content :
![[Pasted image 20250728114324.png]]

expression C# is a combination of operands (variables , literals , method calls ) and operators that can be evaluated to a single value .

&& - || → do short circuit (high precedence )
```cs
static bool check(){
console.WriteLine("Checking.....");
return true;
}

bool value = true || check(); // true and check() not call
console.WriteLine(value); // true


```

& - | → doesn't do short circuit
```cs
bool value = true | check(); // true and check() checking.....
console.WriteLine(value); // true
```

-----------------------------------
### Reference type

```cs
var s1 = "hello";
var s2 = "hello";
var s3 = s1 == s2 ;
console.WriteLine(s3); // true
```

how we get true although s1 and s2 in the diff address?   
	CLR (Common Language Runtime) internally calls `IsEqual()` that's why the result is true . so the CLR get the data for each string and compare char by char.


----------------------------------------
# --------------------------

# EP : 05

### content :
![[Pasted image 20250728160351.png]]

Array

```cs
// Declaration
dataType[] arr_name = new datatype[size];
// or 
dataType[] arr_name = {/*data*/}
```

ex
```cs
string[] names = new string[5];

string[] names2 ={
// accept to himself
}

var friends = new string[5]{
	"ali",
	"mahmoud",
	"sara",
	"ammar"
};

```

we can't use var because Explicitly Defining Type 

==يعني لو هتعرفها ب var لازم تكتب نوعها و تعمل new لو هتعرف نوعها من الاول مش لازم new==

* Multi Array
first way :
```cs 
int [,] suduko ={
{/*data*/},
{/*data*/},
{/*data*/},
{/*data*/},
};
// length for each data must be fixed
```

second way :
```cs
var jagged = new int[][]{
new int[] {1,2},
new int[] {3,4,5},
new int[] {2},
}
// array of arrays
// data length not fixed
```

* access range in array

```cs
var friends = new string[5]{
	"ali",    // 0
	"mahmoud",//1
	"tamer",  //2
	"ammar",  //3
	"b3dsh"   //4
};

// to get first element in array
console.WriteLine(friends[0]); //ali

// to get the first 2 element 
// index of 2 mean here 2 not included
console.WriteLine((string.Join(", ",friends[..2])); //ali mahmoud -> 2 here is index not included
// skip first 2 element
// index of 2 mean here 2 is the first element
console.WriteLine((string.Join(", ",friends[2..])); //tamer ammar b3dsh

// skip first 2 element and get the element till 4 element
console.WriteLine((string.Join(", ",friends[2..3])); // tamer

//skip first 2 element and get the next 2 elemnt
// ^1 = arr.length - 1 = the index for the last element 
// ^1 = 5 -1 = 4 
// 2..^1 = 2..4
console.WriteLine((string.Join(", ",friends[2..^1])); // tamer ammar 

```

i can save the range
```cs
var sliceRange = 2..^3
console.WriteLine(friends[sliceRange]); // tamer ammar b3dsh
```

----------------------------------------
# --------------------------

# EP : 06

### content :
![[Pasted image 20250729011051.png]]

### expression types :

* primary expression : the expression has a value.

```cs
var amount = Math.Cos(30);
// Math is an member lookup
// cos() is a method in the math object
// Math.cos() is a primary expression
```

* void expression : expression has no value (return void) . 

```cs
console.WriteLine("islam") + 1; //❌❌❌❌❌
// can't calc void + 1 
```

----------------
### Operator

```cs
var s1 = "";
var s2 = "";
// right to left
var s3 = s2 = s1 = "Ammar";
```

* null coalescing operator : like `||` but work with null and undefined only.
```cs
string s1 = null ;
// 
// if s1 is null or undefined 
s1 = s1 ?? "Ammar"; // s1 -> Ammar

s1 = "";
s1 = s1 ?? "Ammar"; // s1 -> ""

s1 = "";
s1 = s1 || "Ammar"; // s1 -> "Ammar"

```


* conditional null `?.` 
null mean variable in stack but not in heap (doesn't have data) .
as optional chaining

![[Pasted image 20250729115912.png]]

```cs
string s1 = null ; 
var s2 = s1.ToUpper(); // NullReferenceException
// the program crush
// to solve that we use the conditional null
var  s2 = s1?.ToUpper();
==
var s2 = s1 is null ? null : s1.ToUpper();
```

-----------------------
### object instantiation

```cs
Object o = new object();
```

------
### Switch case

```cs
object o = "ammar";
switch(o){
	case int i :
		console.WriteLine($"variable is intger {i}");
		break;
	case string i :
		console.WriteLine($"variable is string {i} : {i.ToUpper()}");
		break;
}
```


```cs
bool b = true;
switch(b){
	case bool i when i == true :
		console.WriteLine($"Yes");
		break;
	case bool i :
		console.WriteLine($"No");
		break;
}
```

Switch Expression : 
```cs
int cardNo = 13;
string cardName = cardNo  switch{
	1 => "ACE",
	13 => "KING",
	1 => "QUEEN",
	1 => "JACK",
	_ => cardNo.ToString()
}
```

------------------------
### jump statement 

* break
* continue
* return
* goto

```cs
var i =0;
// as loop
start: 
if(i<=5){
	console.WriteLine(i);
	++i;
	goto start;
}
```


-------------------------------
# --------------------------

# EP : 07
### content :
![[Pasted image 20250729125358.png]]

anything in `.NET` his root its an object as JS.

why `int` has a blue color and `object` has a green ?
→ `int` is alias name for `Int32`.
→ `short` is alias name for `Int16`.
→ `long` is alias name for `Int64` .

==so the alias name has a blue color.==

--------------------------------------
### implicit conversion :

**implicit conversion** : change variable data type from one to another automatically .

STL (strongly typed language) some rules apply on data types.
→ can't store integer in string 
→ change data type for the same variable 
→ A variable cannot be given a value greater than its capacity.

```cs
var num = 10;

string str = num; // ❌ compilation Error

int num2 = str ;  // ❌ compilation Error
```

ex for implicit conversion → convert small datatype to large 
→ long → int (❌❌❌❌)

```cs
int numInt =100;
long numLong = numInt; //  implicit conversion
long numLong2 = 10000; //  implicit conversion
int numInt2 = numLong2 //  ❌❌❌❌
```

### Explicit Casting  
change variable data type from one to another manually  .

```cs
long l = 1000;
int x = (int) l ; // Explicit Casting 
```

if i want check the L variable value in the range of int
```cs
long nl = 1000;
if( nl <= Int32.MaxValue ){
	int nI =(int) nl;
}
```

-------------------------------

### Boxing and UnBoxing

boxing     : convert from value to reference 
unboxing : convert from reference to value

```cs
int x =10;    // value type

Object obj ;  // reference type store in heap

obj = x;      // conversion done implicitly (boxing)

int y = obj ; //  ❌❌❌❌

// Explicit
int y =(int) obj ; // unboxing
```

------------------------------------
### Parse
convert from string to a numerical one.

```cs
string stringValue = "120";
int value = stringValue; //  ❌❌❌❌
```

to solve this 
→ `type.parse()` => `int.parse()` ....... 
this is in case the string have a numbers only.

```cs
string stringValue = "120";
int value = int.parse(stringValue); 
```

if have a another char -> format exception .
```cs
string stringValue = "120Aa";
int value = int.parse(stringValue); // format exception
```

if have a value larger than range of datatype -> overflow exception. 
```cs
string stringValue = "99999999999999999999999";
int value = int.parse(stringValue); //  overflow exception
```

if you want to check before execute we use `TryParse()` method .
if can convert do it and store in out else return null.

```cs
string stringValue = "99999999999999999999999";
int number ;

if(int.TryParse(stringValue , out int number)){ //OverFlow
	console.WriteLine(number);
}
```

-------------------------
### Convert Class :
as parser but for performance we use parser

```cs
string stringValue = "120";
var i = Convert.ToInt32(stringValue);
```
```cs
string stringValue = "120ss";
var i = Convert.ToInt32(stringValue);// format exception
```
```cs
string stringValue = "120000000000000000000000000";
var i = Convert.ToInt32(stringValue);//  overflow exception
```


-----------------------------
### Bit converter 

`BitConverter.GetBytes()` convert number to array of bytes
كل بايت بيستجل الجزء ال متخزن فيه .

```cs
//Int32 -> 4 byte
var number = 255;
var bytes =BitConverter.GetBytes(number);

foreach(var b in bytes){
	console.WriteLine(b);
}
// to convert to bits
foreach(var b in bytes){
	var binary = Convert.ToString(b , /*base*/ 2); // 2 for binary
	console.WriteLine(binary);
}
// if i want show 8 bits any way
foreach(var b in bytes){
	var binary = Convert.ToString(b , /*base*/ 2).PadLeft(8 /*number of bits*/ , '0' /*الحرف ال بملي بيه*/);
	console.WriteLine(binary);
}
```

convert from string to bytes or bits.

```cs
// first convert string to number of chars
var name = "ammar";
char[] letters = name.ToCharArray();

foreach (var c in letters)
{
    int ascii = Convert.ToInt32(c);
    Console.WriteLine($"{c} -> ASCII -> {ascii} Binary {Convert.ToString(ascii ,2).PadLeft(8,'0')} Hex -> {ascii:x}");
}
```

to convert from int to char we use 
1- `Char.ConvertFromUtf32();` .
2- explicit casting `(char)carName`

```cs
 string[] hasValues = {"49" , "50", "51", "52", "53", "60", "61"};

 foreach (var hex in hasValues)
 {
     int ascii = Convert.ToInt32(hex,16);
     var stringValue = Char.ConvertFromUtf32(ascii);
     var ch = (char)ascii;
     Console.WriteLine(stringValue);
     Console.WriteLine(ch);
 }
```

to convert hex to int
```cs
var hex = "82f";
int number = Int32.Parse(hex , System.Globalization.NumberStyles.HexNumber);
```

---------------------------------------

# --------------------------

# EP : 08 OOP

### content :

![[Pasted image 20250730041409.png]]

to get data from user we use `ReadLine()`

```cs
var str = Console.ReadLine(); // return string
```

![[Pasted image 20250731041855.png]]

```cs
	const double tax = 0.03;
	Console.WriteLine("Firsr Name :");
	var Fname = Console.ReadLine();

	Console.WriteLine("Last Name :");
	var Lname = Console.ReadLine();

   

	Console.WriteLine("Wage");
	var wage = Convert.ToDouble(Console.ReadLine());

	Console.WriteLine("Logged Hours :");
	var hours = Convert.ToDouble(Console.ReadLine());

	var netsalary = wage * hours - (wage * hours) * tax;

	Console.WriteLine($"Fname {Fname} {Lname}");
	Console.WriteLine($"Wage {wage}");
	Console.WriteLine($"hours {hours}");
	Console.WriteLine($"Total Salary  {netsalary}");

```

the whole code for one employee what if i want to do that for 100 employees the code will be mess so we need `oop concept`. 

==Object-Oriented Programming== (OOP) is a programming paradigm that allows  you to package together data states and functionality .  
the data here is related data(داتا ليها معني لما بتكون مع بعض و مترابطه). 

concept of OOP 
![[Pasted image 20250731043213.png]]


to create class press on project right click choose add and class.

```cs
// to define class
<ClassModifier> can be
→ public
→ internal (default) داخليا متاح
→ private
→ protected

<ClassModifier> class <ClassName>{
	// Body
}
```

==Class Members==
![[Pasted image 20250731044413.png]]

**constant** **syntax**: must assigned to variables.

```cs
<AccessModifier> const <DataType> <ConstName> = <Value>;
```
 

**Field** **syntax** : 
```cs
<AccessModifier> <DataType> <FieldName> = <InitialValue>;
Type of <AccessModifier>
→ public 
→ private for security and encapsulation
→ protected
→ etc
```

ex 
```cs
public class Employee{
// constant
public const double Tax = 0.03;
// -> fields
public string Fname;
public string Lname;
public double Wage;
public double LoggedHours;
}
```

**to create a object from class**
```cs
// Object syntax
// Declaration 
<type> <objectName>;
// Assignment  
<objectName> = new <Type>();
// initialization  = Declaration + Assignment
<type> <objectName> = new <Type>();
```

ex
```cs
Employee e1 = new Employee();
e1.Fname = "Ammar";
e1.Lname = "Abdo";
e1.Wage = 66.5;
e1.LoggedHours = 250;
```

==access constant must my class name==
```cs
console.WriteLine(Employee.Tax)
```

If i have 100 employees for example 
```cs
Employee[] Es = new Employess[100];

for(int i =0 ; i <Es.length ; i++){
		Console.WriteLine($"Enter (FirstName , LastName , Wgae and LoggedHours ) for Employee{i+1} ")
	Es[i].Fname = Console.ReadLine();
	Es[i].Lname = Console.ReadLine();
	Es[i].Wage = Convert.ToDouble(Console.ReadLine());
	Es[i].LoggedHours = Convert.ToDouble(Console.ReadLine());
	var NetSalary = Es[i].Wage * Es[i].LoggedHours - (Es[i].Wage * Es[i].LoggedHours * Employee.Tax)
}
```
--------------------------
### **how to store this object ?**
object is a reference type .

so the object reference (address of heap) on stack and the actual data store in heap.
![[Pasted image 20250731052140.png]]

---------------------------------------------------

# --------------------------

# EP : 09 Static

### content :
![[Pasted image 20250731054139.png]]

addition order from company
![[Pasted image 20250731062237.png]]

`Tax` is defined as constant so we can't change  it at runtime.
to solve that we will use `Static`.

```cs
public class Employee{
// constant
public static double Tax = 0.03;
// -> fields
public string Fname;
public string Lname;
public double Wage;
public double LoggedHours;
}
```

==static and const store in heap in place the garbage collection can't reach there to delete data.==

![[Pasted image 20250731062747.png]]

| const                                                                     | static                                                                             |
| ------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| constant is a promise that can not be changed after has been initialized. | static member is a shared variable that can be changed after has been initialized. |

-------------
##### ==**Instant Method : is called by object .==**
```cs
public class car {
	public void StartEngine(){
		Console.WriteLine("Engine Started");
	}
}

// Usage 
car myCar = new car();
// call the instant method using the object
myCar.StartEngine();

car.StartEngine(); // ❌❌❌❌
//Error :An object reference is required for the non-static field, method, or property 'car.StartEngine()'

```

##### ==**Static Method is called by TypeName .==**
these methods belong to the class itself , not to any object.
you call them using the class name (type name) without creating an object.

```cs
public class MathHelper {
	public static int Add(int x , int y){
		return x + y;
	}
}

// Usage
int result = MathHelper.Add( 4 , 9 ); // cakk static method using class name
-------------
MathHelper Mh = new MathHelper();
int res = Mh.Add(5, 9); // ❌❌❌
//Member 'MathHelper.Add(int, int)' cannot be accessed with an instance reference; qualify it with a type name instead

```
-------------------------
### **Method**

**method syntax** (simple) : 

```cs
<AccessModifier> /*return type*/<DataType/void> <MethodName>(/*Parameters*/){
	//Body
};
```
we use private Access Modifier for security and encapsulation concept.

---------------------------------------
### **EX for `pass by value`** :

**pass by value** means you are make a copy in memory of **the actual parameter's value** , that is passed in.
```cs
static void Main(string[] args){
	Demo d1 = new Demo();
	// caller
	// age(18) here call argument passed
	var age =18;
	d1.DoSomething(age); // 19
	console.WriteLine(age); // 18
}
public class Demo{
	// callee
	// age here call parameter
	public void DoSomthing(int age){
		age += 1;
		console.writeline($"your age become {age} HBD🥳");
	}
}
```
------------------------------------------------
### **EX for `pass by ref`** :
 
 **pass by ref** : means you are pass a copy in memory(actual address) of **the actual parameter's address** , that is passed in.
 → the argument must be initialized to avoid error.
 → add ref key word in caller and callee before variable .
 
```cs
static void Main(string[] args){
	Demo d1 = new Demo();
	// caller
	// age(18) here call argument passed
	var age =18;
	d1.DoSomething(ref age); // 19
	console.WriteLine(age);  // 19 not 18
}
public class Demo{
	// callee
	// age here call parameter
	public void DoSomthing(ref int age){
		age += 1;
		console.writeline($"your age become {age} HBD🥳");
	}
}
```
------------------------------------------------
### **using `out` Keyword** :

→ with out we can pass argument without initialized.
 → add out key word in caller and callee before variable .
```cs
static void Main(string[] args)
{
   Demo d1 = new Demo();
   // caller
   // age(18) here call argument passed
   int  age;
   d1.DoSomthing(out age);  // 1
   Console.WriteLine(age);  // 1
}
public class Demo
{
   // callee
   // age here call parameter
   public void DoSomthing(out int age) { 
	   age = 0; // to avoid error
	   age += 1;
	   Console.WriteLine($"your age become {age} HBD");
   }
}
```

------------------------------------
### What is the Difference between ref and out keyword ?

| out                                      | ref                                        |
| ---------------------------------------- | ------------------------------------------ |
| can pass argument without initialization | can't pass argument without initialization |

----------------------------------------------
ex to implementation the `CalcNetSalary()` .
```cs
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo d = new Demo();
            d.Fname = Console.ReadLine();
            d.Lname = Console.ReadLine();
            d.Wage = Convert.ToDouble(Console.ReadLine());
            d.LoggedHours = Convert.ToDouble(Console.ReadLine());

            var netsalary = d.CalcNetSalary(d.Wage, d.LoggedHours, Demo.Tax);

            // caller
            Console.WriteLine(netsalary);

            Console.ReadKey();
        }
    }

    public class Demo
    {
        
        public static double Tax = 0.03;
        // -> fields
        public string Fname;
        public string Lname;
        public double Wage;
        public double LoggedHours;
        // Methods
        //Callee
        public double CalcNetSalary(double Wag , double LoLoggedHoursad, double Tax)
        {
            var salary = Wage * LoLoggedHoursad;
            var TaxValue = salary * Tax;
            var netSalary = salary - TaxValue; 
            return netSalary;
        }
```

---------------------

### Method Signatures (fingerprint) 

```cs
Name + Param type + Param order
```

if there is two method have the same name of method , parameter type and parameter order , you will get error . 

```cs
public void foo(int x , double y);
public void foo(int x , double y); // Error ❌

// different type
public void foo(int x , double y);
public void foo(int x , int y); // Work ✅

// different order
public void foo(int x , double y);
public void foo(double y ,int x); // Work ✅

// different order
public void foo(int x , double y);
public void foo(double x ,int y); // Work ✅
```

This approach  called **==Method Overloading==** .

==**Method Overloading**== is a common way of implementing **==Polymorphism==**.

Real example for using **Method Overloading**.

```cs
public void Promote(double  amount){
	Console.WriteLine($"You've got a promotion of{amount * 2}");
}
public void Promote(double  amount , string trip){
	Console.WriteLine($"You've got a promotion of{amount * 2} and a trip to {trip}");
}
public void Promote(double  amount , string trip , string hotal){
	Console.WriteLine($"You've got a promotion of{amount * 2} and a trip to {trip} with {hotal} reservation");
}
```

---------------------------
### **Expression Bodied Method**

if the method have a one line to return value we use **Expression Bodied Method** `=>` .

```cs 
public bool IsEven(int number) => number % 2 == 0 ;
```

-----------------------------
### **Local Method** 

**Local Method** is a method define in another method to make code more clear and we can't access it out the scope of the function define in.

```cs
public void PrintEvent(int[] original){
	foreach(var n in original){
		if(IsEven(n)){
			Console.Write($"{n} ");
		}
	}
		// without public
		bool IsEven(int number) => number % 2 == 0 ;
}
```

so the `IsEven()` method is a local method . 
to use this method .
```cs
Demo d = new Demo();
int[] arr = new int[6] { 1, 2, 3, 4, 5,6 };
d.PrintEvent(arr);

d.PrintEvent(new int[6]{ 6 , 22 ,69,30,55 ,9 });
```

--------------------------------------------
### **Static Method** 
static function and static member called with class name.
static member treats with static member only.
so `IsEven()` must be static method also .

```cs
public void PrintEvent(int[] original){
	foreach(var n in original){
		if(IsEven(n)){ // Error ❌
			Console.Write($"{n} ");
		}
	}
		
}
public bool IsEven(int number) => number % 2 == 0 ; 
```

* **==First Solution==** → add static with `IsEven()` method.

```cs
public static void PrintEvent(int[] original){
	foreach(var n in original){
		if(IsEven(n)){ 
			Console.Write($"{n} ");
		}
	}
		
}
public static bool IsEven(int number) => number % 2 == 0 ;
```


* **==Second Solution==** → make `IsEven()` method as a local method.

```cs
public static void PrintEvent(int[] original){
	foreach(var n in original){
		if(IsEven(n)){
			Console.Write($"{n} ");
		}
	}
	bool IsEven(int number) => number % 2 == 0 ;
}
```


---------------------------------------

-----------------------------

# --------------------------

# EP : 10

### content :
![[Pasted image 20250731090142.png]]

### **Constructor :** 

→ **Constructor** means give to the class initialize value .

→ **Modeling** : convert problem to class is anything that represents something .

==convention of naming variables== 
```cs
// private variables (camalCase or _camalCase)
private int  dayMonth;
private int _dayMonth;
// public variables (CamalCase)
public int DayMonth;
```

Constructor Syntax :
```cs
<AccessModifier> <TypeName>/*class name*/( Parameter<list> ){
	// body
}
```

##### ==**abbreviation to create constructor**==
```cs
ctor + tab + tab
```
  
you can't do a method with the same name of class except **Constructor** .

ex 
```cs
 public Date(int day, int month, int year)
 {
     this.Day = day;
     this.Month = month;
     this.Year = year;
 }
 // in main when you make instance of the class
 Date d = new Date(9,4,2003);
 // after this the filed will be initialized
```

----------------------------------------
### **implicit constructors :** 

**implicit constructor** will define after you create class automatically without write a constructor method . 
```cs
public Date(){

}
```

if Access Modifier for constructor is private so we can't create instance class .
```cs
private Date(){

}
```

![[Pasted image 20250801021817.png]] 

if you want the user to be not accessible for the fields then defined the fields as a private and you can assign value to this variable from constructor only.

if the parameter and the fields have the same name to avoid errors we use the `this keyword`

```cs
public  Date(int day, int month, int year)
 {
     day = day;
     month = month;
     year = year;
 } // get error❌

--------------------------------------------

public  Date(int day, int month, int year)
 {
     this.day = day;
     this.month = month;
     this.year = year;
 }
```

if i want make data to be read only and can't modify , we use `readonly keyword`.
`readonly` → make variable read only.
		 → you can reassigned the variable in **constructor** and at definition  only. 
```cs
private static readonly int[] daysToMonth365 ={ 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

```

-----------------------------
### **Constructor Overloading :**

**constructor overloading** is a feature make you not pass all argument and use the default value. 
by create method and this method call constructor .

we use the `this keyword` after we write  parameter .

example :
```cs
// consturcotr
class Date{
	public  Date(int day, int month, int year)
	{
	    var isLeap = year % 4 == 0 && (year % 100 != 0 || year % 400 ==0) ;
	    
	    if (year >= 1 && year <= 9999 && month >= 1 && month <= 12)
	    {
	        int[] days = isLeap ? daysToMonth366 : daysToMonth365;
	        if (day >= 1 && day <= days[month])
	        {
	            this.Day = day;
	            this.Month = month;
	            this.Year = year;
	        }
	    }
	}
	public Date(int year): this(1,1,year){
	
	}
	public Date(int month,int year): this(1,month,year){
	
	}
}


// in main function
Date d  = new Date(9,4,2003);   // 9/4/2003

Date d2 = new Date(4,2003);// 1/4/2003


Date d3 = new Date(2003);       // 1/1/2003
-> Date(1,1,2003) then -> call the orignal constructor to check the validation

Date d4 = new Date(99999);
-> Date(1,1,99999) then -> call the orignal constructor to check the validation -> 99999 > 9999 so the block doesn't executed

```

----------------------
### **Object Initializer :**

Employee Class:

```cs
public class Employee{
	public int Id;
	public string Fname;
	public string Lname;
	
	public Employee(){
	
	}
	public Employee(int id,string fname, string lname){
		this.Id = id ;
		this.Fname =fname;
		this.Lname =lname;
	}
	public Employee(int id){
		this.Id = id ;
	}
}
```

→ initialization fields :
* First Way .
```cs
Employee e = new Employee();
e.Id    = 1;
e.Fname = "Ammar";
e.Lname = "abdo";
```

* Second Way (**==Object Initializer==**) .
```cs
Employee e = new Employee(){
	Id = 1,
	Fname = "Ammar",
	Lname = "abdo"
}
```
* Third Way with constructor . 
```cs
Employee e = new Employee(1,"Ammar","Abdo");
```
* fourth Way with constructor overloaded and object initializer . 
```cs
Employee e = new Employee(1){
	Fname = "Ammar",
	Lname = "abdo"
}
```

-------------------
### Private Constructor and Factory Method :

private constructor : anyone want to make an instance of class must create in the same class.
but we can create a method return class and this method must to be `static` .

```cs
public class Employee
{
	private int id;
	private string fname;
	private string lname;

	private Employee()
	{

	}
	private Employee(int id, string fname, string lname)
	{
		this.id = id;
		this.fname = fname;
		this.lname = lname;
	}
	
	public static Employee create (int id, string fname, string lname)
	{
		// class must create in the same class
		return new Employee(id, fname, lname);
	}
}
// in main we use class name to call the create method
var e = Employe.create(1,"Ammar","Abdo");
```

`create()` method is the Factory method.

so now you can't use the object Only through factory method.
use case for this concept if you want know how many instance for this object .

----------------------------------------------

# --------------------------

# EP : 11

content :
![[Pasted image 20250801050537.png]]

**property promote the encapsulation concept**.
we use the concept of encapsulation to make our class  more secure. 

**property is a public way to access private field.**
so we use it when we want define the data as private and we want to make the user to use them.

**property syntax :**
```cs
<AccessModifier> <DataType> <FieldName>/*CamalCase*/ {
	get{ // to get data
		return this.fieldname;
	}
	set{ // to set data
		this.fieldname = value;
	}
};

or
----------------------------------------------

<AccessModifier> <DataType> <FieldName> {get; set;}
```
##### ==**abbreviation to create property**==
```cs
prop + tab + tab
```

→ **value** is a reserved keyword when i use set with property the value which get from user store in it. 

==→ we can create a property without field== (**like `IsZero`** in next example).
ex 
```cs
private decimal _amount;

public decimal Amount
{
    get
    {
        return this._amount;
    }
    set
    {
        this._amount = value;
    }
}
public bool IsZero
{
    get
    {
        return _amount == 0;
    }
}
==
// called fat arrow operator
public bool IsZero => _amount == 0;
```

set and get called accessors(معاملات).

if i want to make the property doesn't accept any value from user directly.

we use private with set :
```cs
```cs
public class Dollar
{
    private decimal _amount;

    public decimal Amount
    {
        get
        {
            return this._amount;
        }
        private set
        {
            this._amount = this.ProcessValue(value); 
        }
    }
    public void SetAmount(decimal Value){
	    Amount = value ;
    }
}
```

so you can set amount using call `SetAmount()` then Amount set the `_amount`.

this concept called **==Backing Field**== (the field which we will store in (set) and read from (get).
 
![[Pasted image 20250801071108.png]]

benefits from using property :
→ Validation when i set value for it  when variable defined as public i haven't validation .

**fully case**
```cs
public class Dollar
{
    private decimal _amount;

    public decimal Amount
    {
        get
        {
            return this._amount;
        }
        set
        {
            this._amount = this.ProcessValue(value); 
        }
    }
    public Dollar(decimal amount)
    {
        this._amount = this.ProcessValue(amount);
    }

    public decimal ProcessValue(decimal val)
        => val <= 0 ? 0 : Math.Round(val,2);
}
```


if i want to make variable read only never use set.  
-> delete set accessor no one can set the property except at definition(with Constructor) .
-> method access the `_amount` field  directly. 

**set the property at definition :**
```cs
public decimal ConversionFactor{ get; } = 1.99m;
```


**===CLR (common language runtime) at runtime convert property to method .===**

```cs
public decimal Amount
{
	get
	{
		return this._amount;
	}
	private set
	{
		this._amount = this.ProcessValue(value); 
	}
}
// this case at runtime internally convert to two method
// geter and setter
public decimal GetAmount(){
	return _amount;
}

public void SetAmount(decimal value){
	this._amount = value;
}

```

==**reflection** work with property not field we will see next lessons and DB and Ef love reflection so the property is very common in C#== 


--------------------------------



# --------------------------

# EP : 12

### content :
![[Pasted image 20250801083727.png]]

  Index this feature make us can access the element in data type which this data is a collection of datatype like (array and string).

```cs
int[] arr = {1,2,3,4,5};
arr[2] = 33; //{1,2,33,4,5}

string s = "Ammar";
s[1]= "s"; // error ❌❌❌ we can't modifiy the string after initialized
var res = s[0]; // A
```

IP class
```cs
public class IP
{
	private int[] segments = new int[4];

	// index property
	public IP(string IPAdress)
	{
		var segs = IPAdress.Split(".");

		for (int i = 0; i < segs.Length; i++)
		{
			segments[i] = Convert.ToInt32(segs[i]);
		}
	}
	
	public IP(int seg1 , int seg2, int seg3, int seg4)
	{
		segments[0] = seg1;
		segments[1] = seg2;
		segments[2] = seg3;
		segments[3] = seg4;
	}
	// is a property not method
	public string Address => string.Join(".", this.segments);
	------------------
	or
	------------------
	public string Address
    {
        get
        {
            return string.Join(".", this.segments);
        }
    }
    
    public override string ToString()
    {
        return $"IP {this.Address}";

    }

}
```
in main
```cs
var ip = new IP(127,1,1,1);
console.WriteLine(ip[0]); // error because there's no index in class
```

how i can add index in class ?
```cs
<accessModifier> /*public*/ typeData /*the data that i will use index with it*/ this[int index]{
	get{
		return segmant[index];
	}
	set{
		sagmant[index] = valuel; 
	}
}
```

add index to IP class
```cs
public int this[int index]
{
	get
	{
		return segments[index];
	}
	set
	{
		segments[index] = value;
	}
}
```
we add `this[]` to create index and any value pass in [ ] store in index variable and and use it to get the data from segments array.

this keyword point to IP class.

how create index in class which we will use index in array 2D .
```cs
//  int type the element you will return 
public int this[int row , int column]
{
	get
	{
		if(row < 0 || row > _matrix.GetLength(0) -1 )
			return -1;
		if(column < 0 || column > _matrix.GetLength(1) -1)
			return -1;
			
		return _matrix[row , column];
	}
	set
	{
	// check if the value between 1 and 9
		if(value < 1 || value > _matrix.GetLength(0) -1)
			return;
		_matrix[row , column] = value;
	}
}
```

==to know the maximum length for rows `GetLength(0)`==
==to know the maximum length for columns `GetLength(1)`==

---------------------------------

# --------------------------

# EP : 13

![[Pasted image 20250803112711.png]]

How to make a array of object and assigned variables in
```cs
var emps = new Employee[]
{
};
```
between { } we create a new instants and assigned data with { } `filed name = data`
```cs
var emps = new Employee[]
{
	new Employee {Id = 1 , name = "Ammar A." ,Gender ="M" ,ToralSales = 8000},
	new Employee {Id = 2 , name = "Sara A." ,Gender ="F" ,ToralSales = 6000},
	new Employee {Id = 3 , name = "Sama A." ,Gender ="F" ,ToralSales = 4000},
	new Employee {Id = 4 , name = "Mahoud A." ,Gender ="M" ,ToralSales = 7000},
	new Employee {Id = 5, name = "Aya A." ,Gender ="F" ,ToralSales = 6000},
};
```

==to create sperate file to class point to class and use command `CTRL + .`;==

i want create a report for 
1- employees  who's the `total sales > 60000`
2- employees  who's the `total sales < 60000` and `total sales > 30000`
3- employees  who's the `total sales< 30000`
```CS
public class Report
{
   public void ProcessEmployeewith60000PlusSales(Employee[] employee)
   {
	   Console.WriteLine("Employees With $60,000+ Sales");
	   Console.WriteLine("~~~~~~~~~ Report 1 ~~~~~~~~~~");

	   foreach (var e in employee)
	   {
		   if(e.ToralSales >= 60000m)
		   {
			   Console.WriteLine($"{e.Id} | {e.name} | {e.Gender} | {e.ToralSales}");
		   }
	   }
	   Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	   Console.WriteLine("\n\n");

   }

   public void ProcessEmployeewithTotalSalesBetween30000and59999(Employee[] employee)
   {
	   Console.WriteLine("Employees With TotalSales Between $30000 and $59999 ");
	   Console.WriteLine("~~~~~~~~~ Report 2 ~~~~~~~~~~");

	   foreach (var e in employee)
	   {
		   if (e.ToralSales < 60000m && e.ToralSales >= 30000m)
		   {
			   Console.WriteLine($"{e.Id} | {e.name} | {e.Gender} | {e.ToralSales}");
		   }
	   }
	   Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	   Console.WriteLine("\n\n");

   }
   public void ProcessEmployeewithTotalSalesLessThan30000(Employee[] employee)
   {
	   Console.WriteLine("Employees With TotalSales Less Then 30000 ");
	   Console.WriteLine("~~~~~~~~~ Report 3 ~~~~~~~~~~");

	   foreach (var e in employee)
	   {
		   if (e.ToralSales < 30000m)
		   {
			   Console.WriteLine($"{e.Id} | {e.name} | {e.Gender} | {e.ToralSales}");
		   }
	   }
	   Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	   Console.WriteLine("\n\n");

   }

}
```
there's problem here we see repetition code so this is not as DRY concept.
there is only 3 things changing here. so we can write one method and use 3 things as parameters.
```cs
public class Report
{
public void ProcessEmployee(Employee[] employee,string title)
{
   Console.WriteLine(title);
   Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

   foreach (var e in employee)
   {
	   if(e.ToralSales >= 60000m)
	   {
		   Console.WriteLine($"{e.Id} | {e.name} | {e.Gender} | {e.ToralSales}");
	   }
   }
   Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
   Console.WriteLine("\n\n");

}
}
```
### Delegates

**Delegate object** that points to method al changed at run time.

**==Delegate as like as Method but without body , the body defined at runtime.==**

**Delegate a reference type**.

delegate syntax :
```cs
<AccessModifier> delegate returnType NameOfDeleget (Employee e);
```

now Delegate is an object mean we can pass it as a parameter  to function.

```cs
public class Report
{
//Delegate
public delegate bool IllegibleSales ( Employee e);

public void ProcessEmployee(Employee[] employee,string title,IllegibleSales illegibleSales )
{
   Console.WriteLine(title);
   Console.WriteLine("~~~~~~~~~ Report 1 ~~~~~~~~~~");

   foreach (var e in employee)
   {
	   if(illegibleSales(e))
	   {
		   Console.WriteLine($"{e.Id} | {e.name} | {e.Gender} | {e.ToralSales}");
	   }
   }
   Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
   Console.WriteLine("\n\n");

}
}
```

if parameter is delegate mean this parameter wait to pass the method name.

```cs
// in Program Class we defined three method
static bool IsGreaterThanorEqual60000(Employee e) => (e.ToralSales >= 60000m);

static bool IsGreaterThanorEqual30000oandLessThan60000(Employee e) => (e.ToralSales< 60000m && e.ToralSales >= 30000m);

static bool IsLessThan30000(Employee e) => (e.ToralSales < 30000m);

//  in main 

Report re = new Report();

re.ProcessEmployee(emps, "Sales >= $60,000 ",IsGreaterThanorEqual60000);

re.ProcessEmployee(emps, "Sales >= $30,000 and Sales < $60,000 ",IsGreaterThanorEqual30000oandLessThan60000);

re.ProcessEmployee(emps, "Sales < $30,000 ",IsLessThan30000);

```

this way  used till `.Net core 2` after this we use the anonymous Delegate.

-------------------------------------------
### Anonymous Delegate :

Anonymous Delegate No Need for Method . 

Anonymous Delegate syntax :
```cs
delegate(/* parameter */) {
	// body
}
``` 

```cs
Report re = new Report();

re.ProcessEmployee(emps, "Sales >= $60,000 ",delegate(Employee e) {return e.ToralSales >= 60000m });

re.ProcessEmployee(emps, "Sales >= $30,000 and Sales < $60,000 ",delegate(Employee e) {return (e.ToralSales< 60000m && e.ToralSales >= 30000m });

re.ProcessEmployee(emps, "Sales < $30,000 ",delegate(Employee e) {return e.ToralSales < 30000m });
```

------------------------------------------
### Lambda Expression (=>)

Lambda Expression appeared after `.Net Core 3` .
Lambda Expression is a delegate method.

delegate after lambda expression
```cs
(/* parameter */) =>  {
	// body
}
```

```cs
Report re = new Report();

re.ProcessEmployee(emps, "Sales >= $60,000 ",(Employee e)=> e.ToralSales >= 60000m );

re.ProcessEmployee(emps, "Sales >= $30,000 and Sales < $60,000 ",(Employee e) =>  (e.ToralSales< 60000m && e.ToralSales >= 30000m );

re.ProcessEmployee(emps, "Sales < $30,000 ",(Employee e) =>  e.ToralSales < 30000m );
```

when we defined the delegate method we defined the parameter type as `Employee` so you can pass e only in main.
```cs
Report re = new Report();

re.ProcessEmployee(emps, "Sales >= $60,000 ",e=> e.ToralSales >= 60000m );

re.ProcessEmployee(emps, "Sales >= $30,000 and Sales < $60,000 ",e =>  (e.ToralSales< 60000m && e.ToralSales >= 30000m );

re.ProcessEmployee(emps, "Sales < $30,000 ", e =>  e.ToralSales < 30000m );
```

------------------------

### Multicast Delegate

Multicast delegate  point to multi method and when we use this delegate call all this method.

```cs
public class Rectange
{
	public void GetArea(decimal width , decimal height)
	{
		var result = width * height;
		Console.WriteLine($"Area: {width} * {height} = {result}");
	}

	public void GetPerimeter(decimal width, decimal height)
	{
		var result = (width * height) * 2;
		Console.WriteLine($"Perimeter: ({width} * {height}) * 2 = {result}");
	}
}
```

in Main
```cs
// out the main
public delegate void RectDelegate(decimal width, decimal height);

// in main
Rectange helper = new Rectange();

// delegate point to the helper.GetArea
RectDelegate rect = helper.GetArea;

// delegate point to the helper.GetArea and helper.GetPerimeter
rect += helper.GetPerimeter;

// call the delegate then the helper.GetArea and helper.GetPerimeter will execute
rect(14, 15);

// to unsubscribing method from delegate
Console.WriteLine("after unsubscribing rect.GetPerimeter");
rect -= helper.GetPerimeter;

rect(14, 15);
```


--------------------------------------------

# --------------------------

# EP : 14

![[Pasted image 20250804035503.png]]


### What is Event ?

Event enable a class or object to notify other classes or objects something of interest occurs.

when we create an event must be associated with delegate.

الديليجت هو ال بيكون عارف ان حصل تغيير

```cs 
public delegate void StockPriceChangeHandller(Stock stock , decimal oldPrice);
```

Event Syntax : 
```cs
<AccessModifier> event <delegateName> eventName;
```


i want to create event make the text change has color if the price changed.

```cs
// delegate
public delegate void StockPriceChangeHandller(Stock stock , decimal oldPrice)

// class
public class Stock
{
	private string name;
	private decimal price;
	
	// event
	public event StockPriceChangeHandller OnPriceChanged;

	public string Name
	{
		set{
			this.name = value;
		}
		get
		{
			return this.name;
		}
	}
	public decimal Price
	{
		set => this.price = value;
		get => this.price;
	}

	public Stock(string name , decimal price)
	{
		this.name = name;
		this.price = price;
	}

	public void ChangeStockPriceBy(decimal percent)
	{
		decimal oldPrice = this.price;

		this.price += Math.Round(this.price * percent, 2);
		
		if(OnPriceChanged != null) //make sure there is subscriber
		{
			OnPriceChanged(this, oldPrice); // firing the event mean make it work
		}
	}
}

```

Firing Event / Publishing Event 

![[Pasted image 20250804065828.png]]


==to change the text color on console ==
```cs
Console.ForegroundColor = ConsoleColor.Green;
```

in main to add a subscriber to event

```cs
var stock = new Stock("computer", 1200);

stock.OnPriceChanged += Stock_OnPriceChanged;
// after write the stock.event += if we press tab key
// the compiler create to you private static method
// this method will execute if the event happend

// to unsubscribe 
stock.OnPriceChanged -= Stock_OnPriceChanged;
```
 
 we want the `Stock_OnPriceChanged` change the color text .
 
 ```cs
private static void Stock_OnPriceChanged(Stock stock, decimal oldPrice)
{
	if(stock.Price > oldPrice)
	{
		Console.ForegroundColor = ConsoleColor.Green;
	}else if(stock.Price < oldPrice)
	{
		Console.ForegroundColor = ConsoleColor.Red;
	}
	else
	{
		Console.ForegroundColor = ConsoleColor.Gray; 
	}
	Console.WriteLine($"{stock.Name} : {stock.Price}");
}
```

#### using lambda expression
```cs
var stock = new Stock("computer", 1200);

stock.OnPriceChanged += (Stock s , decimal oldPrice) =>{
	if(stock.Price > oldPrice)
	{
		Console.ForegroundColor = ConsoleColor.Green;
	}else if(stock.Price < oldPrice)
	{
		Console.ForegroundColor = ConsoleColor.Red;
	}
	else
	{
		Console.ForegroundColor = ConsoleColor.Gray; 
	}
	Console.WriteLine($"{stock.Name} : {stock.Price}");
};
// or
stock.OnPriceChanged += ( s ,  oldPrice) =>{
	if(stock.Price > oldPrice)
	{
		Console.ForegroundColor = ConsoleColor.Green;
	}else if(stock.Price < oldPrice)
	{
		Console.ForegroundColor = ConsoleColor.Red;
	}
	else
	{
		Console.ForegroundColor = ConsoleColor.Gray; 
	}
	Console.WriteLine($"{stock.Name} : {stock.Price}");
};

```

summary for what happened 
![[Pasted image 20250804071128.png]]


----------------------------
# --------------------------

# EP : 15
![[Pasted image 20250804071731.png]]
### Operator Overloading

**Operator Overloading** : user defined type that can overload predefined operators .
```cs
class Money
{
	private decimal amount;
	public decimal amoun => this.amount;

	public Money(decimal value)
	{
		this.amount = Math.Round(value,2);
	}
}

// in main
Money m = new Money(10);
Money m2 = new Money(30);

Money m3 = m + m2 ; // error ❌❌❌
```

we solve this problem using operator overloading.

mean type like Money we make it work like int or decimal with arithmetic  operation.


operator overloading syntax :
```cs
<AccessModifier> returnType operator <theOperator> (/*the parameter*/){

	return new returnType();
} 
```

to apply this in Money class

```cs
class Money
{
	private decimal amount;
	public decimal Amount => this.amount;

	public Money(decimal value)
	{
		this.amount = Math.Round(value,2);
	}

	public static Money operator +(Money m1 , Money m2)
	{
		var result = m1.Amount + m2.Amount;
		return new Money(result);
	}
		public static Money operator -(Money m1 , Money m2)
	{
		var result = m1.Amount - m2.Amount;
		return new Money(result);
	}
		public static Money operator *(Money m1 , Money m2)
	{
		var result = m1.Amount *+* m2.Amount;
		return new Money(result);
	}
}

// in Main
Money m = new Money(10);
Money m2 = new Money(30);

Money m3 = m + m2 ; // 40
m3 = m2 - m ; // 20
m3 = m2 * m ; // 300
```

![[Pasted image 20250804115544.png]]

if you want to overloading on ( > ) operator if you do that you must defined the ( < ) also to work.
 ```cs
 	public static bool operator >(Money m1 , Money m2)
	{
		return m1.Amount > m2.Amount;
	}
 	
 	public static bool operator <(Money m1 , Money m2)
	{
		return m1.Amount < m2.Amount;
	}
```

so anything compare must write the opposite the operator like 
(> → <) 
(>= → <= )
(== → != )

all the compare operator return bool; 

```cs
public static Money operator ++(Money m)
{
	var val = m.Amout++;
	return new Monry(--value) ;
}
```


----------------------------------

# --------------------------

# EP : 16

 ![[Pasted image 20250804120827.png]]

```cs
// in main
var p = new Person(); // print on console > this is Person Constructor
p.Name = "Ammar";


class Person
{
    public string Name { get; set; }
    
    public Person()
    {
        Console.WriteLine("this is Person Constructor");
    }
}
```

p reference store in stack and the data store in heap.

maybe the p instant  i don't use it again so we want erase it from memory.

**the Garbage Collection** do this thing automatically and implicit way.

**the Garbage Collection** in CLR (Command Language Runtime).

---
### Destructor 

**Destructor** : Method inside the class used to destroy instants of that class.

Destructor syntax :
```cs
~ClassName(){
 // body
}
```

add it in person class
```cs
// in main
var p = new Person(); // print on console > this is Person Constructor
p.Name = "Ammar";


class Person
{
    public string Name { get; set; }
    // constructor
    public Person()
    {
        Console.WriteLine("this is Person Constructor");
    }
    // destructor 
    ~Person()
    {
	    Console.WriteLine("this is Person Destructor");
    }
}
```

==**constructor call** automatically **when you create a object**.
**destructor call** automatically when **the object Destroy** (Dispose). ==


Object flagged to be destroyed when end of its scope reached. 
then when the garbage collection see this flag then destroy the object .

Garbage collection automatic memory management. 

1-![[Pasted image 20250805043225.png]]



2-![[Pasted image 20250805043300.png]]


3- ![[Pasted image 20250805043332.png]]


### When object get disposed ? 

1- End of Program Execution (Implicit).
2- Memory Full (Implicit).
3- `GC.Collect()` (Explicit).


to see the case 3

we create function make garbage.
```cs
static void MakeSomeGarabge(){
	Version V ;

	for(int i = 0 ; i < 1000 ; i++){
		v = new Version();
	}
}
```

in Main 
```cs
MakeSomeGarabge();
Console.WriteLine($"Memory before used Collection : {GC.GetTotalMemory(false):N0}");

GC.Collect(); // Explicit Cleaning
Console.WriteLine($"Memory after used Collection : {GC.GetTotalMemory(true):N0}");

```

`{GC.GetTotalMemory(false):N0}` 
N0 make the value do `,` between numbers. Like : 9,999,999  .

N make the value do `,` between numbers. Like : 9,999,999.00  .

so the result of this program :
![[Pasted image 20250805044713.png]]

------------------------------

# --------------------------

# EP : 17

![[Pasted image 20250805044847.png]]


Nested types : type defined within a class .

```cs
class A {
	
	class B{
	
	}
}
```

### connection between 2 different Project

if we want to make a connection between 2 different Project we add reference .
![[Pasted image 20250805081108.png]]

**How we can do that ?**
* create two project for example one console and other class lib 
* press on console click right
* choose add
* choose `Project reference `
* then add the other project
* in console project in program 
```cs
using ClassLibName
```
* now you can use the classes lib in the console

--------------------------------
### Access Modifier :

```cs
// in customLib we create to class
public class Person{

}

internal class internalPerson{

}
```

in `Program.cs` in console project

```cs
using CutomLib

// in main

//  work because the Person is defined as  public
Person p = new Person(); 

// didn't work because the internalPersin is defined as internal
internalPerson p2 = new internalPerson();


```

![[Pasted image 20250805082125.png]]
### Internal Member :

Internal member is public within the assembly.
mean work in his project only .
حتي لو عامله reference في project تاني مش هيتشاف

so we can use  `internalPerson` class in the Person
but we can't use it in `Program.cs`


| Access Modifier      | Accessibility                                                                   | Accessible Within Class | Accessible Within Same Assembly | Accessible from Derived Class | Accessible from Other Assemblies |
| -------------------- | ------------------------------------------------------------------------------- | ----------------------- | ------------------------------- | ----------------------------- | -------------------------------- |
| `private`            | Accessible only within the same class                                           | ✅                       | ❌                               | ❌                             | ❌                                |
| `protected`          | Accessible within the same class and by derived classes                         | ✅                       | ❌                               | ✅                             | ✅ (only via inheritance)         |
| `internal`           | Accessible within the same assembly (project)                                   | ✅                       | ✅                               | ✅ (if in same assembly)       | ❌                                |
| `protected internal` | Accessible within the same assembly or from derived classes in other assemblies | ✅                       | ✅                               | ✅                             | ✅ (only via inheritance)         |
| `private protected`  | Accessible within the same class and derived classes **in the same assembly**   | ✅                       | ✅                               | ✅ (if in same assembly)       | ❌                                |
| `public`             | Accessible from anywhere                                                        | ✅                       | ✅                               | ✅                             | ✅                                |

### Summary:

- Use **`private`** for strict encapsulation.
- Use `public to expose functionality to any consumer.
- Use `internal` to share code only within the same project/assembly.
- Use `protected` to allow inheritance access.
- Use `protected internal` or `private protected` for finer control in larger applications or frameworks.

----------------
### When we use Nested Types ?

if i have two class A and B .
A class is the only thing use class B . 

so instead of doing this 

```cs
class A {

}
class B{

}
```

we will do this 

```cs
class A {
	class B{
		//  we can't access B class out of A scope .
	}
}
```

مش بيفرق في ال execution بل بيفرق في نضافة الكود
why use nested types ?
* it does not pollute the global scope .
* nested class can access any thing in outer class;

The method of B implicitly have access to private members.
```cs
class A {
	private int x ;
	class B{
		//  we can't access B class out of A scope .
		void Method(){
			A a = new A();
			a.x = 10; // work
		}
	}
}
```


------------------
### Composite Type :

Composite Type : Composition is type of relationship between classes has A (Like the car has a motor so for each car has the filed from Motor class)


ex :
We have 3 classes Employee , Insurance and Department
```cs
class Employee
{
	public int Id { get; set; }
	public string Name { get; set; }
}

class Insurance
{
	public int PolicyId { get; set; }
	public string CompanyName { get; set; }
}

class Department
{
	public int Id { get; set; }
	public string Name { get; set; }
}
```

each employee has an Insurance so i want to add the insurance class in the employee class. - > composite type
```cs
class Employee
{
	public int Id { get; set; }
	public string Name { get; set; }

	public Insurance EmployeeInsurance{set; get;} 
}
```

you notice the employee class the only one access the Insurance class .
so we will apply the nested type .
==must the insurance class defined as public or defined the `EmployeeInsurance` as private .==

```cs
class Employee
{
	public int Id { get; set; }
	public string Name { get; set; }

	public Insurance EmployeeInsurance{set; get;} 
	public class Insurance
	{
		public int PolicyId { get; set; }
		public string CompanyName { get; set; }
	}
}
```

now in main if i try to use the `EmployeeInsurance` property we will get error.

```cs
// in main
Employee e = new Employee();

Console.WriteLine(e.EmployeeInsurance.CompanyName); 
// reference error
// because the EmployeeInsurance type is Insurance 
// How use Insurance class without new
// so the solution in constructor we create a new object in constructor of employee and assigned it to inital value
```

```cs
class Employee
{
	public int Id { get; set; }
	public string Name { get; set; }

	public Insurance EmployeeInsurance{set; get;} 
	
	public Employee() =>
		EmployeeInsurance = new Insurance{PolicyId = -1 , CompanyName ="N/A"};

	public class Insurance
	{
		public int PolicyId { get; set; }
		public string CompanyName { get; set; }
	}
}
```

so in main now work
```cs
// in main
Employee e = new Employee();

Console.WriteLine(e.EmployeeInsurance.CompanyName); // work // N/A
```

-----------------------------------
# --------------------------

# EP : 18

![[Pasted image 20250805100357.png]]
### Type Of Errors : 

#### 1. **Syntax Errors** : occur during development type mistake in code and compiler add Red Squiggly Line under error .
   
```cs
int x =0 ; 
While(x<10){  // while not While

}
```

**to see all the syntax error press on error list window .** 

--------------------------------------------------------
#### 2. **Runtime Errors** : Improper user input , improper Design Logic Or System Errors .
the error appear when the app run . 

```cs
var amount = 1000;
var members = 2 ;

members = Reduce(members , 2); // members = 2
var share = Distribute(1000 , members); // division by zero

static int Reduce(int members , int value){
	return members -= value ;
}

static int Distribute(int amount , int members){
	return amount / members ;
}
```

the Error get as an **exception**.

**Exception** : is an event , which occurs during the exception of a program , that disrupts the normal flow of the program instructions .

##### How to solve this error ?
we solve this problem with `Try Catch` 

```cs
try 
{
	/* the statement that may be get error */
	/* like */
	return amount / members ;
}
catch(Exception ex)
{
	/* the statement will executed in case exception is thrown */
	Console.WriteLine($"Unexpected Error {ex.Message}");
}
finally
{
	/* the statement will executed anyway */
	// any logic you want to executed if in case try or catch happend 
	// used for cleanups
	
}

// return zero if there is a error
return 0;
```

add try and catch on upper example
```cs
static int Distribute(int amount , int members){
	try 
	{
		return amount / members ;
	}
	catch(Exception ex)
	{
		Console.WriteLine($"Unexpected Error {ex.Message}");
	}
	finally
	{
		
	}
	
	return 0;
}
```

![[Pasted image 20250807025531.png]]

-------------------
#### 3. **Logical Errors** : Errors occur when the program is written fine but it does not produce desired result .

ex
```cs
static decimal ConvertCelsiusToFehrenhite(decimal celsius){
	var fehrenhite = 0m;
	fehrenhite = (celsius * 9 / 5) + 32 ;
	return fehrenhite;
}

static decimal ConvertFehrenhiteToCelsius(decimal fehrenhite){
	var celsius = 0m;
	// celsius = ( (fehrenhite -35 ) * 5 )/ 9 ; // true version
	celsius = fehrenhite -35  * 5 / 9; ; // false version
	return celsius;
}

// in main

var f = ConvertCelsiusToFehrenhite(0);
Console.WriteLine($"{0}C = {f}F") // 0 32

var c = ConvertFehrenhiteToCelsius(32);
Console.WriteLine($"{0}F = {c}C") // 32 12 ❌❌❌
```

-----------------------------

### Debagging : Tracing Bugs

![[Pasted image 20250807031506.png]]
![[Pasted image 20250807031815.png]]
to add the edit at runtime to check if the logic will be correct or no.

right like on the statement and add watch and edit the statement if correct edit the original code .


add watch we made it to see if our solution solve the problem or not at runtime .

-------------

# --------------------------

# EP : 19 Struct

![[Pasted image 20250807032155.png]]

### What Is Struct ?

**struct syntax :** 
```cs
struct structName {

}
```

**no parameter less constructor must have a parameters**
**parameter less is exist by default but is forbidden to write or use it .** 
```cs
struct structName {
	public structaName(/* parameter is a must */){
	
	}
}
```

**there's a field as class but we can't initialize it as class .**
```cs
struct structName {
	private int id ;
	private int id  = 16665 ; // ❌❌
	public structaName(/* parameter is a must */){
	
	}
}
```

**there's a property also as the class**
```cs
struct structName {
	private int id ;
	public int Id {get; set;}
	public structaName(/* parameter is a must */){
	
	}
}
```

**→ not supported for inheritance , but struct implicitly inheritance object base class .**

**→ not supported for protected and virtual access modifiers .** 

**→ not recommended for large data .**

**→ maximum for struct is 16 byte  ( recommended from expertise  developers) because store in stack .**

**→ struct is a value type .**

|Feature|Class|Struct|
|---|---|---|
|User Defined Type|✔|✔|
|Constructor|✔|✔|
|Parameterless Constructor|✔|✔|
|Support Fields|✔|✔|
|Field Initializer|✔|✘|
|Support Properties|✔|✔|
|Support Method|✔|✔|
|Support Event|✔|✔|
|Indexers|✔|✔|
|Operator Overloading|✔|✔|
|Finalizer|✔|✘|
|Support Inheritance|✔|✘|
|Implicitly Inherit Object Class|✔|✔|
|Recommended for Large Data|✔|✘|
|Value Semantic (Value Type)|✘|✔|
|Reference Semantic (Reference Type)|✔|✘|
|`new()` is Mandatory|✔|✘|

![[Pasted image 20250813015924.png]] 

**struct instance and its data stored in stack .**

before use the struct you must initialize the member fields via constructor or via `.` access  if public .

```cs
struct Student 
{
	public int id;
	public Student(int id){
		this.id = id
	}

	public void Show(){
		Console.WriteLine("this is a student struct")ك
	}

}

// in main

// first way
	Student s;
	s.id = 5;
	s.Show();

// second way
	Student s = new Student(5);
	s.Show();

// third way if there isn't constructor 
	Student s = new Student(); // make the id =0 ;
	s.Show();

// third way if there isn't member field we can access methods directly  after declare a struct
	Student s ;
	s.Show();
```


==Immutable objects== mean that once the constructor for an object has completed its execution , that instance can't be altered (تتغير) .

 ```cs
struct DigitalSize
{
	private long bit;
	
	private const long bitsInBit = 1;
	private const long bitsInByte = 8;
	private const long bitsInKB = bitsInByte *1024;
	private const long bitsInMB = bitsInKB * 1024;
	private const long bitsInGB = bitsInMB * 1024;
	private const long bitsInTB = bitsInGB * 1024;

	public string Bit => $"{(bit / bitsInBit):N0} Bits";
	public string Byte => $"{(bit / bitsInByte):N0} Byte";
	public string KByte => $"{(bit / bitsInKB):N0} KByte";
	public string MByte => $"{(bit / bitsInMB):N0} MByte";
	public string GByte => $"{(bit / bitsInGB):N0} GByte";
	public string TByte => $"{(bit / bitsInTB):N0} TByte";
	public DigitalSize(long bitrepersent)
	{
		this.bit = bitrepersent;
	}  
	public void show()
	{
		Console.WriteLine($"the bit representation {bit}");
	}
	
	public DigitalSize Addbit(long bit)
	{
	
		return Add(bit , bitsInBit);
	}
	public DigitalSize Addbyte(long bit)
	{
	
		return Add(bit, bitsInByte);
	}
	public DigitalSize AddKbyte(long bit)
	{
	
		return Add(bit, bitsInKB);
	}
	public DigitalSize AddMbyte(long bit)
	{
	
		return Add(bit, bitsInMB);
	}
	public DigitalSize AddGbyte(long bit)
	{
	
		return Add(bit, bitsInGB);
	}
	public DigitalSize AddTbyte(long bit)
	{
	
		return Add(bit, bitsInTB);
	}
	
	private DigitalSize Add(long value ,long scale)
	{
	
		return new DigitalSize(value * scale);
	}
}

// in main 
DigitalSize size = new DigitalSize(60000);
size.show(); // 

size = size.AddByte(4);
size.show(); // 
```

like time the 12:00 not 12:01

different between value type and reference type in struct :
```cs
// in main
DigitalSize ds = new DigitalSize(60000);
ds.show(); // 60000

// get new object
// ds not change after add byte
DigitalSize ds2  = ds.AddGbyte(1);
ds.show(); // 60000

ds2.show(); // ex 97978643246
```

so the struct is immutable by its nature.(غير قابل للتعديل)

but the class is mutable by its nature.

if you define the struct as `readonly` all fields must be `readonly`.

and you only can initialize from constructor.

```cs
readonly struct Age {
	public readonly int years;
	public int whatever ; // ❌❌❌❌ must define as readonly
}
```

`DateTime` is a built in struct .

```cs
DateTime dt = new DateTime();
Console.WriteLine(dt); // 0001-01-01 12:00:00 AM default
-------------------------------------
DateTime dt = new DateTime(2025,8,13);
Console.WriteLine(dt); // 2025-08-13 12:00:00 AM 
// the time here is default
-------------------------------------
DateTime dt = new DateTime(2025,8,13,04,21,00);
Console.WriteLine(dt); // 2025-08-13 04:21:00 AM 
------------------------------------------
DateTime dt = new DateTime(2025,8,13,04,21,00);
dt.AddDays(10);
Console.WriteLine(dt); // 2025-08-13 04:21:00 AM 
// because the struct is immutable
-----------------------------------------------------
// how to add this days to the date
DateTime dt = new DateTime(2025,8,13,04,21,00);
dt = dt.AddDays(10); // create now instance of the struct
Console.WriteLine(dt); // 2025-08-23 04:21:00 AM 
```

**primitive types is a struct .**

to know that right click on data type and go to definition .

so if i do 
```cs
int x = 9;
x = x + 1 ;
// x will store in another place and initialize it with 10
```
string is a ref type (class).

we will know how make class mutable .

# --------------------------
# EP : 20 Enum

![[Pasted image 20250813050744.png]]

Enum : Strongly typed named constants( ثوابت ليها اسم تحمل صفة نوع البيانات ) .
 less memory 

**Simple Enum :**
they start with zero and increase by one following the definition text order .
if you gave any one a value the `next value = last value + 1` .

```cs
enum Month{
JAN = 1, //0
FEB,
MAR,
APT,
MAY,
JUN,
JUL,
AUG,
SEP,
OCT,
NOV,
DEC,
}
```
now i have a new data type call Month .

default datatype is int 
to convert it explicitly for ex to long .
it can't convert to string ❌❌❌❌❌

```cs
enum Month : long
{
	JAN = 1, 
	FEB,// 2
	MAR,
	APT,
	MAY,
	JUN,
	JUL,
	AUG,
	SEP,
	OCT,
	NOV,
	DEC,
}
```

```cs
//in main 
Console.WriteLine(Month.FEB); // FEB -> string
Console.WriteLine((int)Month.FEB); // 2 -> int
// if user give me the day as string and want to get the value from enum
//ex
var month = "feb";
Console.WriteLine(Enum.Parse(typeof(Month), month)); // error because the enum is case sensitive
// to avoid this error use tryparse(day , out the same type of enum (Month))

if (Enum.TryParse(month , out Month month2)){
    Console.WriteLine(month2);
}
==
// using IsDefined -> work with value and string
// if month =2 or FEB is the same
if(Emun.IsDefined(typeof(Month),month)){
	Console.WriteLine(Enum.Parse(typeof(Month), month));
}else{
	Console.WriteLine("Not exist");
}
//////////////////////////////////
var day3 = 4;
if(Enum.IsDefined(typeof(Month), day3))
{
	Console.WriteLine((Month)day3);
}
```

**Flag Enum :** like on and off ( 1,0 )
```cs
// doctor work in specific days
[Flags]
enum Day{
	NONE     = 0b_0000_0000,     // 0
	MONDAY   = 0b_0000_0001,     // 1
	TUESDAY  = 0b_0000_0010,     // 2
	WEDNEDAY = 0b_0000_0100,     // 4
	THURSDAY = 0b_0000_1000,     // 8
	FRIDAY   = 0b_0001_0000,     // 16
	SATURDAY = 0b_0010_0000,     // 32
	SUNDAY   = 0b_0100_0000,     // 64
	BUSYDAY  = MONDAY | TUESDAY | WEDNEDAY | THURSDAY | FRIDAY ,
	WEEKEND  = SATURDAY | SUNDAY // 96 = 0b_0110_0000
}

// in main
var day = ( DAY.SATURDAY | DAY.SUNDAY ) ;
if( day.HasFlag(DAY.WEEKEND)){
	Console.WriteLine("enjoy your weekend");
}
```

in days we make this value to make one if different bit each time to use or bitwise . 


to loop on Enum using `foreach`
```cs
// return as string so to get int must convert this string to enum object first
foreach (var month in Enum.GetNames(typeof(Month)))
{
    Console.WriteLine($"{month} : {(int)Enum.Parse(typeof(Month), month)}");
}
// return enum object 
foreach (var month in Enum.GetValues(typeof(Month)))
{
    Console.WriteLine($"{month} : {(int)month}");
}
```

we use the Enum because :
→ readability
→ easy of use
→ Less Memory 


# --------------------------
# EP : 21 Inheritance

![[Pasted image 20250813085419.png]]
### Inheritance :
##### **1-What's the inheritance ?**
→ technique which let a type acquire all the properties and behaviors its parent type automatically . 
##### **2-Why inheritance ?**
→ reusability .
→ maintainability .
→ extensibility (قابلية المدد) .
##### **3-How ?**
using `:` operator 
```cs
class Animal 
{
	public void Move(){
		Console.WriteLine("Moving");
	} 
}
class Eagle : Animal 
{
	public void Fly(){
		Console.WriteLine("Flying");
	} 
}
class Falcon : Animal 
{
	public void Fly(){
		Console.WriteLine("Flying");
	} 
}
```
now Eagle class can see and use all **public** , **protected** and **internal** member .


→ **A Protected Member** is accessible within its class and by derived class instances ( inheritance class ).

→ class can inherit from only a single class but can itself be inherited by many classes .

------------------
##### `UpCasting` :
creates a base class reference from a subclass reference.

convert from parent to child
```cs
var e = new Eagle();
Animal a = e;
```


##### `DownCasting` :
creates a subclass reference from a base class reference.
must use casting.
```cs
var e = new Eagle();
Animal a = e; // upcasting 
Egale e2 = (Egale) a; // downcasting
```
main
```cs
a.fly(); // ❌❌❌❌
e2.fly(); // aquire the eagle proper ty
```

[[Upcasting and DownCasting]]

---
what if
```cs
var e = new Eagle();
Animal a =e;
Falcon f = (Falcon) a ; // runtime error get exception
```

to avoid this error we use `as` or `is.

```cs
// if a not a falcon will return null 
// as
Falcon f = a as Falcon ;
if(f != null) f.fly();
-----------------------------------
// is
if(a is Falcon){
	Console.WriteLine("a is a falcon");
	f.fly();
}

```

--------------
#### Abstract :
Abstract can't be instantiate it direct (create object from him) but you can be instantiate from subclass.

```cs
abstract class Animal 
{
	public void Move(){
		Console.WriteLine("Moving");
	} 
}
class Eagle : Animal 
{
	public void Fly(){
		Console.WriteLine("Flying");
	} 
}
```
in main
```cs
Animal a = new Animal(); // error Animal is an abstract class
Eagle e = new Eagle();
```

Abstract : 
→ ==with class== : make class can't be instantiate it direct 

→ ==with method== : the method doesn't have body and must override in another inheritance class . 

------------------------
#### Sealed :
**sealed** can't be **inherited** .

```cs
abstract class Animal 
{
	public void Move(){
		Console.WriteLine("Moving");
	} 
}
sealed class Eagle : Animal 
{
	public void Fly(){
		Console.WriteLine("Flying");
	} 
}
class AmiercanEagle :Eagle{ // cannot derive from Eagle because it is sealed 

}
```

---------------------------
### Polymorphism :

definition : one name many forms . 

![[Pasted image 20250816064613.png]]

to make the subclass can edit the method in base class must this method define as `virtual` and in subclass use the `override` keyword to modify it .

##### **Virtual Member override condition :**
→ ==First Condition== : **Base Class** Declare Member as **virtual** (has default implementation) .

→ ==Second Condition== : Add **Override** keyword to the override method to (may override).

ex:
```cs
class Animal 
{
	public virtual void Move(){
		Console.WriteLine("Moving");
	} 
}
class Eagle : Animal 
{
	public override void Move(){
		base.Move();// call move from base class  
		Console.WriteLine("The Eagle");
	}
	public void Fly(){
		Console.WriteLine("Flying");
	} 
}
Eagle e = new Eagle();
e.Move(); // Moving The Eagle
```

`this` keyword call class member .
`base` keyword call base class members .

-----------------
##### **Abstract Member Override :**
→ ==First Condition== : Abstract member must be in abstract class and it hasn't  to default implementation (no body).

→ ==Second Condition== : Add **Override** keyword to the override method to and overriding is **mandatory** .

```cs
abstract class Animal 
{
	public abstract void Move(); 
}
class Eagle : Animal 
{
	public override void Move(){
		Console.WriteLine("The Eagle");
	}
	public void Fly(){
		Console.WriteLine("Flying");
	} 
}
```

because Eagle inherit from Animal and Animal have an Abstract method so must override the method in Eagle .

> Interview Question :
>What's the Different between Virtual and Abstract Member ? 


Sealed Member can not be overriden in the derived class .
```cs
abstract class Animal 
{
	public abstract void Move(); 
}
class Eagle : Animal 
{
	// Sealed
	public sealed override void Move(){
		Console.WriteLine("The Eagle");
	}
	public void Fly(){
		Console.WriteLine("Flying");
	} 
}
class AmericanEagle : Animal 
{
	// Error ❌❌
	// Move mehtod define in other class with the sealed keyword 
	public  override void Move(){
		Console.WriteLine("The AmericanEagle is moving");
	}
}
```

---------------------------
### Object Class :

**Object Class :** the ultimate base class for all .NET Type .

if the class not inherit from any class he will inherit from Object class implicit
```cs
class Animal 
{
	public void Move()
	{
		Console.Write("Moving");
	}
}

// compiler will do that implicit 
class Animal : Object 
{
	public void Move()
	{
		// if i write base here all member in base class i can use them
		base.
		Console.Write("Moving");
	}
}
```

ex :
Animal have a Name and Move method use `ToString` method to concatenate the info and return it if i print the class like 
```cs
Console.Write(Animal);
```

`ToString` : Default textual representation . 

```cs
class Animal 
{
	public string Name{get; set;}
	public void Move()
	{
		Console.Write("Moving");
	}
	// if i write override and ctrl + space you will find the method from base class (Object here) as To string
	public  override string ToString(){
		//return base.ToString(); // the default action
		return $"{Name} is an Anmial Name"
	}
}
``` 

we use the `GetType` method to know type of object
```cs
Eagle e = new Eagle();
console.WriteLine(e.GetType()); // projectName.className
```

-----------------------
#### Constructor with inheritance :

The Base class's constructors are accessible to the derived class but are **never automatically inherited** .

```cs
class BaseClass{
	public int x;
	public BaseClass(){ }
	public BaseClass(int value){
		this.x = value ;
	}
}
class SubClass : BaseClass{

}

// in main
SubClass sc = new SubClass(123); // ❌❌❌❌❌
```

to solve that must create constructor in subclass and call constructor from base class with `base` keyword .

```cs
class BaseClass{
	public int x;
	public BaseClass(){ }
	public BaseClass(int value){
		this.x = value ;
	}
}
class SubClass : BaseClass{
	public SubClass(int scValue) : base(scValue){
	}
}
```

Base-Class constructors always execute first this ensure that base initialization occurs before specialized initialization.  

real case :
**Requirement:** App to calculates the monthly salary slip  
**Minimum Hours required:** 176 hours (8 × 22)  
**Basic salary =** 176 × Wage  
**Overtime =** additional hours × 1.25 × hourly cost

### Types of employees
**Directors**
- manager’s allowance (5% of total salary)

**Maintenance**
- hardship allowance ($100 / month)

**Sales**
- commission percentage on volume of sale

**Programmers**
- bonus 3% of his total salary if all assigned task were accomplished

![[Pasted image 20250816091302.png]]

#### Solution :
1- Employee class
```cs
class Employee
{
    protected const int MinimumLoggedHours = 176;
    protected const decimal OverTimeRate = 1.25m;
    protected int Id { get; set; }
    protected string Name { get; set; }
    protected decimal LoggedHours { get; set; }
    protected decimal Wage { get; set; }

    protected Employee(int id , string name, decimal loggedHours, decimal wage)
    {
        this.Id = id;
        this.Name = name;
        this.LoggedHours = loggedHours;
        this.Wage = wage;
    }
    protected virtual decimal Calculate()
    {
        return CalculateBaseSalary() + CalculateOverTime();
    }

    private decimal CalculateBaseSalary()
    {
        return LoggedHours * Wage;
    }

    private decimal CalculateOverTime()
    {
        var additionalHours = ((LoggedHours - MinimumLoggedHours) > 0 ? LoggedHours - MinimumLoggedHours : 0);

        return (additionalHours * Wage * OverTimeRate);
    }
    public override string ToString()
    {
        var type = GetType().ToString().Replace("Test2", "");
        return $"{type}"
            +$"\nId :{Id}" 
            + $"\nName : {Name}" 
            + $"\nLoggedHours : {LoggedHours}" 
            + $"\nWage : {Wage}"
            + $"\nBase Salary : {CalculateBaseSalary()}" 
            + $"\nOvertime : {CalculateOverTime()}";
    }

}
```

2- Manger class
```cs
class Manager : Employee

{
    protected decimal AllowanceRate = 0.05m;
    public Manager(int id, string name, decimal loggedHours, decimal wage)
    : base(id,name,loggedHours,wage)
    {

    }



    protected override decimal Calculate()
    {
        return base.Calculate() + CalculateAllowance();
    }

    private decimal CalculateAllowance()
    {
        return (AllowanceRate * base.Calculate());
    } 
    public override string ToString()
    {
        return base.ToString() 
            + $"\nAllowance : {CalculateAllowance()}"
            + $"\nNetSalary : {this.Calculate()}";
    }
}
```

3-Maintenance Class
```cs
class Maintenance : Employee

{
    protected decimal Hardship = 100m;
    public Maintenance(int id, string name, decimal loggedHours, decimal wage)
    : base(id, name, loggedHours, wage)
    {

    }



    protected override decimal Calculate()
    {
        return base.Calculate() + Hardship;
    }


    public override string ToString()
    {
        return base.ToString()
            + $"\nHardship: {Hardship}"
            + $"\nNetSalary : {this.Calculate()}";
    }
}
```

4- Sales class
```cs
class Sales : Employee

{
    protected decimal SalesVolum { get; set; }
    protected decimal Commission { get; set; }
    public Sales(int id, string name, decimal loggedHours, decimal wage,decimal salesVolum,decimal commission)
    : base(id, name, loggedHours, wage)
    {
		this.Commission = commission;
		this.SalesVolum = salesVolum;
		
    }
    protected decimal CalculateBouns()
    {
        return SalesVolum * Commission; 
    } 


    protected override decimal Calculate()
    {
        return base.Calculate() + CalculateBouns();
    }

    public override string ToString()
    {
        return base.ToString()
            +$"\nCommission : {Commission}"
            + $"\nBouns : {CalculateBouns()}"
            + $"\nNetSalary : {this.Calculate()}";
    }
}
```

5-Developer Class
```cs
class Devoloper : Employee

{
    protected const decimal Commission = 0.03m;
    protected bool TackCompleted { get; set; }

    public Devoloper(int id, string name, decimal loggedHours, decimal wage, bool taskcompleted)
    : base(id, name, loggedHours, wage)
    {
        this.TackCompleted = taskcompleted;
    }



    protected override decimal Calculate()
    {
        return base.Calculate() + CalculateBouns();
    }

    protected decimal CalculateBouns()
    {
        if(TackCompleted)
            return (Commission * base.Calculate());
        return 0;
    }
    public override string ToString()
    {
        return base.ToString()
            +$"\nTask Completed : {(TackCompleted ? "Yes" : "No")}"
            + $"\nAllowance : {CalculateBouns()}"
            + $"\nNetSalary : {this.Calculate()}";
    }
}
```

6- Main Program
```cs
static void Main(string[] args)
{
	Manager manger = new Manager(100 ,"Tamer A.",180,10);
	Maintenance m = new Maintenance(200,"Salah M.",177,8.5m);
	Sales s = new Sales(300,"Ahmed M.",160,8.5m);
	Devoloper d = new Devoloper(400,"Ammar A.",188,15m,true);
	Employee[] employees =
	{
		manger,
		m,
		s,
		d
	};
	foreach (var employee in employees)
	{
		Console.WriteLine("\n--------------------------");
		Console.WriteLine(employee);
	}

	
	Console.ReadKey();
}
```

---
#### Hiding Inherited members 
**Hiding Inherited members** : A base class and a subclass can define identical members sub class will hide the implementation of the parent .
```cs
class BaseClass{
	public int value = 10;
}
class SubClass : BaseClass {
	public int value = 20; // Warning
}
// in main
SubClass sc = new SubClass();
Console.Write(sc.value); // 20
```
to avoid this warning use `new` keyword after public in subclass
```cs
class SubClass : BaseClass {
	public new int value = 20; // Warning
}
```
# --------------------------
# EP : 22 Interface

 ![[Pasted image 20250817184343.png]]

An abstract class is meant to be used as the base class from which other classes are derived.

The derived class is expected to provide implementation for the member functions that are not implemented in the base class .

A derived class that implements all the missing .

ex : 
```cs
abstract class Vehicle
{
	protected string Brand { get; set; }
	protected string Model { get; set; }
	protected int Year;

	public Vehicle(string brand, string model, int year)
	{
		Brand = brand;
		Model = model;
		Year = year;
	}
}

class Honda : Vehicle
{
	public Honda(string brand, string model, int year) : base(brand , model , year)
	{

	}
}

// in main 
Vehicle v = new Vehicle("Honda" , "civic" , 2021); //❌❌❌ 
Vehicle v = new Honda("Honda" , "civic" , 2021); // upcasting
Honda h =  new Honda("Honda" , "civic" , 2021);

```

if i have `CaterPillar` Vehicle have a Functionality  More than normal vehicle . 
where add this Functionality ?
1- may be add in Vehicles but → Do all Vehicles have these Functionality ?
2- Add Loader class but you can inherit only from one class . 

so we need interface .

-------------------
#### interface :

##### What?
- An **interface** is like a **contract** in C# that defines a set of methods, properties, events, or indexers — but without implementation (no body).
- A **class** or **struct** that implements the interface must provide the actual implementation of the member defined in the interface.
----
##### Why ? 
- **Standardization** → Interfaces enforce a rule that classes must follow.  
    (e.g., if all payment systems implement `IPayment`, you know they all have `Pay()` method).
    
- **Multiple inheritance in C#** → A class can’t inherit from multiple classes, but it can implement multiple interfaces.
    
- **Loose coupling** → You can program against the interface, not the implementation.  
    (Helps in testing, scaling, and flexibility).
    
- **Polymorphism** → You can use different classes interchangeably if they share the same interface.

------
##### How ?

==Naming Convention for best practices  the name start with `IinterfaceName`.==

ex : 
```cs
public interface ILoader{
	void Load();
	void UnLoad();
}
```

I can inherit class and interface at the same Time 
```cs
class CaterPillar : Vehicle , ILoader
{
	// must implementation this method
	void Load (){
		Console.WriteLine("Loading");
	}
	void UnLoad (){
		Console.WriteLine("UnLoading");
	}
}
```
abbreviate in vs studio to implementation method press on interface and `ctrl + .` and press implement interface .

**we can inherit a multi interface .**

```cs
interface IDrivable {
	void Move();
	void Stop();
}
```

there's to way to implement the interface implicit and explicit .

[[Different between explicit and implicit]]

we use explicit  if interfaces have the same method with the same fingerprint 

```cs
interface IMove{
	void Move();
}

interface IDisplay{
	void Move();
}

class Vehicle : IMove , IDisplace {
	IMove.Move(){
		// body
	}
	IDisplace.Move(){
		// body
	}
} 
```
but can't use it with object
```cs
// main
Vehicle v = new Vehicle();
v.Move(); // ❌❌❌❌❌

IMove m = new Vehicle(); // UpCasting
```

#### **Is `IMove m = new Vehicle();` **Upcasting**?**

→ Yes — this is **upcasting**.
##### Why?

- `Vehicle` implements `IMove`.
- So, `Vehicle` **is-an** `IMove`.
- Assigning a `Vehicle` object to an `IMove` reference is **upcasting** (moving from a more specific type → to a more general type / interface).
    
This is exactly like:
```cs
Dog d = new Dog();
Animal a = d; // Upcasting: Dog → Animal
```
Here:

- `Vehicle` → concrete class (child).
- `IMove` → interface (parent contract).
- So, the assignment is **upcasting**.

---

##### 🔹 Why do we need this?

Because with **explicit implementation**, you cannot call `Move()` from the `Vehicle` object directly:

```cs
Vehicle v = new Vehicle();
// v.Move(); ❌ Error: not accessible
```

You must **upcast** to the interface type to access the method:

```cs
IMove m = v;     // Upcasting
m.Move();        // Works
```

---
#####  Summary

-  **Yes, `IMove m = new Vehicle();` is upcasting**.
- **Reason**: `Vehicle` is a subtype of `IMove` (implements it).
- With **explicit implementation**, upcasting is required to access those interface members.

-----------------------------------------------------
-----
#### -
in interface we can add default implementation this feature start after `C# Version-8 `
but these other method must be explicit implementation like `IMove.Move()` .
ex :
```cs
interface IMove{
	void turn(){
		Console.WriteLine("Turning");
	}
	void Move();
}
class Vehicle : IMove
{
	void IMove.Move(){
		Console.Write("Moving");
	}
}

// in main

IMove m = new Vehicle();
m.Move();
m.turn();
```


----------------
#### Tight Coupling vs. Loose Coupling

→ [[Tight Coupling vs. Loose Coupling]] .

* **Tight Coupling** : Means one class is dependent on another class .

* **Loose Coupling** : Means one class is Dependent on interface rather than class .



Loose Coupling example :
```cs
interface IPay
{
	void Pay(decimal amount);
}

class Cash : IPay
{
	public void Pay(decimal amount)
	{
		Console.WriteLine($"Cash Payment : {Math.Round(amount , 2):N0}");
	}
	public override string ToString()
	{
		return $"the amount of {GetType().ToString().Replace("Test2.","")} Payment";
	}
}
class Debit : IPay
{
	public void Pay(decimal amount)
	{
		Console.WriteLine($"Debit Payment : {Math.Round(amount, 2):N0}");
	}
	public override string ToString()
	{
		return $"the amount of {GetType().ToString().Replace("Test2.", "")} Payment";
	}
}
class Visa : IPay
{
	public void Pay(decimal amount)
	{
		Console.WriteLine($"Visa Payment : {Math.Round(amount, 2):N0}");

	}
	public override string ToString()
	{
		return $"the amount of {GetType().ToString().Replace("Test2.", "")} Payment";
	}
}
class MasterCard : IPay
{
	public void Pay(decimal amount)
	{
		Console.WriteLine($"MasterCard Payment : {Math.Round(amount, 2):N0}");

	}
	public override string ToString()
	{
		return $"the amount of {GetType().ToString().Replace("Test2.", "")} Payment";
	}
}
class Cachier 
{
	private IPay _ipay;
	public Cachier(IPay ipay)
	{
		this._ipay = ipay;
	}

	public void Checkout(decimal amount)
	{
		_ipay.Pay(amount);
	}

	public override string ToString()
	{
		return _ipay.ToString();
	}
}

// in main
Cachier[] ca2 = 
{
	new Cachier(new Cash()),
	new Cachier(new Debit()),
	new Cachier(new Visa()),
	new Cachier(new MasterCard()),

};

foreach (var item in ca2)
{
	Console.WriteLine($"{item}");
	decimal amount = int.Parse(Console.ReadLine());
	item.Checkout(amount);
}

```



# --------------------------
# EP : 23 GENERICS

![[Pasted image 20250818052839.png]]


