using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataStorage
{
    public HeroesData[] heroes;

    public DataStorage(Player player)
    {
        for (int i = 0; i < player.heroes.Count; i++)
        {
            heroes.SetValue(new HeroesData(player.heroes[i].GetComponent<ALivings>()),i);
        }
    }
}
