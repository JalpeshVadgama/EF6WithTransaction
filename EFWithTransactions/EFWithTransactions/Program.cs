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
                            CategoryName = "Clothes"
                        };
                        productDbContext.Categories.Add(category);
                        productDbContext.SaveChanges();

                        // Throw some error to check transaction
                        // Comment this to make transactions sucessfull
                        // throw new Exception("Custom Exception");

                        //saving product
                        Product product = new Product
                        {
                            ProductName = "Blue Denim Shirt",
                            CategoryId = category.CategoryId
                        };
                        productDbContext.Products.Add(product);
                        productDbContext.SaveChanges();
                        Console.Write("Cateogry and Product both saved");
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction Roll backed due to some exception");
                    }
                }

            }
            Console.ReadKey();
        }
    }
}
