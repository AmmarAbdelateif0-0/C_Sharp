using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_Commerce_Cart
{
    public class Product
    {
        static int counter = 1; //auto increament
        public int Id { get; }
        public string ProductName { set; get; }
        public string Desc { set; get; }
        public decimal Price { private set; get; }
        public int Quantity { private set; get; }

        public Product(string productName, string desc, decimal price, int quantity)
        {
            this.Id = counter++;
            this.ProductName = productName;
            this.Desc = desc;
            this.Price = price;
            this.Quantity = quantity;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice > 0)
                this.Price = newPrice;
        }

        public bool ReduceStock(int amount)
        {
            if(amount <= this.Quantity)
            {
                this.Quantity -= amount;
                return true;
            }
            return false;

        }
        public void IncreaseStock(int amount)
        {
            if (amount > 0)
                this.Quantity += amount;
        }

        public bool IsInStock() => this.Quantity > 0;

        public override string ToString()
        {
            return $"[{Id}] {ProductName} - {Price:C} ({Quantity} in stock)";
        }

    }
}
