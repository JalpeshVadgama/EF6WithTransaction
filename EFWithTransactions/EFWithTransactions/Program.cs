using System;

namespace EFWithTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProductDbContext productDbContext = new ProductDbContext())
            {
                using (var transaction = productDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        //saving category
                        Category category = new Category
                        {
                            CategoryId = 1,
                            CategoryName = "Clothes"
                        };
                        productDbContext.Categories.Add(category);

                        // Throw some error to check transaction
                        throw new Exception("Custom Exception");

                        //saving product
                        Product product = new Product
                        {
                            ProductId = 1,
                            ProductName = "Blue Denim Shirt",
                            CategoryId = 1
                        };
                        productDbContext.Products.Add(product);
                        productDbContext.SaveChanges();
                        Console.Write("Cateogry and Product both saved");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction Rollbacked due to some exception");
                    }
                }

            }
            Console.ReadKey();
        }
    }
}
