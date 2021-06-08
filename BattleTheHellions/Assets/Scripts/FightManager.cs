using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public float timeBetweenAttacks = 2.0f;

    public AttackTypes attacks = new AttackTypes();

    public static FightManager instance;

    public TeamManager mobsParty;
    public TeamManager heroParty;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        attacks = new AttackTypes();
        heroParty = GameManager.instance.heroParty;

        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        

        if (mobsParty.isTeamDefeated)
        {
            Debug.Log("Hero's party win");
        }
        else if(heroParty.isTeamDefeated)
        {
            Debug.Log("Mobs's party win");
        }
    }

    IEnumerator Attack()
    {
        while (!mobsParty.isTeamDefeated && !heroParty.isTeamDefeated)
        {
            //Fight
            for (int i = 0; i < Mathf.Max( mobsParty.count() ,heroParty.count()); i++)
            {
                Debug.Log("Attack");
                if (heroParty.team[i] && !heroParty.defeatedCaracter.Contains(heroParty.team[i])) { 
                    heroParty.team[i].Attack();
                    yield return new WaitForSeconds(timeBetweenAttacks);
                }
                if (mobsParty.team[i] && !mobsParty.defeatedCaracter.Contains(mobsParty.team[i]))
                {
                    mobsParty.team[i].Attack();
                    yield return new WaitForSeconds(timeBetweenAttacks);
                }
            }
        }
    }
}
