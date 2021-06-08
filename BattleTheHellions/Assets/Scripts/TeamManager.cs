using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<ALivings> team = new List<ALivings>();
    public List<ALivings> defeatedCaracter = new List<ALivings>();

    public bool isTeamDefeated = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var member in team)
        {
            member.team = this;
        }
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
