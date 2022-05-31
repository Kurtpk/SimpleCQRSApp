using SimpleCQRSApp.Domain.Entities.Product;
using System.Collections.Concurrent;

namespace SimpleCQRSApp.Infra.DB
{
	internal sealed class Storage
	{
		public ConcurrentBag<IProductModel?> Products { get; }

		public Storage()
		{
			Products = new ConcurrentBag<IProductModel?>();
		}
	}
}
