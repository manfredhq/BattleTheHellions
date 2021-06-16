using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAriesSpell : ASpell
{
    public int damageMultiplicator = 2;
    public override void CastSpell()
    {
        List<ALivings> targets = SelectTarget();
        foreach (var target in targets)
        {
            target.TakeDamage(living.currentAttack * damageMultiplicator);
        }
        BackEffect();
    }
}
