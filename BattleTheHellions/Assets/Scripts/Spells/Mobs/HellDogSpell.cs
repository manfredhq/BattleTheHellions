using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellDogSpell : ASpell
{
    public float damageMultiplicator = 2;
    public override void CastSpell()
    {
        List<ALivings> targets = SelectTarget();
        foreach (var target in targets)
        {
            target.TakeDamage((int)(living.currentAttack * damageMultiplicator));
        }
        BackEffect();
    }
}
