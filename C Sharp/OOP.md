## ==Day 1:  Introduction==

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

## ==Day 2 : Details about object behind the scenes and Constructor==

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

**member object** initialize by default in heap after i create object 
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
**how the method know which object call it and how use the field for the object ?**
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
**so this keyword is a ref type point to current object **

---
**ex**
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


**so we use the constructor to control how people create an object from class.**

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


**we can't create a object without constructor  till :**
→ the constructor create by you .
→ the constructor create by compiler .

**The constructor is not the one who creates the object.**


new keyword  is one who creates the object and  This constructor tells us which class this object belongs to.

---
### **constructor chaining** : this and base

**constructor chaining** is when one constructor calls another constructor in the same class (or in its base class) so you can avoid repeating initialization code.

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

**🔹 `this(name)` means: “before running my body, run the constructor that accepts a `string`”.**

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
The **usefulness** of constructor chaining in C# comes down to **avoiding repetition** and **keeping initialization consistent**.

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
## ==Day 3 : Relations==

we use relationships to help us understand business logic (business requirements and we transform it to technical requirements)  quickly and this Terminology always uses in work. 

Type of Relations
1. Association
2. Aggregation
3. Composition
4. Inheritance
5. Dependency
6. Interface
we will cover first 4 relation in this day.

--------------------------------------------
###  1. **Association (Uses-a Relationship) :**
- **Meaning**: A class uses another type, but does not own it.
- Example :
```cs
class Doctor
{
    public void Treat(Patient patient) { }
}
class Patient { }
```
**Use case**: Passing objects around without ownership.

the relationship here is short-term  and weak. 

هنا بتدور علي اقرب و اسهل حاجه تقضي الغرض ال انت محتاجه و بعد لما تقضي غرضك ممعتش بتستخدمه .
class x use class y ->  mean we need object from class y in class x . 

**the relationship between difference classes depend on the object creation .**

ex :
instructor class have a function called `WriteOnBoard()` 
now we need Marker Class to write on board 

```cs
public class Instructor
{
	// to use board you need a Marker  so we will create a Marker class
	public void WriteOnBoard(Marker marker)
	{
		 // i use marker here 
		  
	}
	public void attend()
	{

	}
}
public class Marker
{

}
// in main
// we need to create an object from Instructor
// and insturctor need marker class
// so first we will creata marker class
Marker m = new Marker();
Instructor ins = new Instructor();
ins.WirteOnBoard(m);

```
before use `WriteOnBoard()` there's no relationship between marker and instructor classes.

so the relationship start from use `WriteOnBoard()` and the relationship end with `WriteOnBoard()` Done .
فا كدا نقدر نقول ان العلاقه بين ال 2 classes بدأت و انتهت في فانكشن `WriteOnBoard()` .
الاتنين marker and instructor classes وجودهم مش معتمدين علي بعض الا عند استخدام `WriteOnBoard()` لذالك لو اي واحد اتمسح فيهم مش هيأثر علي وجود التاني
so the relation here is Association

##### **Association** :
→ A short -term relationship.
→ It will be created for two objects who don't know anything about each other in the first.
→ Life cycle for each object doesn't depend on the exist for anyone of them .
→ This relationship begins and ends with the end of the function .
→ The relationship here at the level of Method

ممكن مع عدم وجود شرط من الشروط ال هنا تفضل العلاقه هي هي 
ex 
instead of pass marker as parameter , create it in the body
```cs
public void WriteOnBoard()
{
	Marker marker = new Marker();
	 // i use marker here 
	  
}
```
also here the relationship begins and ends with the end of the function.

----------------------------------------

### 2- **Aggregation ( Contains ) (Has-a but Loosely Connected) :**
- **Meaning**: A class has a reference to another object, but they can exist separately.
ex
```cs
class Team
{
    public List<Player> Players { get; set; }
}
class Player { } // Player can exist without Team

```
**Difference from Composition**: In aggregation, the parts can live independently.

**Class team contain object from class player (as a field i guess).**  **(علاقة احتواء)**

