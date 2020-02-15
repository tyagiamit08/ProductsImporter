using Newtonsoft.Json;
using ProductsImporter.BL.Interfaces;
using ProductsImporter.BL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsImporter.BL.Implementation
{
	public class SoftwareAdviceProductsImporter : IProductsImporter
	{
		private readonly IStreamReader _streamReader;
		public SoftwareAdviceProductsImporter(IStreamReader streamReader)
		{
			_streamReader = streamReader;
		}
		public List<Product> Import(string filePath)
		{
			using var streamReader = _streamReader.GetReader(filePath);
			var productsJson = streamReader.ReadToEnd();

			var productsCollection = JsonConvert.DeserializeObject<SoftwareAdviceProducts>(productsJson);

			return productsCollection.Products.Select(product =>
				new Product
				{
					Name = '"' + product.Title + '"',
					Twitter = product.Twitter,
					Categories = product.Categories
				}
			).ToList();
		}
	}
}
