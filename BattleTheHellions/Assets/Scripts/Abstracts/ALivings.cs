using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALivings : MonoBehaviour
{
    public attTypes attackType = attTypes.single;
    public bool isHeroParty;

    public int maxHp;
    public int currentHp;

    public int manaToCast;
    public int currentMana;

    public int maxAttack;
    public int currentAttack;

    public TeamManager team;


    private void Awake()
    {
        currentHp = maxHp;
        currentAttack = maxAttack;
    }

    public void Heal(int amount)
    {
        Debug.Log("heal " + amount);
        currentHp += amount;
        if (currentHp > maxHp) { currentHp = maxHp; }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(gameObject.name + " take " + amount);
        currentHp -= amount;
        if (currentHp <= 0) { Die(); }
    }


    private void DealDamage(List<ALivings> targets)
    {
        foreach (var target in targets)
        {
            Debug.Log(gameObject.name + " is targeting " + target.gameObject.name);
            target.TakeDamage(currentAttack);
        }
    }

    public void Die()
    {
        Debug.Log("die " + gameObject.name);
        team.DeathCaracter(this);
        gameObject.SetActive(false);
    }

    public void Attack()
    {
        DealDamage(FightManager.instance.attacks.Attack(attackType, isHeroParty));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
