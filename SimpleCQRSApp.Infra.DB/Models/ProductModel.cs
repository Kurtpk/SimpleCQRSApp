using SimpleCQRSApp.Domain.Entities.Product;
using SimpleCQRSApp.Domain.Models.Product;

namespace SimpleCQRSApp.Infra.DB.Models
{
	internal sealed class ProductModel : IProductModel
	{
		public Guid Id { get; set; }

		public string? Alias { get; set; }

		public string? Name { get; set; }

		public ProductType Type { get; set; }

		public DateTimeOffset CreatedAt { get; set; }
	}
}
