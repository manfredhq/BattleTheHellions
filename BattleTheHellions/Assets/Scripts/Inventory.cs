using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ARelics> relicsOwn = new List<ARelics>();

    public void GetRelic(ARelics r)
    {
        relicsOwn.Add(r);
        foreach (var relicList in GameManager.instance.relicsAvailable)
        {
            relicList.Remove(r);
        }
    }

}

