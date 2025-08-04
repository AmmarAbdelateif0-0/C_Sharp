
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
	* dynamic is an object
```cs
dynamic result = 300; // result is a intger
result = "Ammar"; // result is a string
result = 1f; // result is a float
```

---------------------------------------------
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
### reference type

```cs
var s1 = "hello";
var s2 = "hello";
var s3 = s1 == s2 ;
console.WriteLine(s3); // true
```

how we get true although s1 and s3 in the diff address?   
	CLR internally calls `IsEqual()` that's why the result is true . so the CLR get the data for each string and compare char by char.


----------------------------------------
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

يعني لو هتعرفها ب var لازم تكتب نوعها و تعمل new
لو هتعرف نوعها من الاول مش لازم 

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
	"ali",
	"mahmoud",
	"tamer",
	"ammar",
	"b3dsh"
};

// to get first element in array
console.WriteLine(friends[0]); //ali

// to get the first 2 element 
// index of 2 mean here 2 not included
console.WriteLine(friends[..2]); //ali mahmoud 2 here is index not included
// skip first 2 element
// index of 2 mean here 2 is the first element
console.WriteLine(friends[2..]); //tamer ammar b3dsh

// skip first 2 element and get the element till 4 element
console.WriteLine(friends[2..3]); // tamer

//skip first 2 element and get the next 2 elemnt
console.WriteLine(friends[2..^2]); // tamer ammar 

```

i can save the range
```cs
var sliceRange = 2..^3
console.WriteLine(friends[sliceRange]); // tamer ammar b3dsh
```

----------------------------------------
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
s1 = s1 ?? "Ammar";
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


```cs
int cardNo = 13;
string cardName =  switch{
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

start: 
if(i<=5){
	console.WriteLine(i);
	++i;
	goto start;
}
```


-------------------------------
# EP : 07
### content :
![[Pasted image 20250729125358.png]]

anything in `.NET` his root its an object .

why `int` has a blue color and `object` has a green ?
→ `int` is alias name for `Int32`.
→ `short` is alias name for `Int16`.
→ `long` is alias name for `Int64` .

--------------------------------------
### implicit conversion :

change variable data type from one to another automatically .

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

if i want check the L value in the range of int
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
int x =10;   // value type

Object obj ; // reference type store in heap

obj = x; // conversion done implicitly (boxing)

int y = obj ; //  ❌❌❌❌

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

if(int.TryParse(stringValue , out int number)){
	console.WriteLine(number);
}
```

-------------------------
### Convert Class
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
string stringValue = "120";
var i = Convert.ToInt32(stringValue);//  overflow exception
```


-----------------------------
### Bit converter 

`BitConverter.GetBytes()` convert number to array of bytes
كل بايت بيستجل الجزء ال متخزن فيه .

```cs
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
<ClassModifier> class <ClassName>{
	// Body
}
```

==Class Members==
![[Pasted image 20250731044413.png]]

**constant** **syntax**: must assigned to variables.

```cs
<AccessModifier> const <DataType> <ConstName. = <Value>;
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
// Declaration <type> <objectName>
// Assignment  <objectName> = new <Type>();
// initialization  <type> <objectName> = new <Type>();
```

ex
```cs
Employee e1 = new Employee();
e1.Fname = "Ammar";
e1.Lname = "Ammar";
e1.Wage = 66.5;
e1.LoggedHours = 250;
// access constant must my class name
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

![[Pasted image 20250731052140.png]]

---------------------------------------------------

-----------------------------

# EP : 09

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

static and const store in heap in place the garbage collection can't reach there to delete data.

![[Pasted image 20250731062747.png]]

| const                                                                     | static                                                                             |
| ------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| constant is a promise that can not be changed after has been initialized. | static member is a shared variable that can be changed after has been initialized. |

-------------
##### ==**Instant Method : is called by object .==**
##### ==**Static Method is called by TypeName .==**
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
 
 **pass by ref** : means you are pass a copy in memory of **the actual parameter's address** , that is passed in.
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
	   age =0;
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

==**Method Overloading**== is a common way of implementing **Polymorphism**.

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
public void PrintEvent(int[] original){
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
public void PrintEvent(int[] original){
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
<AccessModifier> <TypeName>(/*class name*/)( Parameter<list> ){
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
 public  Date(int day, int month, int year)
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

if Access Modifier for constructor is private so we cann't create instance class.
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


public  Date(int day, int month, int year)
 {
     this.day = day;
     this.month = month;
     this.year = year;
 }
```

if i want make data to be read only and can't modify , we use `readonly keyword`.
`readonly` → make variable read only .
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

// in main function
Date d  = new Date(9,4,2003);   // 9/4/2003
Date d2 = new Date(4,2003);     // 1/4/2003
Date d3 = new Date(2003);       // 1/1/2003

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
* fourth Way with constructor and object initializer . 
```cs
Employee e = new Employee(1){
	Fname = "Ammar",
	Lname = "abdo"
}
```

-------------------
### Private Constructor and Factory Method :

private constructor : anyone want to make an instance of class must do that in the class.
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

# EP : 11

### content :
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

<AccessModifier> <DataType> <FieldName> {get; set;}
```
##### ==**abbreviation to create property**==
```cs
prop + tab + tab
```

→ **value** is a reserved keyword when i use set with property the value which get from user store in it. 

==→ we can create a property without field== (**like `IsZero`** we well see next example).
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
we use private with set

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

 this concept called Backing Field (the field which we will store in (set) and read from (get).
 
![[Pasted image 20250801071108.png]]

benefits from using property :
→ Validation when i set value for it  when variable defined as public i haven't validation . 
→

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
-> delete set accessor no one can set the property except at defination .
->  the `SetAmount()` method access the `_amount` field  directly. 

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



----------------------------

# EP : 12

### content :
![[Pasted image 20250801083727.png]]

  index this feature make us can access the element in data type which this data is a collection of datatype like (array and string).

```cs
int[] arr = {1,2,3,4,5};
arr[2] = 33; //{1,2,33,4,5}

string s = "Ammar";
s[1]= "s"; // error we can't modifiy the string after initialized
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
	// is a variable not method
	public string Address => string.Join(".", this.segments);
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

to know the maximum length for rows `GetLength(0)`
to know the maximum length for columns `GetLength(1)`

---------------------------------

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
# EP : 15
![[Pasted image 20250804071731.png]]