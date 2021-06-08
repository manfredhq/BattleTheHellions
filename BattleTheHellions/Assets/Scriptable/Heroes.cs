using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Heroes : ScriptableObject
{
    public attTypes attackType = attTypes.single;

    public bool isRanged = false;

    public int maxHp;

    public int manaToCast;

    public int maxAttack;
}