مثال الاوضه ال احنا قاعدين فيها هي كائن و الكائن دا بيحتوي علي سرير مكتب دولاب و طرابيزه .
بس برضو الاوضه ممكن تكون موجوده من غير اي حاجه و طرابيزه ممكن تكون موجوده من غير الاوضه .

→ **aggregation relationship is powerful than association relationship .** 
→ **Life cycle for each object doesn't depend on the exist for anyone of them** .
→ **The relationship here at the level of class** .

ex :
Room class have 2 method `InstructorEntered()` and `InstructorTurnLightOn()`
so the class room need to store which instructor entered the room so we create an object from instructor in room class .

```cs
 public class Room
 {
     //public List<Instructor> Instructors = new Instructor ; 
     public Instructor instructor;
     public Room()
     {
         instructor = null;
     }
     // we need store instructor info to use it in another case 
     // so we create object from Instructor to store the instructor info
     public void InstructorEntered(Instructor ins)
     {
         this.instructor = ins;
     }
	 public void InstructorLeft(Instructor ins)
     {
         this.instructor = null;
     }

     public void InstructorTurnLightOn() 
     { 
         // i will give to instructor (الذي داخل الغرف ) order to turn on the ligth
     }
 }
```
maybe the instructor object in main died and in object still live so you should check when before use it .

instructor life not responsibility of room .



so this relationship starts  with instructor entered the room and ends with the instructor left the room. 

→ It will be created for two objects  don't depend in other .

**=the relationship may be between object and multi objects**

so maybe the room have student also
```cs
public class Room
{
	//public List<Instructor> Instructors = new Instructor ; 
	public Instructor instructor;
	public Student[] stds ;
	int index = 0;
	public Room()
	{
		instructor = null;
		stds = new Student[10];
	}
	// we need store instructor info to use it in another case 
	// so we create object from Instructor to store the instructor info
	public void InstructorEntered(Instructor ins)
	{
		this.instructor = ins;
	}
	public void StudentEntered(Student std)
	{
		this.stds[index++] = std;
	}
	public void InstructorLeft(Instructor ins)
	{
		this.instructor = null;
	}

	public void InstructorTurnLightOn() 
	{ 
		// i will give to instructor (الذي داخل الغرف ) order to turn on the ligth
	}
}
```

`std = new Student[10]` in memory 
now we create an array object (references to array of student) , 10 element each element will store a reference for the student object . 

→ listen start from [ 58:00 ]  video 7 in playlist .

---------------------------

### 3- **Composition (Consist) (Has-a Relationship)**

- **Meaning**: A class **has** another class as part of it. 
- Example
```cs
class Engine { }
class Car
{
    Engine engine = new Engine(); // Car HAS an Engine
}
```
**Use case**: Build complex objects from simpler ones.

**Composition → consists of class A consists of class B .**
here in example  → **consists of class Car consists of class Engine .**

زي الكتاب يتكون من مجموعة صفح .

**Composite :**
**→ the relationship more power and the relationship is long-term .**
→ the certation  for  objects  depend on other object .
	like no body without head , no room without walls.
→ the relation live with the class life.

here the reference and the creation happened in same class.

**object member must be private to make sure i am only one create the object .**

ex :
human body consist of head 

```cs
public class head 
{

}

public class HumanBody
{
	Head head;

	public HumanBody()
	{
		// creation of head happened in HumanBody
		head = new Head();
	}
	public void Think()
	{

	}
}
```


ex 
Room consist of walls

```cs
class Wall{

}
class Room{
	Wall walls;
	public Room(){
		walls = new Wall[4];
	}
	public void build(){
		for(int i = 0 ; i < walls.Length ; i++){
			walls[i] = new Wall();
		}
	}
}

```



| compare      | aggregation Relationship                                                                   | Composition Relationship                                                                                                                    |
| ------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------- |
| life time    | until delete the reference                                                                 | until class died                                                                                                                            |
| relationship | whole class                                                                                | whole class                                                                                                                                 |
|  creation    | the class doesn't depend on other class<br>and the creation happened outside the class<br> | the class depends on other class<br>because <br>first class  consists of other class<br>the creation happened anywhere inside the class<br> |

