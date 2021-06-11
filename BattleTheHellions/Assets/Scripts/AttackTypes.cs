using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypes : MonoBehaviour
{
    public List<ALivings> Attack(attTypes type, bool isHeroParty)
    {
        if(type == attTypes.single)
        {
            return SingleAtt(isHeroParty);
        }
        else if(type == attTypes.line)
        {
            return LineAtt(isHeroParty);
        }
        else if (type == attTypes.row)
        {
            return RowAtt(isHeroParty);
        }
        else if (type == attTypes.all)
        {
            return AllAtt(isHeroParty);
        }

        return null;
    }

    private List<ALivings> AllAtt(bool isHeroParty)
    {
        if (isHeroParty)
        {
            return FightManager.instance.mobsParty.team;
        }
        else
        {
            return FightManager.instance.heroParty.team;
        }
    }

    private List<ALivings> SingleAtt(bool isHeroParty)
    {
        List<ALivings> targets = new List<ALivings>();
        if (isHeroParty) { 
            var mobParty = FightManager.instance.mobsParty;
            foreach (var target in mobParty.team)
            {
                if (!mobParty.defeatedCaracter.Contains(target))
                {
                    targets.Add(target);
                    return targets;
                }
            }
        }
        else
        {
            var heroParty = FightManager.instance.heroParty;
            foreach (var target in heroParty.team)
            {
                if (!heroParty.defeatedCaracter.Contains(target))
                {
                    targets.Add(target);
                    return targets;
                }
            }
        }
        return null;
    }

    private List<ALivings> LineAtt(bool isHeroParty)
    {
        List<ALivings> targets = new List<ALivings>();
        if (isHeroParty) { 
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
        }
        else
        {
            var heroParty = FightManager.instance.heroParty;
            for (int i = 0; i < heroParty.team.Count; i++)
            {
                if (!heroParty.defeatedCaracter.Contains(heroParty.team[i]))
                {
                    targets.Add(heroParty.team[i]);
                    if (i < heroParty.team.Count && i < 3 && !heroParty.defeatedCaracter.Contains(heroParty.team[i + 3]))
                    {
                        targets.Add(heroParty.team[i + 3]);
                    }
                    return targets;
                }
            }
        }
        return null;
    }

    private List<ALivings> RowAtt(bool isHeroParty)
    {
        List<ALivings> targets = new List<ALivings>();
        if (isHeroParty) { 
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
                    targets.Add(mobParty.team[3]);
                }
                if (!mobParty.defeatedCaracter.Contains(mobParty.team[4]))
                {
                    targets.Add(mobParty.team[4]);
                }
                if (!mobParty.defeatedCaracter.Contains(mobParty.team[5]))
                {
                    targets.Add(mobParty.team[5]);
                }
            }
        }
        else
        {
            var heroParty = FightManager.instance.heroParty;
            if (!heroParty.defeatedCaracter.Contains(heroParty.team[0]) || !heroParty.defeatedCaracter.Contains(heroParty.team[1]) || !heroParty.defeatedCaracter.Contains(heroParty.team[2]))
            {
                if (!heroParty.defeatedCaracter.Contains(heroParty.team[0]))
                {
                    targets.Add(heroParty.team[0]);
                }
                if (!heroParty.defeatedCaracter.Contains(heroParty.team[1]))
                {
                    targets.Add(heroParty.team[1]);
                }
                if (!heroParty.defeatedCaracter.Contains(heroParty.team[2]))
                {
                    targets.Add(heroParty.team[2]);
                }
            }
            else if (!heroParty.defeatedCaracter.Contains(heroParty.team[3]) || !heroParty.defeatedCaracter.Contains(heroParty.team[4]) || !heroParty.defeatedCaracter.Contains(heroParty.team[5]))
            {
                if (!heroParty.defeatedCaracter.Contains(heroParty.team[3]))
                {
                    targets.Add(heroParty.team[3]);
                }
                if (!heroParty.defeatedCaracter.Contains(heroParty.team[4]))
                {
                    targets.Add(heroParty.team[4]);
                }
                if (!heroParty.defeatedCaracter.Contains(heroParty.team[5]))
                {
                    targets.Add(heroParty.team[5]);
                }
            }
        }
        return targets;
    }
}

public enum attTypes
{
    single,
    line,
    row,
    all
}