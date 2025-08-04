using System;

namespace E_Commerce_Cart
{
    public class Program
    {
        static List<User> users = new();
        static List<Product> products = new();
        static User currentUser = null;

        public static void Main()
        {
            SeedData();
            MainMenu();
        }

        static void SeedData()
        {
            User user = new User("admin", "admin@admin.com", "admin");
            users.Add(user);

            products.Add(new Product("Mouse", "Wireless Mouse", 150.0m, 10));
            products.Add(new Product("Keyboard", "Mechanical Keyboard", 450.0m, 5));
            products.Add(new Product("Monitor", "27-inch 4K UHD Display", 3200.0m, 7));
            products.Add(new Product("Laptop", "High-performance laptop with 16GB RAM", 12000.0m, 4));
            products.Add(new Product("Headphones", "Noise-cancelling wireless headphones", 850.0m, 15));
            products.Add(new Product("Webcam", "HD webcam with microphone", 300.0m, 12));
            products.Add(new Product("USB Hub", "4-Port USB 3.0 Hub", 180.0m, 20));
            products.Add(new Product("Gaming Chair", "Ergonomic gaming chair with lumbar support", 2500.0m, 3));
            products.Add(new Product("External SSD", "1TB USB-C External Solid State Drive", 1400.0m, 6));
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to E-Commerce Console App");
                Console.WriteLine("1. Register \n2. Login \n3. Exit");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invaild Option.");
                        break;
                }

            }
        }

        static void Register()
        {
            Console.Write("Name :");
            var name = Console.ReadLine();
            Console.Write("Email (@admin.com or @user.com :");
            var email = Console.ReadLine();
            Console.Write("Password :");
            var password = Console.ReadLine();

            try
            {
                users.Add(new User(name, email, password));
                Console.WriteLine("Registered Successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }

        }

        static void Login()
        {
            Console.Write("Email : ");
            var email = Console.ReadLine();
            Console.Write("Password : ");
            var password = Console.ReadLine();

            var user = users.Find(u => u.Email == email);
            if(user != null && user.CheckPassword(password))
            {
                currentUser = user;
                if (currentUser.Role == 'a') AdminMenu();
                else UserMenu();
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Product\n2. View Products\n3. Logout");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ViewProduct();
                        break;
                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;

                }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. View Products\n2. Buy Product\n3. Logout");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewProduct();
                        break;
                    case "2":
                        BuyProduct();
                        break;
                    case "3":
                        return;
                   
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

            }
        }

        static void AddProduct()
        {
            Console.Write("Product Name: "); 
            string name = Console.ReadLine();

            Console.Write("Description: "); 
            string desc = Console.ReadLine();

            Console.Write("Price: ");
            decimal price; 
            decimal.TryParse(Console.ReadLine(),out price);

            Console.Write("Quantity: "); 
            int qty;
            int.TryParse(Console.ReadLine() , out qty);

            products.Add(new Product(name, desc, price, qty));
            Console.WriteLine("Product added successfully!");
        }
        static void ViewProduct()
        {
            Console.WriteLine("Available Products");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
        static void BuyProduct()
        {
            Console.WriteLine("Enter Product Id to buy");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = products.Find(p => p.Id == id);
                if (product != null && product.IsInStock())
                {
                    Console.WriteLine("How many item do you want ? ");
                    int.TryParse(Console.ReadLine(), out int num);
                    product.ReduceStock(num);
                    Console.WriteLine("Product not available.");
                }
                else
                {
                    Console.WriteLine("Product not available.");

                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            
        }
    }
}