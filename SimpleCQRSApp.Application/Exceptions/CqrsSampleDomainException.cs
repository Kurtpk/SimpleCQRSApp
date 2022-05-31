namespace SimpleCQRSApp.Application.Exceptions
{
	public sealed class CqrsSampleDomainException : Exception
	{
		public CqrsSampleDomainException()
		{
		}

		public CqrsSampleDomainException(string message)
			: base(message)
		{
		}

		public CqrsSampleDomainException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
