using System;
using ProductsImporter.BL.Interfaces;
using ProductsImporter.BL.Models;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.RepresentationModel;

namespace ProductsImporter.BL.Implementation
{
	public class CapterraProductsImporter : IProductsImporter
	{
		private readonly IStreamReader _streamReader;
		public CapterraProductsImporter(IStreamReader streamReader)
		{
			_streamReader = streamReader;
		}

		public List<Product> Import(string filePath)
		{
			var products = new List<Product>();

			using var streamReader = _streamReader.GetReader(filePath);
			var yamlStream = new YamlStream();
			yamlStream.Load(streamReader);

			if (yamlStream.Documents.Count <= 0)
				return products;

			var rootNode = (YamlSequenceNode)yamlStream.Documents[0].RootNode;

			var parsedProducts = rootNode.Children.Select(BuildProduct);
			products.AddRange(parsedProducts);

			return products;
		}

		private Product BuildProduct(YamlNode node)
		{
			var product = new Product();

			foreach (var (nodeKey, nodeValue) in ((YamlMappingNode)node).Children)
			{
				var key = Convert.ToString(nodeKey);
				var value = Convert.ToString(nodeValue);

				switch (key)
				{
					case "tags":
						product.Categories = value.Split(',').ToList();
						break;
					case "name":
						product.Name = '"' + value + '"';
						break;
					case "twitter":
						product.Twitter = "@" + value;
						break;
				}
			}

			return product;
		}
	}
}
