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

    public List<GameObject> heroesPrefab = new List<GameObject>();

    public List<ARelics> relicsList = new List<ARelics>();
    // Start is called before the first frame update
    void Start()
    {
        fightButton.onClick.AddListener(OnFightButtonPressed);
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
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
                fightButton.onClick.AddListener(OnFightButtonPressed);
                saveButton.onClick.AddListener(Save);
                loadButton.onClick.AddListener(Load);
            }
        }
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
        
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


        List<ARelics> relicsReplace = new List<ARelics>();
        for (int i = 0; i < relics.Count; i++)
        {
            ARelics temp = relicsList[relics[i]];
            relicsReplace.Add(temp);
        }

        Player.instance.inventory.relicsOwn = relicsReplace;
    }
    public void OnFightButtonPressed()
    {
        loadScene(2);
    }
}
