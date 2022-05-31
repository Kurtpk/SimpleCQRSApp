using SimpleCQRSApp.Domain.Repositories;

namespace SimpleCQRSApp.Infra.DB.Repositories
{
	internal sealed class UnitOfWork : IUnitOfWork
	{
		private readonly Storage _storage;

		//private readonly IDbContextTransaction _transaction;
		//private volatile int _commited;
		//private volatile int _disposed;

		public IProductRepository ProductRepository { get; }

		public UnitOfWork(bool withTransaction = false)
		{
			//_commited = 0;
			//_disposed = 0;

			//if (withTransaction)
			//{
			//	_transaction = _context.Database.BeginTransaction();
			//}

			_storage = new Storage();
			ProductRepository = new ProductRepository(_storage);
		}

		public void Dispose()
		{
			//if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 1)
			//{
			//	return;
			//}

			//if (_transaction != null)
			//{
			//	if (_context.ChangeTracker.HasChanges())
			//	{
			//		if (Interlocked.CompareExchange(ref _commited, 0, 0) == 0)
			//		{
			//			_transaction.Rollback();
			//		}
			//	}

			//	_transaction.Dispose();
			//}

			//_context.Dispose();
		}

		public async Task<int> SaveChangesAsync(bool continueOnCapturedContext, CancellationToken token)
		{
			// Так как не используется подключение к бд используется заглушка, ниже реальный пример:

			//if (_disposed == 1)
			//{
			//	throw new ObjectDisposedException("UoW");
			//}

			//Interlocked.CompareExchange(ref _commited, 1, 0);

			//var result = await _context.SaveChangesAsync(token).ConfigureAwait(false);

			//if (_transaction != null)
			//{
			//	await _transaction.CommitAsync(token);
			//}

			//return result;

			return await Task.FromResult(0).ConfigureAwait(continueOnCapturedContext);
		}
	}
}
