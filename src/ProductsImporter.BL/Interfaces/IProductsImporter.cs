using ProductsImporter.BL.Models;
using System.Collections.Generic;

namespace ProductsImporter.BL.Interfaces
{
	public interface IProductsImporter
	{
		public List<Product> Import(string filePath);
	}
}
