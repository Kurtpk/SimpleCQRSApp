namespace SimpleCQRSApp.Domain.Repositories
{
	public interface IUnitOfWorkFactory
	{
		IUnitOfWork Create();

		IUnitOfWork CreateWithTransaction();
	}
}
