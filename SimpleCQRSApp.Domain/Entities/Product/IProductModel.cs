using SimpleCQRSApp.Domain.Entities.Base;
using SimpleCQRSApp.Domain.Models.Product;

namespace SimpleCQRSApp.Domain.Entities.Product
{
	public interface IProductModel : IEntity
	{
		public string? Alias { get; set; }

		public string? Name { get; set; }

		public ProductType Type { get; set; }

		public DateTimeOffset CreatedAt { get; set; }
	}
}
