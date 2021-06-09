using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonManager : MonoBehaviour
{
    public int currentRoomIndex = 0;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button insaneButton;

    public static DungeonManager instance;

    public List<roomTypes> easyDungeon = new List<roomTypes>();

    public List<roomTypes> mediumDungeon = new List<roomTypes>();

    public List<roomTypes> hardDungeon = new List<roomTypes>();

    public List<roomTypes> insaneDungeon = new List<roomTypes>();

    public List<FightRooms> easyFightRooms = new List<FightRooms>();

    public List<FightRooms> mediumFightRooms = new List<FightRooms>();

    public List<FightRooms> hardFightRooms = new List<FightRooms>();

    public List<FightRooms> insaneFightRooms = new List<FightRooms>();

    public List<ARooms> currentRun = new List<ARooms>();


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

    private void Update()
    {
        if (easyButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                easyButton = GameObject.Find("Easy").GetComponent<Button>();
                easyButton.onClick.AddListener(GenerateEasy);
            }
        }
        if (mediumButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                mediumButton = GameObject.Find("Medium").GetComponent<Button>();
                mediumButton.onClick.AddListener(GenerateMedium);
            }
        }
        if (hardButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                hardButton = GameObject.Find("Hard").GetComponent<Button>();
                hardButton.onClick.AddListener(GenerateHard);
            }
        }
        if (insaneButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                insaneButton = GameObject.Find("Insane").GetComponent<Button>();
                insaneButton.onClick.AddListener(GenerateInsane);
            }
        }
    }
    void GenerateEasy()
    {
        for (int i = 0; i < easyDungeon.Count; i++)
        {
            if(easyDungeon[i] == roomTypes.fight)
            {
                var roomIndex = Random.Range(0, easyFightRooms.Count);
                currentRun.Add(easyFightRooms[roomIndex]);
            }
            else if (easyDungeon[i] == roomTypes.fountain)
            {

            }
            else if (easyDungeon[i] == roomTypes.treasure)
            {

            }
        }
        
        if(easyDungeon[currentRoomIndex] == roomTypes.fight)
        {
            GameManager.instance.loadScene(1);
        }
        else if(easyDungeon[currentRoomIndex] == roomTypes.fountain)
        {

        }
        else if(easyDungeon[currentRoomIndex] == roomTypes.treasure)
        {

        }
    }

    void GenerateMedium()
    {

    }

    void GenerateHard()
    {

    }

    void GenerateInsane()
    {

    }
}


public enum roomTypes
{
    fight,
    fountain,
    treasure
}