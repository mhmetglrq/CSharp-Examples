using LinqSamples.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSamples
{
    class Model
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db=new NorthwindContext())
            {
                var customers = db.Customers
                    .Where(c => c.Orders.Any())
                    .Select(c => new
                {
                    c.ContactName,
                    OrderCount=  c.Orders.Count
                    })
                    .OrderBy(i=>i.OrderCount)
                    .ToList();
                foreach (var item in customers)
                {
                    Console.WriteLine(item.ContactName+"    "+ item.OrderCount);
                }
            }

            Console.Read();
        }

        private static void Ders10()
        {
            using (var db = new NorthwindContext())
            {
                ////var products = db.Products.Where(p => p.CategoryId == 1).ToList();
                ////var products = db.Products.Include(p=>p.Category).Where(p => p.Category.CategoryName == "Beverages").ToList();
                //var products = db.Products
                //    .Where(p => p.Category.CategoryName == "Beverages")
                //    .Select(p=> new { name=p.ProductName,id=p.CategoryId,category=p.Category.CategoryName})
                //    .ToList();
                //foreach (var item in products)
                //{
                //    Console.WriteLine(item.name+"    "+item.id + "   "+item.category);
                //}
                //var categories = db.Categories.Where(p => p.Products.Count() == 0).ToList();
                //var categories = db.Categories.Where(c => !c.Products.Any()).ToList();
                //var products = db.Products
                //    .Select(s => 
                //    new 
                //    {
                //        companyName=s.Supplier.CompanyName,
                //        contactName=s.Supplier.ContactName,
                //        s.ProductName
                //    })
                //    .ToList();
                //var products = (from p in db.Products
                //                where p.UnitPrice>10

                //               select p).ToList();
                var products = (from p in db.Products
                                join s in db.Suppliers on p.SupplierId equals s.SupplierId
                                select new
                                {
                                    p.ProductName,
                                    contactName = s.ContactName,
                                    companyName = s.CompanyName
                                }).ToList();
                foreach (var item in products)
                {
                    Console.WriteLine(item.ProductName + "    " + item.companyName + "    " + item.contactName);
                }
            }
        }

        private static void Ders9(NorthwindContext db)
        {
            var p = new Product() { ProductId = 85 };
            var p1 = new Product() { ProductId = 84 };
            var products = new List<Product>() { p, p1 };


            //db.Entry(p).State = EntityState.Deleted;
            db.Products.RemoveRange(products);

            db.SaveChanges();
        }

        private static void Ders8(NorthwindContext db)
        {
            var p = db.Products.Find(88);
            if (p != null)
            {
                db.Products.Remove(p);
                db.SaveChanges();
            }
        }

        private static void Ders6(NorthwindContext db)
        {
            var product = db.Products.Find(1);

            if (product != null)
            {
                product.UnitPrice = 28;
                db.Update(product);
                db.SaveChanges();
            }
        }

        private static void Ders7(NorthwindContext db)
        {
            var p = new Product() { ProductId = 1 };

            db.Products.Attach(p);

            p.UnitsInStock = 50;

            db.SaveChanges();
        }

        private static void Ders5(NorthwindContext db)
        {
            var product = db.Products
                                .AsNoTracking()
                                .FirstOrDefault(p => p.ProductId == 1);
            if (product != null)
            {
                product.UnitsInStock += 10;
                db.SaveChanges();
                Console.WriteLine("Veri Güncellendi");
            }
        }

        private static void Ders4()
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.Where(i => i.CategoryName == "Beverages").FirstOrDefault();
                var p2 = new Product() { ProductName = "yeni ürün6" };
                var p1 = new Product() { ProductName = "yeni ürün5" };
                //var products = new List<Product>()
                //{
                //    p1,p2
                //};
                category.Products.Add(p1);
                category.Products.Add(p2);
                db.SaveChanges();
                Console.WriteLine("verilereklendi");
                Console.WriteLine(p1.ProductId);
                Console.WriteLine(p2.ProductId);
            }
        }

        private static void Ders3()
        {
            using (var db = new NorthwindContext())
            {
                //var result = db.Products.Count();
                //var result = db.Products.Count(i=> i.UnitPrice>10&& i.UnitPrice<30);
                //var result = db.Products.Min(i => i.UnitPrice );
                //var result = db.Products.Max(i => i.UnitPrice );
                //var result = db.Products.Where(p=>p.CategoryId==1).Max(i => i.UnitPrice );
                //var result = db.Products.Where(p=>!p.Discontinued).Sum(i => i.UnitPrice);
                //var result = db.Products.OrderBy(p=>p.UnitPrice).ToList();
                var result = db.Products.OrderBy(p => p.UnitPrice).ToList();

                foreach (var item in result)
                {
                    Console.WriteLine(item.ProductName + " " + item.UnitPrice);
                }
            }
        }

        private static void Ders2()
        {
            using (var db = new NorthwindContext())
            {
                //var products = db.Products.Select(p=> new ProductModel {Name=p.ProductName,Price=p.UnitPrice}).Where(p => p.Price > 18 &&p.Price<30).ToList();
                //var products = db.Products.Where(p => p.CategoryId == 1 &&p.CategoryId<5).ToList();
                //var products = db.Products.Where(p => p.CategoryId == 1 || p.CategoryId == 5).ToList();
                //var products = db.Products.Select(p=> new ProductModel {Name=p.ProductName,Price=p.UnitPrice}).Where(p => p.Price > 18 &&p.Price<30).ToList();
                //var products = db.Products.Where(i => i.ProductName == "Chai").FirstOrDefault();
                //var products = db.Products.Where(i => i.ProductId >=5 && i.ProductId<=10 ).ToList();


            }
        }

        private static void Ders1()
        {
            using (var db = new NorthwindContext())
            {
                //var products = db.Products.ToList();
                //var products = db.Products.Select(p=>p.ProductName);
                //var products = db.Products.Select(p=>new { p.ProductName,p.UnitPrice }).ToList();
                //var products = db.Products.Select(p =>
                //new ProductModel { Name=p.ProductName,
                //    Price=p.UnitPrice 
                //}).ToList();
                //var product = db.Products.Select(p => new Model { Name = p.ProductName  }).FirstOrDefault();
                //Console.WriteLine(product.Name + " " + product.Price);

                //foreach (var item in products)
                //{
                //    Console.WriteLine(item.Name+" "+ item.Price);
                //}
            }
        }
    }
}
