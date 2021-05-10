using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{

    public TeamManager mobsParty;
    private TeamManager heroParty ;
    // Start is called before the first frame update
    void Start()
    {
        heroParty = GameManager.instance.heroParty;
        heroParty.team[0].DealDamage(mobsParty.team[0]);
    }

    // Update is called once per frame
    void Update()
    {
        /*while (!mobsParty.isTeamDefeated && !heroParty.isTeamDefeated)
        {
            //Fight
            /*for (int i = 0; i < mobsParty.count()+heroParty.count(); i++)
            {
                heroParty.team[i].DealDamage(mobsParty.team[i]);
            }
        }*/

        if (mobsParty.isTeamDefeated)
        {
            Debug.Log("Hero's party win");
        }
        else if(heroParty.isTeamDefeated)
        {
            Debug.Log("Mobs's party win");
        }
    }
}
