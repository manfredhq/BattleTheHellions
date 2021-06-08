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

    public void Setup()
    {
        for (int i = 0; i < teamPrefab.Count; i++)
        {
            var temp = Instantiate(teamPrefab[i], spawnPoints[i].transform);
            team.Add(temp.GetComponent<ALivings>());
        }
        foreach (var member in team)
        {
            member.team = this;
        }
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
