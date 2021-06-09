using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroesData
{
    public int maxHP;
    public int maxAttack;
    public int manaToCast;
    public int level;
    public int experiencePoint;
    public bool isRanged;
    public int hpGain;
    public int attackGain;
    public int identity;

    public HeroesData(ALivings heroe)
    {
        maxHP = heroe.maxHp;
        maxAttack = heroe.maxAttack;
        manaToCast = heroe.manaToCast;
        level = heroe.level;
        experiencePoint = heroe.currentExperience;
        isRanged = heroe.isRanged;
        hpGain = heroe.hpGain;
        attackGain = heroe.attackGain;
        Debug.Log(heroe.gameObject);
        identity = heroe.GetComponent<HeroManager>().index;
        Debug.Log(identity);
    }
}
