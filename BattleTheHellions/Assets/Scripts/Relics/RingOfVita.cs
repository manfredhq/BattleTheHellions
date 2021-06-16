using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfVita : ARelics
{
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().maxHp += 2;
        }
    }

    public override void UndoEffect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().maxHp -= 2;
        }
    }
}
