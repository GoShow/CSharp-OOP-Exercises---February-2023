using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interfaces;

public interface IFoodFactory
{
    IFood CreateFood(string type, int quantity);
}
