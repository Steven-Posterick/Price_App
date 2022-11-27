using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Price_App.Helper;
using Price_App.Model;
using Price_App.Service;

namespace Price_App.ViewModel;

public class PriceViewModel
{
    private readonly IPriceService _priceService;

    public PriceViewModel(IPriceService priceService)
    {
        _priceService = priceService;
    }

    public ICommand SearchWebsiteCommand => CommandHelper.CreateAsyncCommand(OnSearchWebsite);
    public ICommand SelectItemCommand => CommandHelper.CreateAsyncCommand<ScrapedItem>(OnSelectItem);
    
    private async Task OnSearchWebsite()
    {
        // TODO: Add Search functionality 
        MessageBox.Show("Searching...");
        var scrapedItems = await _priceService.GetScrapedItems("Intel I7 CPU");
        // Show results
        
    }

    private async Task OnSelectItem(ScrapedItem item)
    { 
        // TODO: Add Population when an item is selected.
        var pricedItems = await _priceService.GetPricedItems(item);
        item.PricedItems.Clear();
        pricedItems.ForEach(x=> item.PricedItems.Add(x));
    }
}