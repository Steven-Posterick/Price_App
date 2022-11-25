using System.Collections.Generic;
using System.Threading.Tasks;
using Price_App.Model;

namespace Price_App.Provider.Impl;

public interface IBestBuyProvider : IItemScraper, IPriceProvider { }
public class BestBuyProvider : IBestBuyProvider
{
    public Task<List<ScrapedItem>> GetScrapedItems(string description)
    {
        return Task.FromResult(new List<ScrapedItem>()
        {
            new ScrapedItem("GPU 1.0", "This is GPU 1 without a cooler"),
            new ScrapedItem("GPU 1.1", "This is GPU 1 with a cooler")
        });
    }

    public Task<PricedItem> GetPricedItems(string modelId)
    {
        throw new System.NotImplementedException();
    }
}