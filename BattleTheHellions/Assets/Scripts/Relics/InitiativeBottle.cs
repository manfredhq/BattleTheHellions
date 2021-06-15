using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiativeBottle : ARelics
{
    public override void Effect()
    {
        foreach (var mob in FightManager.instance.mobsParty.team)
        {
            //reduce the maxHP of all mobs by 2 percent
            mob.maxHp -= (int)((mob.maxHp/100f)*2);
        }
    }

    public override void UndoEffect()
    {
        foreach (var mob in FightManager.instance.mobsParty.team)
        {
            mob.maxHp += (int)((mob.maxHp / 100f)*2);
        }
    }
}
