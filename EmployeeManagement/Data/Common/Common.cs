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
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=employees-management;AccountKey=GzAgzUgkI74nj7waNHxjaZAqcmJHqYnhnBJGTCAgXg7bKfyIZlpVDGwgDM5oIFxBRb0mv5AKmtoB8I853YIiXg==;TableEndpoint=https://employees-management.table.cosmos.azure.com:443/;";

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
                return cloudTable;
            } else
            {
                Console.WriteLine("Connectionstring IS NOT valid");
                return null;
            }
        }
    }
}
