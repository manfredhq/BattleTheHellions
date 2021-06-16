using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaoCaoWeapon : ARelics
{
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().currentLifeStealPercentage += 11;
            charater.GetComponent<ALivings>().currentAttack += 25;
        }
    }

    public override void UndoEffect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            charater.GetComponent<ALivings>().currentLifeStealPercentage -= 11;
            charater.GetComponent<ALivings>().currentAttack -= 25;
        }
    }
}
