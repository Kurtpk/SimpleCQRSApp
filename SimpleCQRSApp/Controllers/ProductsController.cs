using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRSApp.Application.Commands.Product;
using SimpleCQRSApp.Application.Queries.Product;
using SimpleCQRSApp.Domain.Models.Product;

namespace SimpleCQRSApp.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<IProduct>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetProducts(
			[FromQuery] GetProductsQuery request,
			CancellationToken token)
		{
			return Ok(await _mediator.Send(request, token));
		}

		[HttpGet("{id:guid}")]
		[ProducesResponseType(typeof(IProduct), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetProductById(
			[FromRoute]Guid id,
			CancellationToken token)
		{
			return Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }, token));
		}

		[HttpPost]
		[ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> AddProduct(
			[FromBody] AddProductCommand client,
			CancellationToken token)
		{
			var id = await _mediator.Send(client, token);
			return Ok(id);
			//return CreatedAtAction(nameof(GetProductById), id);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> DeleteProduct(
			[FromQuery] DeleteProductCommand request,
			CancellationToken token)
		{
			return Ok(await _mediator.Send(request, token));
		}
	}
}
