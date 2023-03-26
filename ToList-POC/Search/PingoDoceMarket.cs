using System;
using ToList_POC.Model;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace ToList_POC.Search
{
	public class PingoDoceMarket : Market
	{
		private const string SEARCH_URL = "https://www.pingodoce.pt/wp-content/themes/pingodoce/ajax/pd-ajax.php?action=pd_search_autocomplete&q={0}";
		private const string PRODUCT_URL = "https://www.pingodoce.pt/produtos/marca-propria-pingo-doce/pingo-doce/{0}/";

        public PingoDoceMarket() : base()
		{
		}

        public override async Task<IEnumerable<SearchResult>> SearchAsync(string product)
        {
            string[] products = await ProductSearchAsync(product);


            return null;
        }

        private async Task<string[]> ProductSearchAsync(string product)
        {
            using var httpResponse = await _httpClient.GetAsync(string.Format(SEARCH_URL, product));
            string searchJson = await httpResponse.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(searchJson);
            JToken data = jObject["data"]["results"];

            Regex regex = new Regex("href=\"([^\"]*)\"", RegexOptions.IgnoreCase);
            MatchCollection collection = regex.Matches(data.ToString());

            collection.ToList().ForEach((match) => Console.WriteLine(match.Groups.Values.LastOrDefault()));

            return null;
        }

        // private async Task<IEnumerable<SearchResult>> 
    }
}

