using MediatR;
using SimpleCQRSApp.Domain.Services;

namespace SimpleCQRSApp.Application.Commands.Product
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

		async Task<Unit> IRequestHandler<DeleteProductCommand, Unit>.Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			await _productService.Delete(
                    request.Id,
                    false,
                    cancellationToken)
                .ConfigureAwait(false);

            return await Unit.Task.ConfigureAwait(false);
		}
	}
}
