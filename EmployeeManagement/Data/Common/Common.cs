using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Common
{
    public class Common
    {
        public static async Task<CloudTable> CreateTableAsync(string tableName)
        {
            string connectionString = ""; // Paste your Azure account's unique connection string.

            CloudStorageAccount cloudStorageAccount;

            if(CloudStorageAccount.TryParse(connectionString, out cloudStorageAccount))
            {
                Console.WriteLine("Connectionstring is valid");
                CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
                CloudTable cloudTable = cloudTableClient.GetTableReference(tableName);
                if(await cloudTable.CreateIfNotExistsAsync())
                {
                    Console.WriteLine($"Created table {tableName}");
                } else
                {
                    Console.WriteLine($"Table {tableName} already exists");
                }
            } else
            {
                Console.WriteLine("Connectionstring IS NOT valid");
            }

            return null;
        }
    }
}
