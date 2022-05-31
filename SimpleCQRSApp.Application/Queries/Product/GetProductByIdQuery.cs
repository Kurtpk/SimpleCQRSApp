using MediatR;
using SimpleCQRSApp.Domain.Models.Product;
using SimpleCQRSApp.Domain.Services;


namespace SimpleCQRSApp.Application.Queries.Product
{
	public class GetProductByIdQuery : IRequest<IProduct?>
	{
		public Guid Id { get; set; }
	}

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, IProduct?>
    {
        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IProduct?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _productService.GetProductById(
                    query.Id,
                    false,
                    cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
