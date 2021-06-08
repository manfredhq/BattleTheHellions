using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypes : MonoBehaviour
{
    public List<ALivings> Attack(attTypes type)
    {
        if(type == attTypes.single)
        {
            return SingleAtt();
        }
        else if(type == attTypes.line)
        {
            return LineAtt();
        }
        else if (type == attTypes.row)
        {
            return RowAtt();
        }

        return null;
    }

    private List<ALivings> SingleAtt()
    {
        List<ALivings> targets = new List<ALivings>();
        var mobParty = FightManager.instance.mobsParty;
        foreach (var target in mobParty.team)
        {
            if (!mobParty.defeatedCaracter.Contains(target))
            {
                targets.Add(target);
                return targets;
            }
        }
        return null;
    }

    private List<ALivings> LineAtt()
    {
        List<ALivings> targets = new List<ALivings>();
        var mobParty = FightManager.instance.mobsParty;
        for (int i = 0; i < mobParty.team.Count; i++)
        {
            if (!mobParty.defeatedCaracter.Contains(mobParty.team[i]))
            {
                targets.Add(mobParty.team[i]);
                if (i< mobParty.team.Count && i < 3 && !mobParty.defeatedCaracter.Contains(mobParty.team[i + 3]))
                {
                    targets.Add(mobParty.team[i + 3]);
                }
                return targets;
            }
        }
        return null;
    }

    private List<ALivings> RowAtt()
    {
        List<ALivings> targets = new List<ALivings>();
        var mobParty = FightManager.instance.mobsParty;
        if(!mobParty.defeatedCaracter.Contains(mobParty.team[0]) || !mobParty.defeatedCaracter.Contains(mobParty.team[1]) || !mobParty.defeatedCaracter.Contains(mobParty.team[2]))
        {
            if (!mobParty.defeatedCaracter.Contains(mobParty.team[0]))
            {
                targets.Add(mobParty.team[0]);
            }
            if (!mobParty.defeatedCaracter.Contains(mobParty.team[1]))
            {
                targets.Add(mobParty.team[1]);
            }
            if (!mobParty.defeatedCaracter.Contains(mobParty.team[2]))
            {
                targets.Add(mobParty.team[2]);
            }
        }
        else if (!mobParty.defeatedCaracter.Contains(mobParty.team[3]) || !mobParty.defeatedCaracter.Contains(mobParty.team[4]) || !mobParty.defeatedCaracter.Contains(mobParty.team[5]))
        {
            if (!mobParty.defeatedCaracter.Contains(mobParty.team[3]))
            {
                targets.Add(mobParty.team[0]);
            }
            if (!mobParty.defeatedCaracter.Contains(mobParty.team[4]))
            {
                targets.Add(mobParty.team[1]);
            }
            if (!mobParty.defeatedCaracter.Contains(mobParty.team[5]))
            {
                targets.Add(mobParty.team[2]);
            }
        }
        return targets;
    }
}

public enum attTypes
{
    single,
    line,
    row
}