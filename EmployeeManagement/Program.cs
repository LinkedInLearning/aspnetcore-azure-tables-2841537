using EmployeeManagement.Data.Common;
using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.CreateTableAsync("test").GetAwaiter().GetResult();

            Console.ReadKey();
        }
    }
}
