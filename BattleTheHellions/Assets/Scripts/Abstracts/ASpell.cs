using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASpell : MonoBehaviour
{
    public attTypes attType;
    public ALivings living;
    public string spellName;

    public List<ALivings> SelectTarget()
    {
        return FightManager.instance.attacks.Attack(attType, living.isHeroParty);
    }

    protected void BackEffect()
    {
        living.currentMana -= living.manaToCast;
        Debug.Log("Unit " + living.name + " casted his spell named " + spellName);
    }

    public virtual void CastSpell()
    {
        Debug.Log("Cast spell from Aspell");
    }
}
