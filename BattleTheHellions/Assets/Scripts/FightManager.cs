using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public float timeBetweenAttacks = 2.0f;

    public AttackTypes attacks = new AttackTypes();

    public static FightManager instance;

    public List<GameObject> spawnPoints = new List<GameObject>();

    public RewardManager rewardManager;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        heroParty = Player.instance.team;
        attacks = new AttackTypes();
        heroParty.Setup();
        mobsParty.teamPrefab = DungeonManager.instance.currentRun[DungeonManager.instance.currentRoomIndex].GetComponent<FightRooms>().mobsPrefabs;
        mobsParty.Setup();
        StartCoroutine(StartFight());
    }

    IEnumerator StartFight()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (mobsParty.isTeamDefeated)
        {
            //TODO REWARDS
            rewardManager.EarnExperience();


            Player.instance.heroes[0].GetComponent<ALivings>().maxHp += 10;

            Player.instance.team.Clean();
            foreach (var  heroe in Player.instance.heroes)
            {
                heroe.SetActive(false);
            }
            foreach (var relic in Player.instance.GetComponent<Inventory>().relicsOwn)
            {
                relic.UndoEffect();
            }

            GameManager.instance.loadScene(0);
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
                if(heroParty.count() > i) { 
                    if (!heroParty.defeatedCaracter.Contains(heroParty.team[i])) { 
                        heroParty.team[i].Attack();
                        yield return new WaitForSeconds(timeBetweenAttacks);
                    }
                }

                if (mobsParty.isTeamDefeated)
                {
                    yield break;
                }

                if (mobsParty.count() > i) { 
                    if (!mobsParty.defeatedCaracter.Contains(mobsParty.team[i]))
                    {
                        mobsParty.team[i].Attack();
                        yield return new WaitForSeconds(timeBetweenAttacks);
                    }
                }

                if (heroParty.isTeamDefeated)
                {
                    yield break;
                }
            }
        }
    }

}
