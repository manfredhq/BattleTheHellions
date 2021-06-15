using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAxe : ARelics
{
    private List<int> baseAttacks = new List<int>();
    public override void Effect()
    {
        foreach (var charater in Player.instance.heroes)
        {
            if (GameManager.instance.heroesPrefab[0].name == charater.name) {
                baseAttacks.Add(charater.GetComponent<ALivings>().maxAttack);
                charater.GetComponent<ALivings>().maxAttack -= (int)((charater.GetComponent<ALivings>().maxAttack / 100f) * 2); ;
                charater.GetComponent<ALivings>().numberOfHit += 1;
            }
        }
    }

    public override void UndoEffect()
    {
        for (int i = 0; i < Player.instance.heroes.Count; i++)
        {
            ALivings character = Player.instance.heroes[i].GetComponent<ALivings>();
            if (GameManager.instance.heroesPrefab[0].name == character.name)
            {
                character.maxAttack = baseAttacks[i];
                character.numberOfHit -= 1;
            }
        }

        baseAttacks = new List<int>();
    }
}
