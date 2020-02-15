using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProductsImporter.BL.Factory;
using ProductsImporter.BL.Implementation;
using ProductsImporter.BL.Interfaces;

namespace TestProject.Bl.Test
{
	public class ProductsImporterFactoryTest
	{
		private ProductsImporterFactory _productsImporterFactory;
		private Mock<IStreamReader> _mockStreamReader;

		[SetUp]
		public void Setup()
		{
			_mockStreamReader = new Mock<IStreamReader>();
			_productsImporterFactory = new ProductsImporterFactory(_mockStreamReader.Object);
		}

		[Test(Description = "When products importer is capterra and fileExtension is .yaml then it")]
		public void Should_Return_Object_Of_Capterra_Products_Importer()
		{
			const string productsImporter = "capterra";
			const string fileExtension = ".yaml";

			var result = _productsImporterFactory.ResolveImporter(productsImporter, fileExtension);

			result.Should().NotBeNull();
			result.Should().BeOfType<CapterraProductsImporter>();
		}

		[Test(Description = "When products importer is softwareAdvice and fileExtension is .json then it")]
		public void Should_Return_Object_Of_SoftwareAdvice_Products_Importer()
		{
			const string productsImporter = "softwareAdvice";
			const string fileExtension = ".json";

			var result = _productsImporterFactory.ResolveImporter(productsImporter, fileExtension);

			result.Should().NotBeNull();
			result.Should().BeOfType<SoftwareAdviceProductsImporter>();
		}


		[Test(Description = "When products importer is neither capterra nor softwareAdvice then it")]
		public void Should_Return_Null()
		{
			const string productsImporter = "foo";
			const string fileExtension = ".bar";

			var result = _productsImporterFactory.ResolveImporter(productsImporter, fileExtension);

			result.Should().BeNull();
		}
	}
}
