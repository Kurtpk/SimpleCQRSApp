using MediatR;
using SimpleCQRSApp.Domain.Models.Product;
using SimpleCQRSApp.Domain.Services;

namespace SimpleCQRSApp.Application.Commands.Product
{
	public class AddProductCommand : IRequest<Guid>
	{
        /// <summary>
        ///     Алиас продукта
        /// </summary>
        public string? Alias { get; set; }

        /// <summary>
        ///     Название продукта
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///     Тип продукта
        /// </summary>
        public ProductType Type { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductService _productService;

        public AddProductCommandHandler(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<Guid> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            return await _productService.AddProductAsync(
                    command.Alias,
                    command.Name,
                    command.Type,
                    false,
                    cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
