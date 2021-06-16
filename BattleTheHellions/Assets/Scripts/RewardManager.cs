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

    public ARelics RandomRelic()
    {
        GameManager gManager = GameManager.instance;
        ARelics reward = null;
        if (DungeonManager.instance.selectedDifficulty == 1)
        {
            var rng = Random.Range(0, 1);
            for (int i = 0; i < gManager.easyRelicRates.Length; i++)
            {
                if(rng <= gManager.easyRelicRates[i] && reward == null)
                {
                    if (gManager.relicsAvailable[i].Count == 0)
                    {
                        Debug.Log("No more relics of the quality got are obtainable");
                        return null;
                    }
                    var r = Random.Range(0, gManager.relicsAvailable[i].Count);
                    reward = gManager.relicsAvailable[i][r];
                    i = 7;
                }
            }
        }
        return reward;
    }

    public void RandomGold(float multiplier = 1f)
    {

    }
}
