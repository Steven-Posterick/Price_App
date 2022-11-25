using System.Threading.Tasks;
using Price_App.Model;

namespace Price_App.Provider.Impl;

public interface INewEggPriceProvider : IPriceProvider { }
public class NewEggPriceProvider : INewEggPriceProvider
{
    public Task<PricedItem> GetPricedItems(string modelId)
    {
        throw new System.NotImplementedException();
    }
}