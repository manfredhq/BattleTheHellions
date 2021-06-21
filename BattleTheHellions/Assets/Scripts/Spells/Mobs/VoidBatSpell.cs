using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBatSpell : ASpell
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
