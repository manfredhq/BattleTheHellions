using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeManSpell : ASpell
{
    public int damageMultiplicator = 1;
    public override void CastSpell()
    {
        ALivings target = SelectTarget()[0];
        target.TakeDamage(living.currentAttack * damageMultiplicator);
        BackEffect();
    }
}
