namespace SimpleCQRSApp.Domain.Models.Product.Default
{
	/// <inheritdoc cref="IProduct"/>
	public sealed class Product : IProduct
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Идентификатор продукта</param>
		/// <param name="alias">Алиас продукта</param>
		/// <param name="name">Название продукта</param>
		/// <param name="type">Тип продукта</param>
		/// <param name="createdAt">Дата создания продукта</param>
		public Product(
			Guid id,
			string? alias,
			string? name,
			ProductType type,
			DateTimeOffset createdAt)
		{
			Id = id;
			Alias = alias;
			Name = name;
			Type = type;
			CreatedAt = createdAt;
		}

		public Guid Id { get; }

		public string? Alias { get; }

		public string? Name { get; }

		public ProductType Type { get; }

		public DateTimeOffset CreatedAt { get; }
	}
}
