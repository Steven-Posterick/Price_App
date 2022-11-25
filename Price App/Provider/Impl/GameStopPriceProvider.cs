using System.Threading.Tasks;
using Price_App.Model;

namespace Price_App.Provider;

public interface IGameStopPriceProvider : IPriceProvider {}
public class GameStopPriceProvider : IGameStopPriceProvider
{
    public Task<PricedItem> GetPricedItems(string modelId)
    {
        throw new System.NotImplementedException();
    }
}