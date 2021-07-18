using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{
    private short _money = 200;
    [SerializeField]
    private Text MoneyUI;

    private void Start()
    {
        MoneyChanged();
    }

    public void AddMoney(short earned)
    {
        MoneyChanged();
        _money += earned;
    }

    public short GetMoney()
    {
        MoneyChanged();
        return _money;
    }

    public bool PayMoney(short money)
    {
        MoneyChanged();
        if (_money >= money)
        {
            _money -= money;
            return true;
        }
        return false;
    }

    private void MoneyChanged()
    {
        MoneyUI.text = string.Concat("Money ", _money.ToString());
    }

}
