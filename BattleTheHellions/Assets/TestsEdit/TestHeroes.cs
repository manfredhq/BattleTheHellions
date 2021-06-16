using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestHeroes
{
    [Test]
    public void TestOverHeal()
    {
        int currentHP = 10;
        int maxHP = 15;
        ALivings h = new ALivings();
        h.currentHp = currentHP;
        h.maxHp = maxHP;
        h.Heal(10);
        Assert.AreEqual(maxHP, h.currentHp);
    }

    [Test]
    public void TestHeal()
    {
        int currentHP = 4;
        int maxHP = 15;
        ALivings h = new ALivings();
        h.currentHp = currentHP;
        h.maxHp = maxHP;
        h.Heal(10);
        Assert.AreEqual(currentHP+10, h.currentHp);
    }

    [Test]
    public void TestEarnExperience()
    {
        ALivings h = new ALivings();
        h.currentExperience = 0;
        h.level = 5;
        h.EarnExperience(24);
        Assert.AreEqual(24, h.currentExperience);
    }
    [Test]
    public void TestLevelUp()
    {
        ALivings h = new ALivings();
        h.currentExperience = 0;
        h.level = 5;
        h.EarnExperience(25);
        Assert.AreEqual(6, h.level);
    }
}
