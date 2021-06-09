using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerBook : ARelics
{
    public override void Effect()
    {

        FightManager.instance.rewardManager.increaseExperienceMultiplier(15);
    }

    public override void UndoEffect()
    {
        FightManager.instance.rewardManager.decreaseExperienceMultiplier(15);
    }
}
