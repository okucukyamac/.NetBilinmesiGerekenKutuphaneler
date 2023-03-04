using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.SRP.Good
{



    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class ProductRepository
    {
        private static List<Product> productList = new();

        public ProductRepository()
        {
            productList = new()
            {
                new(){Id=1,Name="Kalem 1"},
                new(){Id=2,Name="Kalem 2"},
                new(){Id=3,Name="Kalem 3"},
                new(){Id=4,Name="Kalem 4"},
                new(){Id=5,Name="Kalem 5"},
            };
        }
        public void SaveOrUpdate(Product product)
        {
            var hasProduct = productList.Contains(product);

            if (!hasProduct)
            {
                productList.Add(product);
            }
            else
            {
                var index = productList.IndexOf(product);

                productList[index] = product;
            }
        }

        public void Delete(int id)
        {
            var hasProduct = productList.Find(x => x.Id == id);

            if (hasProduct == null)
                throw new Exception("Ürün bulunamadı");

            productList.Remove(hasProduct);
        }
    }

    public class ProductPresenter
    {
        public void WriteToConsole(List<Product> productList)
        {
            productList.ForEach(a =>
            {
                Console.WriteLine($"{a.Id} - {a.Name}");
            });
        }

    }
}
