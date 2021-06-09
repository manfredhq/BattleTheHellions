using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARelics : MonoBehaviour
{
    public RelicRarity rarity = RelicRarity.common;
    public new string name;
    public string description;

    public int id;
    public virtual void Effect()
    {
        Debug.Log("relic name " + name + " has use its effect");
    }

    public virtual void UndoEffect()
    {
        Debug.Log("relic name " + name + " has undo its effect");
    }
}

public enum RelicRarity
{
    common,
    uncommon,
    rare,
    epic,
    lengendary,
    mythic,
    godlike
}