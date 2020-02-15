using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using ProductsImporter.BL.Factory;
using ProductsImporter.BL.Implementation;
using ProductsImporter.BL.Interfaces;
using ProductsImporter.BL.Models;

namespace ProductsImporter
{
	class Program
	{
		static void Main(string[] args)
		{
			if (!ArgumentsAreValid(args)) return;

			var productsFilePath = args[1];

			if (!FileExistsOnPath(productsFilePath)) return;

			var products = ImportProducts(args, productsFilePath);

			foreach (var product in products)
				Console.WriteLine($"importing: Name:{product.Name}; Categories: {string.Join(", ", product.Categories)}; Twitter: {product.Twitter}");
		}

		#region PrivateMethods

		private static bool ArgumentsAreValid(string[] args)
		{
			if (args != null && args.Length == 2) return true;

			Console.WriteLine("You have not entered the valid import command.");
			return false;

		}

		private static bool FileExistsOnPath(string productsFilePath)
		{
			if (File.Exists(productsFilePath))
				return true;

			Console.WriteLine($"The file does not exists on the path {productsFilePath}");
			return false;
		}

		private static IEnumerable<Product> ImportProducts(string[] args, string productsFilePath)
		{
			var productsProvider = args[0];
			var fileName = Path.GetFileName(productsFilePath);
			var fileExtension = Path.GetExtension(fileName);

			var serviceProvider = ConfigureServices();
			var streamReader = serviceProvider.GetService<IStreamReader>();

			var productsImporter = new ProductsImporterFactory(streamReader);
			var resolvedImporter = productsImporter.ResolveImporter(productsProvider, fileExtension);

			return resolvedImporter != null ? resolvedImporter.Import(productsFilePath) : new List<Product>();
		}

		private static ServiceProvider ConfigureServices()
		{
			var collection = new ServiceCollection();
			collection.AddScoped<IStreamReader, FileStreamReader>();
			return collection.BuildServiceProvider();
		}

		#endregion
	}
}
