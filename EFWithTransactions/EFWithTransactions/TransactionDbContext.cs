using System.Data.Entity;

namespace EFWithTransactions
{
    public class TransactionDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    public class Employee
    {
    }

    public class Department
    {
    }
}