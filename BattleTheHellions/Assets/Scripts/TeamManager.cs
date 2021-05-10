using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<ALivings> team = new List<ALivings>();

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
        if(team.Count == 0)
        {
            isTeamDefeated = true;
        }
    }

    public int count()
    {
        return team.Count;
    }
}
