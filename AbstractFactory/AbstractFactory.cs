using System.Net.Mime;
using System;

using System.Collections.Generic;

namespace FactorySolution
{

    public abstract class Product
    {
        protected string description = "";

        public abstract void MakeComputer(int cpu, int ram, int storage, int display);

        public string GetInfo()
        {
            return description;
        }
    }

    public class PC : Product
    {
        public override void MakeComputer(int cpu, int ram, int storage, int display)
        {
            description = $"DELL PC: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
        }
    }

    public class Laptop : Product
    {
        public override void MakeComputer(int cpu, int ram, int storage, int display)
        {
            description = $"DELL Laptop: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
        }
    }

    public class iMac : Product
    {
        public override void MakeComputer(int cpu, int ram, int storage, int display)
        {
            description = $"APPLE iMac: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
        }
    }

    public class MacBook : Product
    {
        public override void MakeComputer(int cpu, int ram, int storage, int display)
        {
            description = $"APPLE MacBook: CPU {cpu}, RAM {ram}, STORAGE {storage}, DISPLAY {display}";
        }
    }

    public abstract class OrderSystem
    {
        private List<Product> products = new();

        protected abstract Product? Create(string type, int cpu, int ram, int storage, int display);

        public Product? PlaceOrder(string type, int cpu, int ram, int storage, int display)
        {
            var product = Create(type, cpu, ram, storage, display);
            products.Add(product);
            return product;
        }

        public void ListOrders()
        {
            products.ForEach(product => Console.WriteLine(product.GetInfo()));
        }
    }

    public class Order : OrderSystem
    {
        protected Dictionary<string, Func<Product>> creator;
        public Order()
        {
            creator = new();
        }

        protected override Product? Create(string type, int cpu, int ram, int storage, int display)
        {
            var product = creator[type.ToLower()]();
            product.MakeComputer(cpu, ram, storage, display);
            return product;
        }
    }

    public class DellVendor : Order
    {
        public DellVendor()
        {
            creator.Add("pc", () => new PC());
            creator.Add("laptop", () => new Laptop());
        }
    }

    public class AppleVendor : Order
    {
        public AppleVendor()
        {
            creator.Add("imac", () => new iMac());
            creator.Add("macbook", () => new MacBook());
        }
    }

    public class Vendors
    {
        protected Dictionary<string, Func<Order>> orders;

        public Vendors() 
        {
            orders = new();
            orders.Add("Dell", () => new DellVendor());
            orders.Add("Apple", () => new AppleVendor());
        }

        public Order GetVendor(string vendorType)
        { 
            return orders[vendorType]();
        }
    }

    class AbstractFactory
    {
        public static void Main()
        {
            var vendor = new Vendors();
            var order = vendor.GetVendor("Apple");

            order.PlaceOrder("iMac", 4, 16, 512, 16);
            order.ListOrders();

            order = vendor.GetVendor("Dell");
            order.PlaceOrder("Laptop", 8, 32, 1024, 32);
            order.ListOrders();
        }
    }
}
