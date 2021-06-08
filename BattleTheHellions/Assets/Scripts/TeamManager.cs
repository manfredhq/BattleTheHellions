using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<ALivings> team = new List<ALivings>();
    public List<ALivings> defeatedCaracter = new List<ALivings>();

    public List<GameObject> teamPrefab = new List<GameObject>();
    public List<GameObject> spawnPoints = new List<GameObject>();

    public bool isTeamDefeated = false;

    bool isPlayerTeam = false;
    public void Setup()
    {
        if(spawnPoints.Count == 0) { 
            spawnPoints = FightManager.instance.spawnPoints;
            isPlayerTeam = true;
        }
        if (isPlayerTeam)
        {
            for (int i = 0; i < Player.instance.heroes.Count; i++)
            {
                Player.instance.heroes[i].SetActive(true);
                Player.instance.heroes[i].GetComponent<ALivings>().Setup();
                Player.instance.heroes[i].transform.SetPositionAndRotation(spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                team.Add(Player.instance.heroes[i].GetComponent<ALivings>());
            }
        }
        else { 
            for (int i = 0; i < teamPrefab.Count; i++)
            {
                var temp = Instantiate(teamPrefab[i], spawnPoints[i].transform);
                team.Add(temp.GetComponent<ALivings>());
                if (isPlayerTeam && !Player.instance.heroes.Contains(temp))
                    Player.instance.heroes.Add(temp);
            }
        }
        foreach (var member in team)
        {
            member.team = this;
        }

        InvokeRepeating("CheckTeamDefeated", 0.1f, 1f);
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckTeamDefeated()
    {
        if (defeatedCaracter.Count == team.Count)
        {
            isTeamDefeated = true;
        }
    }

    public int count()
    {
        return team.Count;
    }

    public void DeathCaracter(ALivings character)
    {
        defeatedCaracter.Add(character);
    }

    public void Clean()
    {
        CancelInvoke("CheckTeamDefeated");
        spawnPoints = new List<GameObject>();
        defeatedCaracter = new List<ALivings>();
        team = new List<ALivings>();
        isTeamDefeated = false;
    }
}
