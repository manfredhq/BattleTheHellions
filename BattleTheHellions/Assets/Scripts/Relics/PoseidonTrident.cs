using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonTrident : ARelics
{
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().maxAttack += 65;
        }
    }

    public override void UndoEffect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().maxAttack -= 65;
        }
    }
}
