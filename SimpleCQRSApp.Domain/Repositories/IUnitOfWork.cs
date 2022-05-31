using SimpleCQRSApp.Domain.Entities.Product;

namespace SimpleCQRSApp.Domain.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IProductRepository ProductRepository { get; }

		Task<int> SaveChangesAsync(
			bool continueOnCapturedContext,
			CancellationToken token);
	}
}
