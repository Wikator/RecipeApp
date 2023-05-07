using System.Text.Json;
using webapi.Helpers;

namespace webapi.Extensions
{
	public static class HttpExtensions
	{
		public static HttpResponse AddPaginationHeader(this HttpResponse response, PaginationHeader header)
		{
			JsonSerializerOptions options = new()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

			response.Headers.Add("Pagination", JsonSerializer.Serialize(header, options));
			response.Headers.Add("Access-Control-Expose-Headers", "Pagination");

			return response;
		}
	}
}
