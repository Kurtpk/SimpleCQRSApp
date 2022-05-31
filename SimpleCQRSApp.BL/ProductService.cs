using SimpleCQRSApp.Domain.Models.Product;
using SimpleCQRSApp.Domain.Models.Product.Default;
using SimpleCQRSApp.Domain.Repositories;
using SimpleCQRSApp.Domain.Services;

namespace SimpleCQRSApp.BL
{
	internal sealed class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IUnitOfWorkFactory unitOfWorkFactory)
		{
			_unitOfWork = unitOfWorkFactory?.Create() ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
		}

		public async Task<IEnumerable<IProduct?>> GetProducts(
			bool continueOnCapturedContext,
			CancellationToken token)
		{
			var products = await _unitOfWork.ProductRepository.GetAllAsync(
					continueOnCapturedContext,
					token)
				.ConfigureAwait(continueOnCapturedContext);

			if (products.Any() != true)
			{
				return new List<IProduct?>();
			}

			return products
				.Where(prd => prd != null)
				.Select(prd => new Product(
					prd.Id,
					prd.Alias,
					prd.Name,
					prd.Type,
					prd.CreatedAt))
				.ToList();
		}

		public async Task<IProduct?> GetProductById(
			Guid productId,
			bool continueOnCapturedContext,
			CancellationToken token)
		{
			var productModel = await _unitOfWork.ProductRepository.GetById(
					productId,
					continueOnCapturedContext,
					token)
				.ConfigureAwait(continueOnCapturedContext);

			if(productModel == null)
			{
				return null;
			}

			return new Product(
				productModel.Id,
				productModel.Alias,
				productModel.Name,
				productModel.Type,
				productModel.CreatedAt);
		}

		public async Task<Guid> AddProductAsync(
			string? alias,
			string? name,
			ProductType type,
			bool continueOnCapturedContext,
			CancellationToken token)
		{
			IProduct newProduct = new Product(
				Guid.Empty,
				alias,
				name,
				type,
				DateTimeOffset.MinValue);

			return await _unitOfWork.ProductRepository.AddAsync(
					newProduct,
					continueOnCapturedContext,
					token)
				.ConfigureAwait(continueOnCapturedContext);
		}

		public async Task Delete(
			Guid productId,
			bool continueOnCapturedContext,
			CancellationToken token)
		{
			await _unitOfWork.ProductRepository.DeleteAsync(
					productId,
					continueOnCapturedContext,
					token)
				.ConfigureAwait(continueOnCapturedContext);
		}
	}
}
