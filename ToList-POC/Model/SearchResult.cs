using System;
namespace ToList_POC.Model
{
	public struct SearchResult
	{
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public SearchResult(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }
}
