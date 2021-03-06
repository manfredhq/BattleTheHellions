using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public TeamManager team;
    public static Player instance;

    public string username = "Unlogged";

    public List<GameObject> heroes = new List<GameObject>();

    public Inventory inventory;

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
        foreach (var prefab in team.teamPrefab)
        {
            var temp = Instantiate(prefab);
            heroes.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
