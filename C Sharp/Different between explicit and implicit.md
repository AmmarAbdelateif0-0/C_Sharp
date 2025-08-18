
# 1. Implicit Implementation

###  What?

- You implement the interface methods/properties as **normal `public` members** in your class.
- They are accessible from both the **class reference** and the **interface reference**.

###  Why?

- Simple, clear, and most common approach.
- You want the interface methods to be part of your class’s public API.
- No method name conflicts exist between interfaces.

###  How?

```cs
public interface IWorker
{
    void Work();
}

public class Programmer : IWorker
{
    // Implicit Implementation
    public void Work()
    {
        Console.WriteLine("Programmer is coding...");
    }
}

class Program
{
    static void Main()
    {
        Programmer p = new Programmer();
        p.Work();             // ✅ Class reference
        IWorker w = p;
        w.Work();             // ✅ Interface reference
    }
}
```

---

# 🔹 2. Explicit Implementation

###  What?

- You implement the interface methods using the **interface name as a prefix** (`void IWorker.Work()`).
- These methods are **not accessible** directly from the class reference, only via the interface reference.

###  Why?

- To **avoid name conflicts** when two interfaces define methods with the same name.
- To **hide methods** from the class’s public API, so they are only usable through the interface.
- To give different behaviors for the same method name depending on the interface.

### ✅ How?

```cs
public interface ICamera
{
    void Start();
}

public interface IPhone
{
    void Start();
}

public class Smartphone : ICamera, IPhone
{
    // Explicit Implementation
    void ICamera.Start()
    {
        Console.WriteLine("Camera started...");
    }

    void IPhone.Start()
    {
        Console.WriteLine("Call started...");
    }
}

class Program
{
    static void Main()
    {
        Smartphone s = new Smartphone();

        // s.Start(); ❌ Not accessible directly

        ICamera cam = s;
        cam.Start();   // ✅ "Camera started..."

        IPhone ph = s;
        ph.Start();    // ✅ "Call started..."
    }
}

```

---

# 🔹 Clear Comparison Table

| Feature          | Implicit Implementation                                       | Explicit Implementation                                                 |
| ---------------- | ------------------------------------------------------------- | ----------------------------------------------------------------------- |
| **What**         | Normal `public` methods/properties implementing the interface | Interface methods implemented with **interface name prefix**            |
| **Why**          | Simple, common, part of public API                            | Avoid conflicts, hide methods, or give separate meanings                |
| **How**          | `public void Work()`                                          | `void IWorker.Work()`                                                   |
| **Access**       | Both class reference and interface reference                  | Only interface reference                                                |
| **Real Example** | `Programmer.Work()` → anyone can call it                      | `Smartphone as ICamera` vs `Smartphone as IPhone` → different behaviors |


# why explicit interface exist ?
## 1. **When two interfaces have members with the same name**

Imagine you are forced to implement two interfaces, both with a `Print()` method but different meanings.

Example:

```cs
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Print();
}

public class Machine : IPrinter, IScanner
{
    // Implicit would cause conflict (two Print methods)
    // Solution: Explicit implementation
    void IPrinter.Print()
    {
        Console.WriteLine("Printing document...");
    }

    void IScanner.Print()
    {
        Console.WriteLine("Scanning document...");
    }
}

class Program
{
    static void Main()
    {
        Machine m = new Machine();

        // m.Print(); ❌ Error: ambiguous, no direct access

        IPrinter printer = m;
        printer.Print();   // ✅ "Printing document..."

        IScanner scanner = m;
        scanner.Print();   // ✅ "Scanning document..."
    }
}

```

 **Why explicit here?**

- It lets you implement **both versions** of `Print()` without conflict.
    
- The class decides which behavior to expose depending on how you use it.
    

---

## 2. **When you want to hide implementation from public API**

Sometimes you don’t want every method from an interface to “pollute” your class’s public members.

 Example: Database connection

```cs
public interface IDatabase
{
    void Connect();
}

public class SecureDatabase : IDatabase
{
    // Explicit implementation (hidden)
    void IDatabase.Connect()
    {
        Console.WriteLine("Database connected securely...");
    }

    public void DoWork()
    {
        Console.WriteLine("Doing some work...");
    }
}

class Program
{
    static void Main()
    {
        SecureDatabase db = new SecureDatabase();
        db.DoWork();        // ✅ Works normally
        // db.Connect();    ❌ Not accessible directly

        IDatabase connection = db;
        connection.Connect(); // ✅ Accessible only via interface
    }
}

```

 **Why explicit here?**

- Maybe you don’t want every developer using `SecureDatabase` to call `Connect()` directly — instead they must use it through `IDatabase`.
- This is useful in **frameworks, security-sensitive APIs, or when restricting usage**.

---

## 🔹 Summary

You need **explicit implementation** when:

1. **Two interfaces have conflicting member names** (avoids ambiguity).
2. **You want to hide certain members** from the class’s public API and only expose them via interface reference.