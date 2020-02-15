using System.IO;

namespace ProductsImporter.BL.Interfaces
{
	public interface IStreamReader
	{
		StreamReader GetReader(string filePath);
	}
}
