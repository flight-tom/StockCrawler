﻿namespace StockCrawler.Dao
{
    public abstract class StockDataService
    {
        /// <summary>
        /// Retrieve a new service instance. It's thread-safe.
        /// </summary>
        /// <returns>Database service instance</returns>
        public static IStockDataService GetServiceInstance()
        {
            return new StockDataServiceMSSQL();
        }
    }
}
