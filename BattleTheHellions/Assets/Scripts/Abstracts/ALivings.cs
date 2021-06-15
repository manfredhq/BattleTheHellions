using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALivings : MonoBehaviour
{
    public attTypes attackType = attTypes.single;
    public bool isHeroParty;

    public bool isRanged = false;

    public int maxHp;
    public int currentHp;

    public int manaToCast;
    public int currentMana;

    public int maxAttack;
    public int currentAttack;

    public int currentExperience;
    public int level = 1;

    public TeamManager team;

    public int experienceDrop;

    public int hpGain;
    public int attackGain;

    public int manaGainByAttack = 10;

    public float lifeStealPercentage = 0;
    public float currentLifeStealPercentage = 0;

    public ASpell spell;

    private void Start()
    {
        currentHp = maxHp;
        currentAttack = maxAttack;
        DontDestroyOnLoad(this.gameObject);
    }
    public void Setup()
    {
        currentHp = maxHp;
        currentAttack = maxAttack;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Heal(int amount)
    {
        Debug.Log("heal " + amount);
        currentHp += amount;
        if (currentHp > maxHp) { currentHp = maxHp; }
    }

    public int TakeDamage(int amount)
    {
        //StartCoroutine(damageAnim(3));
        Debug.Log(gameObject.name + " take " + amount);
        currentHp -= amount;

        if (currentHp <= 0) { StartCoroutine(Die()); }
        return amount;
    }

    IEnumerator damageAnim(int loopNumber)
    {
        for (int i = 0; i < loopNumber*2; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void DealDamage(List<ALivings> targets)
    {
        foreach (var target in targets)
        {
            Debug.Log(gameObject.name + " is targeting " + target.gameObject.name);

            Heal((int)(target.TakeDamage(currentAttack) * (currentLifeStealPercentage/100)));
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("die " + gameObject.name);
        team.DeathCaracter(this);
        gameObject.SetActive(false);
    }

    public void Attack()
    {
        
        if(currentMana >= manaToCast)
        {
            var targets = spell.SelectTarget();
            StartCoroutine(positionChangement(targets));
            spell.CastSpell();
        }
        else 
        {
            var targets = FightManager.instance.attacks.Attack(attackType, isHeroParty);
            StartCoroutine(positionChangement(targets));
            DealDamage(targets);
        }
    }
    IEnumerator positionChangement(List<ALivings> targets)
    {
        if (!isRanged) { 
            if(attackType == attTypes.single || attackType == attTypes.line) { 
                Vector3 currentpos = gameObject.transform.position;
                gameObject.transform.position = targets[0].transform.position;
                yield return new WaitForSeconds(0.5f);
                gameObject.transform.position = currentpos;
            }
            else if(attackType == attTypes.row)
            {
                if(targets.Count == 3)
                {
                    Vector3 currentpos = gameObject.transform.position;
                    gameObject.transform.position = targets[1].transform.position;
                    yield return new WaitForSeconds(0.5f);
                    gameObject.transform.position = currentpos;
                }
                else
                {
                    Vector3 currentpos = gameObject.transform.position;
                    gameObject.transform.position = targets[0].transform.position;
                    yield return new WaitForSeconds(0.5f);
                    gameObject.transform.position = currentpos;
                }
            }
        }
        else
        {
            if (isHeroParty) { 
                Vector3 currentpos = gameObject.transform.position;
                gameObject.transform.position += transform.right;
                yield return new WaitForSeconds(0.5f);
                gameObject.transform.position = currentpos;
            }
            else
            {
                Vector3 currentpos = gameObject.transform.position;
                gameObject.transform.position -= transform.right;
                yield return new WaitForSeconds(0.5f);
                gameObject.transform.position = currentpos;
            }
        }
    }

    public void EarnExperience(int amount)
    {
        currentExperience += amount;
        while(currentExperience >= level * level)
        {
            LevelUP();
        }
    }

    private void LevelUP()
    {
        currentExperience -= level * level;
        level++;
        maxAttack += attackGain;
        maxHp += hpGain;
    }
}
