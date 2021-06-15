using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAxe : ARelics
{
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            if(GameManager.instance.heroesPrefab[0].name == charater.name)
                charater.GetComponent<ALivings>().maxAttack += 3;
        }
    }

    public override void UndoEffect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            if (GameManager.instance.heroesPrefab[0].name == charater.name)
                charater.GetComponent<ALivings>().maxHp -= 3;
        }
    }
}
