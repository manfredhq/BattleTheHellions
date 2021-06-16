using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : ALivings
{
    public int index;

    public void Setup(HeroesData data)
    {
        maxHp = data.maxHP;
        maxAttack = data.maxAttack;
        manaToCast = data.manaToCast;
        level = data.level;
        currentExperience = data.experiencePoint;
        isRanged = data.isRanged;
        hpGain = data.hpGain;
        attackGain = data.attackGain;
        index = data.identity;
    }
}
