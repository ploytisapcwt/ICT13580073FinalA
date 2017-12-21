using System;
using System.Collections.Generic;
using System.Linq;

using ICT13580073FinalA.Model;
using SQLite;

namespace ICT13580073FinalA.Helpers
{
	public class DbHelper
	{
		SQLiteConnection db;
		
        public DbHelper(String dbPath)

		{
			db = new SQLiteConnection(dbPath);
			db.CreateTable<Product>();
		}

		public int AddProduct(Product product)
		{
			db.Insert(product);
            return product.Id;
		}
		public List<Product> GetProducts()
		{
			return db.Table<Product>().ToList();

		}
		public int UpdateProduct(Product product)
		{
			return db.Update(product);
		}
		public int DeleteProduct(Product product)
		{
			return db.Delete(product);
		}
	}
}