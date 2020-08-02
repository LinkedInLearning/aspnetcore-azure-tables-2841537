using EmployeeManagement.Data.Common;
using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.CreateTableAsync("Employee").GetAwaiter().GetResult();

            Console.ReadKey();
        }
    }
}
