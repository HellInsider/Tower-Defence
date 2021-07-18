
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Text Name;
    public Image Icon;
    public Text Price;
    public GameObject Building;
    private BuildingsView _builder;
    private GameLogicManager _logicManager;
    private short _price;


    public void Present(BuildingProfile profile)
    {
        Icon.sprite = profile.Icon;
        Name.text = profile.Name;
        Building = profile.Building;
        _price = profile.Price;
        Price.text = profile.Price.ToString();

    }

    public void SetBuilder(BuildingsView _b)
    {
        _builder = _b;
    }

    public void SetBuilding()
    {
        if(_logicManager.PayMoney(_price))
        {
            _builder.StartBuildingMode(Building);
            _builder.Building = Building;
        }
    }

    public void SetGameLogicManager(GameLogicManager man)
    {
        _logicManager = man;
    }
}
