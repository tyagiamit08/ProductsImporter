using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using Moq;
using ProductsImporter.BL.Implementation;
using ProductsImporter.BL.Interfaces;

namespace ProductsImporter.BL.Tests.FunctionalTest
{
	[TestFixture]
	public class SoftwareAdviceProductsImporterTest
	{
		private SoftwareAdviceProductsImporter _softwareAdviceProductsImporter;
		private Mock<IStreamReader> _mockStreamReader;

		[SetUp]
		public void Setup()
		{
			_mockStreamReader = new Mock<IStreamReader>();
			_softwareAdviceProductsImporter = new SoftwareAdviceProductsImporter(_mockStreamReader.Object);
		}

		[Test(Description = "Given valid filePath with valid products then it")]
		public void Should_Return_Valid_List_Of_Products()
		{
			const string dummyProductsJson = @"{""products"": [{""categories"": [""Customer Service"",""Call Center""],""twitter"": ""@freshdesk"",""title"": ""Freshdesk""},{""categories"": [""CRM"",""Sales Management""],""title"": ""Zoho""}]}";

			var byteArray = Encoding.ASCII.GetBytes(dummyProductsJson);
			var stream = new MemoryStream(byteArray);

			_mockStreamReader.Setup(m => m.GetReader(It.IsAny<string>())).Returns(new StreamReader(stream));

			var products = _softwareAdviceProductsImporter.Import("foo");

			_mockStreamReader.Verify(m => m.GetReader(It.IsAny<string>()), Times.Once);

			products.Should().NotBeNull();
			products.Count.Should().Be(2);

			products.First().Name.Should().BeEquivalentTo("\"Freshdesk\"");
			products.First().Twitter.Should().BeEquivalentTo("@freshdesk");
			products.First().Categories[0].Should().BeEquivalentTo("Customer Service");
			products.First().Categories[1].Should().BeEquivalentTo("Call Center");
		}

		[Test(Description = "Given filePath which is not valid or products not found in the file then it")]
		public void Should_Return_Empty_List_Of_Products()
		{
			const string dummyProductsJson = @"{""products"":[]}";

			var byteArray = Encoding.ASCII.GetBytes(dummyProductsJson);
			var stream = new MemoryStream(byteArray);

			_mockStreamReader.Setup(m => m.GetReader(It.IsAny<string>())).Returns(new StreamReader(stream));

			var products = _softwareAdviceProductsImporter.Import("foo");

			_mockStreamReader.Verify(m => m.GetReader(It.IsAny<string>()), Times.Once);

			products.Should().NotBeNull();
			products.Count.Should().Be(0);
		}
	}
}
