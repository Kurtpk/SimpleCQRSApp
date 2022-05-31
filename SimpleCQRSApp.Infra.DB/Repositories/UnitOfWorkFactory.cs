using SimpleCQRSApp.Domain.Repositories;

namespace SimpleCQRSApp.Infra.DB.Repositories
{
	internal sealed class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		public IUnitOfWork Create()
		{
			return new UnitOfWork();
		}

		public IUnitOfWork CreateWithTransaction()
		{
			// Так как храним сущности в памяти, повторяет реализацию, как без транзакции
			return new UnitOfWork(/*true*/);
		}
	}
}
