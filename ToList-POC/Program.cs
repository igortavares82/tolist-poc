

// See https://aka.ms/new-console-template for more information
using ToList_POC.Search;

Console.WriteLine("Type a product name: ");
string product = Console.ReadLine();

PingoDoceMarket market = new PingoDoceMarket();
await market.SearchAsync(product);

Console.ReadKey();