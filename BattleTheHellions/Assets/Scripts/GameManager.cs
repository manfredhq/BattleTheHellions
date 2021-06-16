using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Button fightButton;
    public Button saveButton;
    public Button loadButton;
    public Button teamButton;

    public List<GameObject> heroesPrefab = new List<GameObject>();

    public List<ARelics> relicsList = new List<ARelics>();



    public List<ARelics> commons = new List<ARelics>();
    public List<ARelics> uncommons = new List<ARelics>();
    public List<ARelics> rare = new List<ARelics>();
    public List<ARelics> epic = new List<ARelics>();
    public List<ARelics> legendary = new List<ARelics>();
    public List<ARelics> mythic = new List<ARelics>();
    public List<ARelics> godlike = new List<ARelics>();

    public List<List<ARelics>> relics = new List<List<ARelics>>();

    public List<List<ARelics>> relicsAvailable = new List<List<ARelics>>();

    public float[] easyRelicRates = new float[7];
    public float[] mediumRelicRates = new float[7];
    public float[] hardRelicRates = new float[7];
    public float[] insaneRelicRates = new float[7];

    // Start is called before the first frame update
    void Start()
    {
        relics.Add(commons);
        relics.Add(uncommons);
        relics.Add(rare);
        relics.Add(epic);
        relics.Add(legendary);
        relics.Add(mythic);
        relics.Add(godlike);
        relicsAvailable = relics;
        fightButton.onClick.AddListener(OnFightButtonPressed);
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
        teamButton.onClick.AddListener(() => { loadScene(5); });
        for (int i = 0; i < relicsList.Count; i++)
        {
            relicsList[i].id = i;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(fightButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                fightButton = GameObject.Find("Fight").GetComponent<Button>();
                saveButton = GameObject.Find("Save").GetComponent<Button>();
                loadButton = GameObject.Find("Load").GetComponent<Button>();
                teamButton = GameObject.Find("Team").GetComponent<Button>();
                fightButton.onClick.AddListener(OnFightButtonPressed);
                saveButton.onClick.AddListener(Save);
                loadButton.onClick.AddListener(Load);
                teamButton.onClick.AddListener(delegate{ loadScene(5); });
            }
        }
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
        
    }

    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void Save()
    {
        SavingSystem.Save(Player.instance.heroes, Player.instance.inventory.relicsOwn);
    }

    public void Load()
    {
        var heroes = SavingSystem.LoadHeroes();
        var relics = SavingSystem.LoadRelics();
        for (int i = 0; i < heroes.Count; i++)
        {
            if(Player.instance.heroes.Count > i)
            {
                Destroy(Player.instance.heroes[i].gameObject);
            }
            Player.instance.team.teamPrefab[i] = heroesPrefab[heroes[i].identity];
            var temp = Instantiate(heroesPrefab[heroes[i].identity]);
            Player.instance.heroes[i] = temp;
            temp.GetComponent<HeroManager>().Setup(heroes[i]);
        }


        Player.instance.inventory.relicsOwn = new List<ARelics>();
        for (int i = 0; i < relics.Count; i++)
        {
            ARelics temp = relicsList[relics[i]];
            Player.instance.inventory.GetRelic(temp);
        }

    }
    public void OnFightButtonPressed()
    {
        loadScene(2);
    }

    public void SetHeroesVisible()
    {
        foreach (GameObject heroes in Player.instance.heroes)
        {
            heroes.SetActive(true);
        }
    }
}
