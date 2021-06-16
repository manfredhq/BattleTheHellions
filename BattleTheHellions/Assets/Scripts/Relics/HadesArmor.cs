using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadesArmor : ARelics
{
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().maxHp += 2500;
        }
    }

    public override void UndoEffect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().maxHp -= 2500;
        }
    }
}
