using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using AdventureWorks.Models;
using AdventureWorks.Context;

public class DataMigrationTool{

        private const string sqlCon = "Server=tcp:polysqlsrini9999.database.windows.net,1433;Initial Catalog=AdventureWorks;Persist Security Info=False;User ID=sriniadmin;Password=Password123#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private const string cosmosCon = "AccountEndpoint=https://polycosmossrini999.documents.azure.com:443/;AccountKey=ozE4QaXdhUKTCKaQ9taI7WrPXRTHo7fN4c90qxmuw1DZlHMbnTRhsKa7YrN7y4KDMGFIL3R8IaTOACDbqaaCwQ==;";
        public static async Task Main() {

            await Console.Out.WriteLineAsync($"***********Migrating Data from Azure SQL to Cosmos***************");
            AdventureWorksSqlContext sqlCtx = new AdventureWorksSqlContext(sqlCon);
            //join the data of models with product
            List<Model> items = await sqlCtx.Models.Include( m=>m.Products).ToListAsync<Model>();
            //print out the list of items - they are now in memory
            await Console.Out.WriteLineAsync($"# of records in SQL Database :\t{items.Count}");

            //#Connect to Cosmos
            using CosmosClient client = new CosmosClient(cosmosCon);
            //Create a database -- Retail
            Database db = await client.CreateDatabaseIfNotExistsAsync("Retail");
            //create a container - Online with a partitionkey (shard key)
            Container newContainer = await db.CreateContainerIfNotExistsAsync("Online",partitionKeyPath:$"/{nameof(Model.Category)}");

            //upsert the docments onby one from the items list (binary serialized );
            int count=0;
            foreach(var item in items){
                Thread.Sleep(100);
                ItemResponse<Model> document = await newContainer.UpsertItemAsync<Model>(item);
                count++;
                await Console.Out.WriteLineAsync($"Insterted document with id {document.ActivityId}");
            }
            await Console.Out.WriteLineAsync($"**Completed migrating {count} records to CosmosDB");
        }


}

