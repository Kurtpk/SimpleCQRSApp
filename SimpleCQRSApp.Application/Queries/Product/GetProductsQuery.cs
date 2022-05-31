using MediatR;
using SimpleCQRSApp.Domain.Models.Product;
using SimpleCQRSApp.Domain.Services;

namespace SimpleCQRSApp.Application.Queries.Product
{
	public class GetProductsQuery : IRequest<IEnumerable<IProduct?>>
	{
		public int? Take { get; set; }
	}

	public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<IProduct?>>
	{
		private readonly IProductService _productService;

		public GetProductsQueryHandler(IProductService productService)
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService));
		}

		public async Task<IEnumerable<IProduct?>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
		{
			// TODO: Фильтровать на уровне бд
			var products = await _productService.GetProducts(
					false,
					cancellationToken)
				.ConfigureAwait(false);

			if(query?.Take != null)
			{
				return products.Take(query.Take.Value);
			}
			
			return products;
		}
	}
}
