using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABuilding : MonoBehaviour
{
    public int id;
    public new string name;
    public string description;
    public int level = 0;
    public int maxLevel = 10;
    public bool isBuild = false;
    public BuildingEffectMoment moment;
    public virtual void Effect()
    {
        Debug.Log("building effect at " + moment);
    }

    public virtual void UndoEffect()
    {
        Debug.Log("building undo effect at " +moment);
    }
}

public enum BuildingEffectMoment
{
    combat,
    town
}
