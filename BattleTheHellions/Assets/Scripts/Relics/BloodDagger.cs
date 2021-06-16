using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDagger : ARelics
{
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().currentLifeStealPercentage += 10;
        }
    }

    public override void UndoEffect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().currentLifeStealPercentage -= 10;
        }
    }
}
