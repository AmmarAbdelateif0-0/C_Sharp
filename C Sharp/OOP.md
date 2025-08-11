## Day 1 Introduction

Object is an instant from class.
```cs
--ex
Car c = new Car();
```

Class is a logical presentation and Object is a physical presentation 
اطالما قادر تقول علي الحاجه هي من نوع ايه و كمان تقول مواصفات ليها بعينها يعني تقول طولها كذا و عرضها كذا ووزنها كذا مثلا يبقى دا object

When we are objects from the same class ,we must be the same thing.
==False ex ==
I am a door , and he is a table so we aren't in the same class
==True ex ==
I am a blue car and he is a red car so we are in the same class 
I hope you understand that.

```cs
class car {
	string name;
	double speed;
	int Model;

	void MoveForward(){
	
	}
	void Stop(){
	
	}
}

// in main
Car c = new Car();
c.Model = 2020; // ❌❌❌
// because the Model haven't accrss modifier
```

==**Abstraction**== : you decide if this feature will be in my class or not depend on my business Goal.
يعني بيحدد انهي هيكون موجود في الكلاس و مين ال مش هيكون موجود 

**==Encapsulation==** : the concept make you define which filed the user can access or not .
يعني بيحدد  ال variables and method ال في ال class ايه ال هتكون private عشان تعملها hide
via ==**Access Modifier**== .
→ public
→ private
→ internal.
→ protected 

if i didn't use any access modifier the variable will be define as a private by default .

in the same class we treat with variables as public . 

public make you can't valid the data .  

ex : 
any car price must be larger than 5000
```cs
public class Car
{
	private int price;
	public string name;

	public void SetPrice(int price)
	{
		this.price = price > 5000 ? price : 5000;
	}

	public int GetPrice()
	{
		return this.price;
	}
}
```

**==why we use private access modifier ?==**
1. for security .
2. hide more details .
3. to control the data validation  .


Facebook Class
```cs
public  class FacebookAccount
	{
	public string Email;
	private string Password; 
	
	public void SetPassword(string newPassword)
	{
		if (CheckValidationPassword(newPassword))
		{
			this.Password = newPassword;
		}
	}
	public void SetNewPassword(string oldPassword, string newPassword)
	{
		if (CheckValidationPassword(newPassword)  )
		{
			if (oldPassword == this.Password)
			{
				this.Password = newPassword;
			}
			else
			{
				Console.WriteLine("Wrong Password");
			}
		}
		else
		{
			Console.WriteLine("InValid Password ");
		}
	}
	
	private bool CheckValidationPassword(string password)
	{
		if (password == "dsa")
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
```

**==NOTED : Good Practice==**
make class about only one theme and method do only one thing for readability.

---------------------------

 
# ---------------------------------

## Day 2 Details about object behind the scenes and Constructor

instruction move from Disk to RAM
Disk store code.
RAM store data.

RAM include two places (Stack , Heap).

When data Store in stack and when data store in heap ?

Stack : 
1. any Local Variable (may be value type or reference type as object ref) .
2. Call functions and parameters  (during execution ) .

Heap :
1. Dynamic Allocation  (anything store in runtime) .
2. reference type .


value type as (Struct , Enum , and primitive Data Types ) .
Reference Type as Class .

**value type** mean the variable store data directly .
**reference type** mean the address( in heap) for the data store in stack and the actual data store in heap
![[Pasted image 20250810000309.png]]

So the num is a value type and c is a ref type .
object store in heap and its address store in stack .
so to treat with object you must have the reference to that object . 

any local variable must initialize it before use it or use NULL if ref type and any other value if value type .

```cs
//case 1
Car c ;
c.price = 1999; // get error Use of unassigned local variable 'c'
// at compilation time 

//case 2
Car c = NULL ; 
c.price = 1999; // get error at runtime
```

==**member object** initialize by default in heap after i create object== 
→ if int , double or other = 0
→ if bool = false
→ if object = NULL
→ if string = NULL ;

```cs
Car c = new Car();
console.WriteLine(c.price); // 0
console.WriteLine(c.Name); // NULL
```

we can create multi ref for one object
```cs
Car c = new Car();
Car c2 = c;
c.Price = 2000;
c2.Price = 6500;
Console.WriteLine(c.Price); // 6500 
```


The method write only one time in memory and all object call it  so :
==**how the method know which object call it and how use the field for the object ?**==
-> compiler do this job automatically 

so compiler do that behind the scene like : 
```cs
c.display();
// compiler do somrthing like this
display(c);
// and in implemention add input parameter as ref automatically 
public void display(Car this){
	Console.WriteLine($"Number : {this.number} Price : {this.price}");
	// or without this
	Console.WriteLine($"Number : {number} Price : {price}");	
}
```

what if i call method inside another method the compile do the same 
```cs
public void Move(Car this){
	this.speed = 10;
	Display(this);
}
```
**==so this keyword is a ref type point to current object .==**

---
==**ex**==
employee class have (name , id , salary)
 i want add feature make us can't create any object from employee without add values for this fields .

to do  this feature we use **the constructor** . 
```cs
public class Employee{
	private int id ;
	private string name ;
	private decimal salary ;
	// constructor 
	public Employee(int Id , string Name ,decimal Salary ){
		this.id = Id;
		this.name = Name;
		this.salary = Salary;
	}
}
```


the constructor called only when i create object.
when i create object the compiler create empty constructor by default .
```cs
Employee e = new Employee(); 
// here we call the instructor
// if exist we call it if not compiler create empty constructor by default
```

to stop the program we use Exceptions
```cs
throw Exception();
```


 what if we want to create object only if the salary of employee larger than 3000
