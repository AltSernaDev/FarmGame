using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resouces : MonoBehaviour
{
    private int gold; // hard currency
    private int money; // soft currency

    public int Gold { get => gold;}
    public int Money { get => money;}

    public bool AddGold(int amount)
    {
        if (amount > 0)
        {
            gold += amount;
            return true;
        }
        return false;
    }
    public bool PayGold(int amount)
    {
        if (amount > 0 && (gold - amount) >= 0)
        {
            gold -= amount;
            return true;
        }
        return false;
    }

    public bool AddMoney(int amount)
    {
        if (amount > 0)
        {
            money += amount;
            return true;
        }
        return false;
    }
    public bool PayMoney(int amount)
    {
        if (amount > 0 && (money - amount) >= 0)
        {
            money -= amount;
            return true;
        }
        return false;
    }
}
