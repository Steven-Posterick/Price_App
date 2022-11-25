using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Price_App.Model;

namespace Price_App.Service;

public interface IPriceService {
    // Queries the IItemScraper, in our design it will be BestBuy
    // When the List is awaited we will set the list to our viewmodel.
    Task<List<ScrapedItem>> GetScrapedItems(String description);
 
    // Queries all the priced items for a specific scrapedItem 
    // This will be called when they expand the specific scrapedItem;
    // When finished awaiting it will be set to the List on the ScrapedItem called PricedItems. 
    Task<List<PricedItem>> GetPricedItems(ScrapedItem scrapedItem);
}

public class PriceService : IPriceService
{
    public Task<List<ScrapedItem>> GetScrapedItems(string description)
    {
        return Task.FromResult(new List<ScrapedItem>()
        {
            new ScrapedItem("GPU 1.0", "This is GPU 1 without a cooler"),
            new ScrapedItem("GPU 1.1", "This is GPU 1 with a cooler")
        });
    }

    public Task<List<PricedItem>> GetPricedItems(ScrapedItem scrapedItem)
    {
        return Task.FromResult(
            scrapedItem.ModelId == "GPU 1.0" ? new List<PricedItem>()
            {
                new PricedItem("Best Buy", 300),
                new PricedItem("Gamestop", 250),
                new PricedItem("New Egg", null)
            } : new List<PricedItem>()
            {
                new PricedItem("Best Buy", 320),
                new PricedItem("Gamestop", 310),
                new PricedItem("New Egg", 330)
            });
    }
}