-------------------------------------
### 4-  **Inheritance (Is-a Relationship)**
- **Meaning**: One class **is a kind of** another class.
- **Keyword**: `:` (colon)

- **Example**:    
```cs
class Animal { }
class Dog : Animal { } // Dog Is an Animal
```
**Use case**: Code reuse & polymorphism.

هوا عباره عن كونست يستحدم للتوريث class من another class مجموعه من الصفات و الوظائف و يضيف عليها شوية صفات عشان تميزه مثال الكلب يكون حيوان ولكن عنه بعض الصفات ال تميزه صوته طوله ديله ودانه وهكذا

ex:
human is a creature

```cs
public class Creature
{
	public string Name;
	protected double Weight;
	private int age;
	
	public Creature(string name , int age ,double weight)
	{
		this.Name = name;
		this.age = age;
		this.Weight = weight;
	}
	public void Move()
	{
		Console.WriteLine("Creature is moving ...");
	}
	public void Eat()
	{
		Console.WriteLine("Creature is eating ...");
	}
}

public class Human : Creature
{
	public int Id;

	public Human(int id , string name , int age) :base(name, age)
	{
		this.Id = id;
	}
	public void Think()
	{

	}
	public void Eat3Time(){
		this.Weight += 5.5d ;
	}
}
```

**human class inherit all thing in Creature class and can use  public and protected members.**

the Inheritance class ( as Human here ) can use 
→ public member
→ protected member


Good Question
#### How  Human Class can access any field in Creature Class ?
→ After create Human object compiler by default create an object from Create Class in Human Class , so the child class automatically added object from parent class.
```cs
// i wrote 
public class Human : Creature
{
	public int Id;

	public Human(int id , string name , int age) :base(name, age)
	{
		this.Id = id;
	}
	public void Think()
	{

	}
	public void Eat3Time(){
		this.Weight += 5.5d ;
	}
}
// compiler do and added hidden member called base point to parent class
// like this in the same class 
public class Human 
{
	Creature creature = new Creature();
	
	public void Eat3Time(){
		Weight += 5.5d;
		-- or
		this.Weight += 5.5d ;

		// compiler will convert it to this
		// to point to parent class 
		base.Weight += 5.5d ;
	}
}
```

WHAT IF ? 
the parent class have multi constructor compiler will create an object from parent which constructor will call ?
ex :
```cs
public class Creature
{
	public string Name;
	protected double Weight;
	private int age;

	public Creature(){
	
	}
	public Creature(string name, int age, double weight)
	{
		this.Name = name;
		this.age = age;
		this.Weight = weight;
	}

	}
}

public class Human : Creature
{
	public int Id;
	public Human()
	{
	
	}
	public Human(int id , string name , int age, double weight)
	{
		this.Id = id;
	}
	public void Eat3Time()
	{
		this.Weight += 5.5d;
	}

	public void Think()
	{

	}
}
```
if you not tell the compiler explicitly which constructor you will use the compiler choose the parameter less constructor .

so in this case will call the empty constructor
```cs
// in main
Human h = new Human();
```

how you can tell the compiler explicitly which constructor you will use via **Constructor Chaining `base`**
```cs
public class Human : Creature
{
	public int Id;
	// call empty constructor 
	// i can call it without base 
	public Human() : base()
	{
	
	}
	// call second constructor
	public Human(int id , string name , int age, double weight) :base(name, age , weight)
	{
		this.Id = id;
	}
	public void Eat3Time()
	{
		this.Weight += 5.5d;
	}

	public void Think()
	{

	}
}
```

so in main if you use the second constructor in Human  
```cs
// in main
Human h = new Human();
```

----
**multi Level inheritance** : a class inherit from class and this class inherit from another class.
ex : 
Employee class inherit from Human class and human class inherit from Creature class
```cs
public Creature{

}

public Human : Creature{

}

public Employee : Human{

}
```

---------------------

### why association is exist ?
	to expresses the Uses-a Relationship

### why aggregation is exist ?
	to expresses the  Contains relationship

### why composite is exist ?
	to expresses the consist of relationship

### why inheritance is exist ?
	to expresses the is a relationship



# ---------------------------------
## Day 4 : 