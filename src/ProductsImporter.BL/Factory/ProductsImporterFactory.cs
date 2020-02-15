using ProductsImporter.BL.Constants;
using ProductsImporter.BL.Implementation;
using ProductsImporter.BL.Interfaces;

namespace ProductsImporter.BL.Factory
{
	public class ProductsImporterFactory
	{
		private readonly IStreamReader _streamReader;
		public ProductsImporterFactory(IStreamReader streamReader)
		{
			_streamReader = streamReader;
		}

		public IProductsImporter ResolveImporter(string productsProvider, string fileExtension)
		{
			return productsProvider.ToLower() switch
			{
				ProductsProviders.SoftwareAdvice when fileExtension == FileExtensions.Json =>
				new SoftwareAdviceProductsImporter(_streamReader),
				ProductsProviders.Capterra when fileExtension == FileExtensions.Yaml => 
				new CapterraProductsImporter(_streamReader),
				_ => null
			};
		}
	}
}
