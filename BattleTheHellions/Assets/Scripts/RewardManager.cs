using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public float experienceMultiplier = 1;

    public void EarnExperience()
    {
        int amount = 0;
        var mobs = FightManager.instance.mobsParty.defeatedCaracter;
        foreach (var mob in mobs)
        {
            amount += mob.experienceDrop;
        }
        foreach (var heroe in Player.instance.heroes)
        {
            heroe.GetComponent<ALivings>().EarnExperience((int)(amount*experienceMultiplier));
        }
    }

    public void EarnExperience(int amount)
    {
        foreach (var heroe in Player.instance.heroes)
        {
            heroe.GetComponent<ALivings>().EarnExperience((int)(amount * experienceMultiplier));
        }
    }
    public void increaseExperienceMultiplier(int percentage)
    {
        experienceMultiplier += (percentage / 100);
    }

    public void decreaseExperienceMultiplier(int percentage)
    {
        experienceMultiplier -= (percentage / 100);
    }
}
