using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpell : ASpell
{
    public int numberOfShoot = 2;
    public int damageMultiplcator = 1;
    public override void CastSpell()
    {
        ALivings target = SelectTarget()[0];
        for (int i = 0; i < numberOfShoot; i++)
        {
            target.TakeDamage(living.currentAttack * damageMultiplcator);
        }
        BackEffect();
    }
}
