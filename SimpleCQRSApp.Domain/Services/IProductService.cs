using SimpleCQRSApp.Domain.Models.Product;

namespace SimpleCQRSApp.Domain.Services
{
	public interface IProductService
	{
		Task<IEnumerable<IProduct?>> GetProducts(
			bool continueOnCapturedContext,
			CancellationToken token);

		Task<IProduct?> GetProductById(
			Guid productId,
			bool continueOnCapturedContext,
			CancellationToken token);

		Task<Guid> AddProductAsync(
			string? alias,
			string? name,
			ProductType type,
			bool continueOnCapturedContext,
			CancellationToken token);

		Task Delete(
			Guid productId,
			bool continueOnCapturedContext,
			CancellationToken token);
	}
}
