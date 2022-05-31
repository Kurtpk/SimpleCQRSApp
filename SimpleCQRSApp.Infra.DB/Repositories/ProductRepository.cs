using SimpleCQRSApp.Domain.Entities.Product;
using SimpleCQRSApp.Domain.Models.Product;
using SimpleCQRSApp.Domain.Repositories;
using SimpleCQRSApp.Infra.DB.Models;

namespace SimpleCQRSApp.Infra.DB.Repositories
{
	internal sealed class ProductRepository : IProductRepository
	{
		private readonly Storage _storage;

		public ProductRepository(Storage storage)
		{
			_storage = storage ?? throw new ArgumentNullException(nameof(storage));
		}

		public async Task<IProductModel?> GetById(
			Guid id,
			bool continueOnCapturedContext,
			CancellationToken token)
		{
			var product = _storage.Products.FirstOrDefault(prd => prd?.Id == id);
			return await Task.FromResult(product).ConfigureAwait(continueOnCapturedContext);
		}

		public async Task<IReadOnlyCollection<IProductModel?>> GetAllAsync(
			bool continueOnCapturedContext,
			CancellationToken token)
		{
			IReadOnlyCollection<IProductModel?> products = _storage.Products.ToList();
			return await Task.FromResult(products).ConfigureAwait(continueOnCapturedContext);
		}

		public async Task<Guid> AddAsync(
			IProduct product,
			bool continueOnCapturedContext,
			CancellationToken token)
		{
			var newProduct = new ProductModel
			{
				Id = Guid.NewGuid(),
				Alias = product.Alias,
				Name = product.Name,
				Type = product.Type,
				CreatedAt = DateTime.UtcNow
			};

			_storage.Products.Add(newProduct);

			return await Task.FromResult(newProduct.Id).ConfigureAwait(continueOnCapturedContext);
		}

		public async Task DeleteAsync(
			Guid id,
			bool continueOnCapturedContext,
			CancellationToken token)
		{
			if (_storage.Products.Any(prd => prd?.Id == id))
			{
				// хаха
				var temp = _storage.Products.ToList();
				_storage.Products.Clear();
				
				foreach (var product in temp)
				{
					if (product?.Id != id)
					{
						_storage.Products.Add(product);
					}
				}
			}

			await Task.CompletedTask.ConfigureAwait(continueOnCapturedContext);
		}
	}
}
