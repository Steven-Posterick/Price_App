﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Price_App.Model;
using Price_App.Provider;
using Price_App.Provider.Impl;

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
    private readonly IItemScraper _itemScraper;
    private readonly List<IPriceProvider> _priceProviders;
    public PriceService(
        IBestBuyProvider bestBuyProvider,
        // ReSharper disable once SuggestBaseTypeForParameterInConstructor
        IMicroCenterPriceProvider microCenterPriceProvider,
        // ReSharper disable once SuggestBaseTypeForParameterInConstructor
        INewEggPriceProvider newEggPriceProvider)
    {
        _priceProviders = new List<IPriceProvider>
        {
            bestBuyProvider,
            microCenterPriceProvider,
            newEggPriceProvider
        };
        
        _itemScraper = bestBuyProvider;
    }

    public Task<List<ScrapedItem>> GetScrapedItems(string description) => _itemScraper.GetScrapedItems(description);

    public Task<List<PricedItem>> GetPricedItems(ScrapedItem scrapedItem)
    {
        return Task.FromResult(
            scrapedItem.ModelId == "GPU 1.0" ? new List<PricedItem>()
            {
                new PricedItem("Best Buy", 300, ""),
                new PricedItem("Gamestop", 250, ""),
                new PricedItem("New Egg", null, "")
            } : new List<PricedItem>()
            {
                new PricedItem("Best Buy", 320, ""),
                new PricedItem("Gamestop", 310, ""),
                new PricedItem("New Egg", 330, "")
            });
    }
}