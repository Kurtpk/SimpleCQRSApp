using SimpleCQRSApp.Domain.Entities.Base;
using SimpleCQRSApp.Domain.Models.Product;

namespace SimpleCQRSApp.Domain.Repositories.Base
{
	public interface IRepository<T> where T : IEntity?
	{
		Task<T> GetById(
			Guid id,
			bool continueOnCapturedContext,
			CancellationToken token);

		Task<IReadOnlyCollection<T>> GetAllAsync(
			bool continueOnCapturedContext,
			CancellationToken token);

		Task<Guid> AddAsync(
			IProduct product,
			bool continueOnCapturedContext,
			CancellationToken token);

		Task DeleteAsync(
			Guid id,
			bool continueOnCapturedContext,
			CancellationToken token);
	}
}
