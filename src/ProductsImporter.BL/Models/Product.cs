using System.Collections.Generic;

namespace ProductsImporter.BL.Models
{
	public class Product
	{
		public string Name { get; set; }
		public List<string> Categories { get; set; }
		public string Twitter { get; set; }
	}
}
