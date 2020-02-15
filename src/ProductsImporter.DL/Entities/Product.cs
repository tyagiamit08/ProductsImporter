using System.Collections.Generic;

namespace ProductsImporter.DL.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Twitter { get; set; }
		public ICollection<Category> Categories { get; set; }
	}
}
