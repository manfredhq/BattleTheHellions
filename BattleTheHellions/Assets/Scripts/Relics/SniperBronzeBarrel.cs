using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBronzeBarrel : ARelics
{
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            if (GameManager.instance.heroesPrefab[1].name == charater.name)
                charater.GetComponent<ALivings>().maxAttack += 1;
        }
    }

    public override void UndoEffect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            if (GameManager.instance.heroesPrefab[1].name == charater.name)
                charater.GetComponent<ALivings>().maxAttack -= 1;
        }
    }
}
