
# Tight Coupling

###  What is it?
- **Tight coupling** happens when one class is **highly dependent** on another class.
- If you change one class, the other will likely break.
###  Problems:
- Hard to maintain.
- Hard to reuse code in other projects.
- Difficult to test (especially unit testing).

###  Example (Tightly Coupled)
```cs
public class EmailService
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class Notification
{
    private EmailService _emailService = new EmailService(); // tightly coupled

    public void Notify(string message)
    {
        _emailService.SendEmail(message);
    }
}

class Program
{
    static void Main()
    {
        Notification notify = new Notification();
        notify.Notify("Hello Ammar!");
    }
}
```

 Problem: If later you want to send SMS instead of Email, you must change `Notification` class. That’s **tight coupling**.

---

#  Loose Coupling

### What is it?

- **Loose coupling** means classes **communicate through abstraction** (like interfaces).
- Classes depend less on each other → more flexible and maintainable.
###  Benefits:

- Easier to maintain.
- Easier to test (you can mock dependencies).
- Reusable and extendable.

###  Example (Loosely Coupled)

```cs
public interface IMessageService
{
    void SendMessage(string message);
}

public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class SMSService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}

public class Notification
{
    private readonly IMessageService _messageService;

    // Dependency Injection
    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify(string message)
    {
        _messageService.SendMessage(message);
    }
}

class Program
{
    static void Main()
    {
        IMessageService email = new EmailService(); // upcasting
        IMessageService sms = new SMSService();     // upcasting

        Notification notify1 = new Notification(email);
        notify1.Notify("Hello Ammar (via Email)");

        Notification notify2 = new Notification(sms);
        notify2.Notify("Hello Ammar (via SMS)");
    }
}
```

→ Now, `Notification` does not care _how_ the message is sent. You can plug in **Email, SMS, WhatsApp, Push Notification, etc.**  
That’s **loose coupling**  .

---
#  Summary

| Aspect          | Tight Coupling                | Loose Coupling                              |
| --------------- | ----------------------------- | ------------------------------------------- |
| **Dependency**  | Direct class-to-class         | Uses abstraction (interface/abstract class) |
| **Flexibility** | Rigid                         | Flexible, extendable                        |
| **Testing**     | Hard                          | Easy (mocking possible)                     |
| **Maintenance** | Costly                        | Easier                                      |
| **Example**     | `Notification → EmailService` | `Notification → IMessageService`            |
