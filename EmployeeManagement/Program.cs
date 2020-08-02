using EmployeeManagement.Data.Common;
using EmployeeManagement.Data.Operations;
using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Common.CreateTableAsync("Employee").GetAwaiter().GetResult();

            Operations dataOperations = new Operations();
            dataOperations.TriggerOperations().Wait();

            Console.ReadKey();
        }
    }
}
