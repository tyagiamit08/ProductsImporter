using System.IO;
using ProductsImporter.BL.Interfaces;

namespace ProductsImporter.BL.Implementation
{
	public class FileStreamReader : IStreamReader
	{
		public StreamReader GetReader(string filePath)
		{
			return new StreamReader(filePath);
		}
	}
}
