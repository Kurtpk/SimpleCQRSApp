namespace SimpleCQRSApp.Domain.Models.Product
{
	public interface IProduct
	{
		/// <summary>
		/// Идентификатор продукта
		/// </summary>
		public Guid Id { get; }

		/// <summary>
		/// Алиас продукта
		/// </summary>
		public string? Alias { get; }

		/// <summary>
		/// Название продукта
		/// </summary>
		public string? Name { get; }

		/// <summary>
		/// Тип продукта
		/// </summary>
		public ProductType Type { get; }

		/// <summary>
		/// Дата создания продукта
		/// </summary>
		public DateTimeOffset CreatedAt { get; }
	}
}
