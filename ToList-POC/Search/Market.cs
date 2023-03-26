using System;
using ToList_POC.Model;

namespace ToList_POC.Search
{
	public abstract class Market
	{
		protected HttpClient _httpClient;

		public Market()
		{
			_httpClient = new HttpClient();
		}

		public abstract Task<IEnumerable<SearchResult>> SearchAsync(string product);
	}
}

