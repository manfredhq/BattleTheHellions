using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALivings : MonoBehaviour
{
    public int maxHp;
    public int currentHp;

    public int manaToCast;
    public int currentMana;

    public int maxAttack;
    public int currentAttack;

    public TeamManager team;

    // Start is called before the first frame update
    void Start()
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

    public void DealDamage(ALivings target)
    {
        Debug.Log(gameObject.name +" is targeting " + target.gameObject.name);
        target.TakeDamage(currentAttack);
    }

    public void Die()
    {
        Debug.Log("die " + gameObject.name);
        team.team.Remove(this);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
