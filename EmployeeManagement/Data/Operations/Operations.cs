using EmployeeManagement.Data.Entities;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Operations
{
    public class Operations
    {
        public async Task TriggerOperations()
        {
            string tableName = "Employee";

            CloudTable cloudTable = await Common.Common.CreateTableAsync(tableName);

            try
            {
                await BasicTableDataOperations(cloudTable);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task BasicTableDataOperations(CloudTable cloudTable)
        {
            //Create Entity
            EmployeeEntity newEmployeeEntity = new EmployeeEntity("Consulting")
            {
                FullName = "Ervis Trupja",
                Email = "ervis@trupja.com",
                RowKey = "ervis-trupja-rk"
            };

            TableOperation addOperation = TableOperation.InsertOrMerge(newEmployeeEntity);
            TableResult addResult = await cloudTable.ExecuteAsync(addOperation);
            EmployeeEntity addResponse = addResult.Result as EmployeeEntity;

            if (addResult.RequestCharge.HasValue)
            {
                Console.WriteLine($"addResponse ==> {addResponse.PartitionKey} - {addResponse.RowKey} - {addResponse.FullName}");
            }
        }
    }
}
