using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int Coin
    {
        get => PlayerPrefs.GetInt("Coin", 0);
        set => PlayerPrefs.SetInt("Coin", value);
    }
}