```cs
public Employee(int Id , string Name ,decimal Salary ){
	this.id = Id;
	this.name = Name;
	this.salary = Salary >= 3000 ? Salary : throw Exception() ;
}
```


**==so we use the constructor to control how people create an object from class.==**

we can create more than one constructor by overload concept .
```cs
//1
public Employee( ){

}
//2
public Employee( decimal Salary ){
	this.salary = Salary >= 3000 ? Salary : throw Exception();
}
//3
public Employee(int Id , string Name ,decimal Salary ){
	this.id = Id;
	this.name = Name;
	this.salary = Salary >= 3000 ? Salary : throw Exception();
}
```

and we create an object you define which constructor will be called .


**==we can't create a object without constructor  till :==**
→ the constructor create by you .
→ the constructor create by compiler .

==**The constructor is not the one who creates the object.**==


new keyword  is one who creates the object and  This constructor tells us which class this object belongs to.

---
==**constructor chaining**== is when one constructor calls another constructor in the same class (or in its base class) so you can avoid repeating initialization code.

It’s mainly done using the keywords **`this`** and **`base`**.

---

1. **Same-Class Constructor Chaining — using `this`**

You can call another constructor from the same class:

```cs
class Person
{
    public string Name;
    public int Age;

    // Constructor 1
    public Person(string name) 
    {
        Name = name;
        Age = 0; // default
    }

    // Constructor 2 - calls Constructor 1
    public Person(string name, int age) : this(name) 
    {
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        var p1 = new Person("Ammar");         // calls first constructor
        var p2 = new Person("Ammar", 21);     // calls second, which chains to first
    }
}
```

==**🔹 `this(name)` means: “before running my body, run the constructor that accepts a `string`”.**==

---

2. **Base-Class Constructor Chaining — using `base`**

If your class inherits from another, you can call the parent’s constructor first:

```cs
class Animal
{
    public string Species;

    public Animal(string species)
    {
        Species = species;
    }
}

class Dog : Animal
{
    public string Breed;

    public Dog(string species, string breed) : base(species) // Call Animal constructor
    {
        Breed = breed;
    }
}

class Program
{
    static void Main()
    {
        var dog = new Dog("Canine", "German Shepherd");
    }
}
```

🔹 `base(species)` ensures that the parent constructor runs before the child constructor code.

---

3. Rules & Notes

- The `this` or `base` call must be the **first statement** in the constructor.
- If you don’t call `base(...)` explicitly, the **parameterless** base constructor (if it exists) is called automatically.
- You can chain multiple constructors in a hierarchy to reduce code duplication.
- Avoid **circular calls** — they’ll cause a compile error.

---

If you want, I can also draw you a **visual diagram** of how the constructor chain flows in memory for both `this` and `base`.  
That way you’ll see exactly in which order they execute.

---------------------------------------------
==The **usefulness** of constructor chaining in C# comes down to **avoiding repetition** and **keeping initialization consistent**.==

---
1. **Avoid Repeating Code**

Without chaining, you’d have to write the same initialization logic in multiple constructors.

❌ **Without chaining**:
```cs
public Person(string name)
{
    Name = name;
    Age = 0; // repeated
}

public Person(string name, int age)
{
    Name = name; // repeated
    Age = age;
}
```

✅ **With chaining**:

```cs
public Person(string name)
{
    Name = name;
    Age = 0;
}

public Person(string name, int age) : this(name)
{
    Age = age;
}
```
No duplication — if you later change how `Name` is set, you change it in **one place**.

---
2. **Guarantee Consistent Initialization**

When you chain, you ensure that **all constructors go through the same setup path**.

This prevents bugs where one constructor forgets to initialize something that others do.

---
3. **Simplify Maintenance**

If you add new initialization logic later, you only have to update **one constructor**, not many.

---
4.  **Handle Inheritance Properly**

With `base(...)`, you can make sure the **base class gets set up first** before you add child class properties.

Example:  
If `Dog` inherits from `Animal`, `base(...)` ensures `Animal`'s fields are ready before `Dog` uses them.


-------------------------- 
### Visualize diagram

 **Same-Class Chaining with `this`**

```cs
public Person(string name)
{
    Name = name;
    Age = 0;
}

public Person(string name, int age) : this(name)
{
    Age = age;
}
```

**Flow Diagram:**

```pgsql
new Person("Ammar", 21)
           │
           ▼
┌───────────────────────────┐
│ Person(string name, int age)  
│   : this(name)             │
└───────────────────────────┘
           │
           ▼
┌───────────────────────────┐
│ Person(string name)        │
│   Name = name              │
│   Age = 0                  │
└───────────────────────────┘
           │
           ▼
Back to Person(string name, int age)
    Age = 21  (overrides Age = 0)

```


---

**2️⃣ Base-Class Chaining with `base`**

```cs
class Animal
{
    public Animal(string species) { ... }
}

class Dog : Animal
{
    public Dog(string species, string breed) : base(species) { ... }
}
```

**Flow Diagram:**

```pgsql
new Dog("Canine", "German Shepherd")
           │
           ▼
┌───────────────────────────┐
│ Dog(string species, string breed)
│   : base(species)          │
└───────────────────────────┘
           │
           ▼
┌───────────────────────────┐
│ Animal(string species)     │
│   Species = species        │
└───────────────────────────┘
           │
           ▼
Back to Dog constructor
    Breed = breed

```

----------------------------------------------
#  ---------------------------------
## Day 3 Relations
#####  1. **Association (Uses-a Relationship)**
- **Meaning**: A class uses another type, but does not own it.

the relationship here is short Life Time  and weak . 

