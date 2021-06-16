using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGodBarrel : ARelics
{
    private List<int> baseAttacks = new List<int>();
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            if (GameManager.instance.heroesPrefab[1].name == charater.name)
            {
                baseAttacks.Add(charater.GetComponent<ALivings>().maxAttack);
                //Augment the attack by 5%
                charater.GetComponent<ALivings>().maxAttack += (int)((charater.GetComponent<ALivings>().maxAttack / 100f) * 5);
            }
        }
    }

    public override void UndoEffect()
    {
        for (int i = 0; i < Player.instance.heroes.Count; i++)
        {
            ALivings character = Player.instance.heroes[i].GetComponent<ALivings>();
            if (GameManager.instance.heroesPrefab[1].name == character.name)
            {
                character.GetComponent<ALivings>().maxAttack = baseAttacks[i];
            }
        }

        baseAttacks = new List<int>();
    }
}
