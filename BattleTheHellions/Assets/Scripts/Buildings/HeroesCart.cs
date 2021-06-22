using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesCart : ABuilding
{
    public List<GameObject> heroes = new List<GameObject>();

    public List<GameObject> heroesInstance = new List<GameObject>();

    public GameObject heroesButtonPrefab;
    public override void Effect()
    {
        if(heroes.Count == 0)
            GenerateHeroes(level);
    }

    public override void UndoEffect()
    {
        foreach (var h in heroesInstance)
        {
            Destroy(h);
        }
    }

    private void GenerateHeroes(int number)
    {
        for (int i = 0; i < number; i++)
        {
            int rng = Random.Range(0,GameManager.instance.heroesPrefab.Count);
            heroes.Add(GameManager.instance.heroesPrefab[rng]);
            Debug.Log(GameManager.instance.heroesPrefab[rng].name);
        }
    }
}
